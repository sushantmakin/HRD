using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using HitaRasDhara.Models;

namespace HitaRasDhara.Controllers
{
    public class AdminController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            ApplicationDbContext _dbContext = new ApplicationDbContext();
            var viewModel = new DbViewForDashboard { ContentItems = _dbContext.UserResponse5Aug.Select(m => m).ToList() };
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
    }

    public class DbViewForDashboard
    {
        public List<UserResponse5Aug> ContentItems { get; set; }
    }
}