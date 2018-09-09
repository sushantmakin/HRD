using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using HitaRasDhara.Models;

namespace HitaRasDhara.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            ApplicationDbContext _dbContext = new ApplicationDbContext();
            var viewModel = new DbViewForDashboard { ContentItems = _dbContext.UserResponse5Aug.Select(m => m).ToList() };
            ViewBag.TotalRegistration = _dbContext.UserResponse5Aug.Count();
            ViewBag.RegisteredUsers = _dbContext.UserResponse5Aug.Count(t => t.SeatStatus == "Registered");
            ViewBag.CancelledUsers = ViewBag.TotalRegistration - ViewBag.RegisteredUsers;
            ViewBag.QuestionUsers = _dbContext.UserResponse5Aug.Count(x => x.Question != null);
            return View(viewModel);
        }

        public ActionResult Feedback()
        {
            ApplicationDbContext _dbContext = new ApplicationDbContext();
            var viewModel = new DbViewForFeedback { ContentItems = _dbContext.Feedback5August.Select(m => m).ToList() };
            ViewBag.TotalFeedback = _dbContext.Feedback5August.Count();
           return View(viewModel);
        }

        public ActionResult Query()
        {
            ApplicationDbContext _dbContext = new ApplicationDbContext();
            var viewModel = new DbViewForQuery { ContentItems = _dbContext.QueryForm.Select(m => m).ToList() };
            ViewBag.TotalQueries = _dbContext.QueryForm.Count();
            return View(viewModel);
        }

        public void WriteTsv<T>(IEnumerable<T> data, TextWriter output)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            foreach (PropertyDescriptor prop in props)
            {
                output.Write(prop.DisplayName); // header
                output.Write("\t");
            }
            output.WriteLine();
            foreach (T item in data)
            {
                foreach (PropertyDescriptor prop in props)
                {
                    output.Write(prop.Converter.ConvertToString(
                        prop.GetValue(item)));
                    output.Write("\t");
                }
                output.WriteLine();
            }
        }


        public void ExportListFromTsvDashboard()
        {
            try
            {
                ApplicationDbContext _DbContextForDownloadExcel = new ApplicationDbContext();
                var data = _DbContextForDownloadExcel.UserResponse5Aug.Select(m => m).ToList();
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment;filename=RegistrationDashboard.xls");
                Response.AddHeader("Content-Type", "application/vnd.ms-excel");
                WriteTsv(data, Response.Output);
                Response.End();
            }
            catch
            {
                //Ignore
            }
        }

        public void ExportListFromTsvFeedback()
        {
            try
            {
                ApplicationDbContext _DbContextForDownloadExcel = new ApplicationDbContext();
                var data = _DbContextForDownloadExcel.Feedback5August.Select(m => m).ToList();
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment;filename=FeedbackDashboard.xls");
                Response.AddHeader("Content-Type", "application/vnd.ms-excel");
                WriteTsv(data, Response.Output);
                Response.End();
            }
            catch
            {
                //Ignore
            }
        }
    }

    public class DbViewForDashboard
    {
        public List<UserResponse5Aug> ContentItems { get; set; }
    }
    public class DbViewForFeedback
    {
        public List<EventFeedbackViewModel> ContentItems { get; set; }
    }

    public class DbViewForQuery
    {
        public List<QueryViewModel> ContentItems { get; set; }
    }
}