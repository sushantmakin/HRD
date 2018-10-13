using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using HitaRasDhara.Models;
using System.ComponentModel;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

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
            ViewBag.EnteredUsers = _dbContext.UserResponse5Aug.Count(t => t.SeatStatus == "Entered");
            ViewBag.CancelledUsers = _dbContext.UserResponse5Aug.Count(t => t.SeatStatus == "Cancelled");
            ViewBag.NoShowListeners = ViewBag.RegisteredUsers - ViewBag.EnteredUsers;
            ViewBag.QuestionUsers = _dbContext.UserResponse5Aug.Count(x => x.Question != null);
            ViewBag.IdPrefix = _dbContext.SmsContent.Find("RegistrationTemplate")?.Value;
            return View(viewModel);
        }

        public bool Reseed()
        {
            try
            {
                ApplicationDbContext dbContext = new ApplicationDbContext();
                dbContext.Database.ExecuteSqlCommand("DBCC CHECKIDENT('UserResponse5Aug', RESEED, 0)");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public ActionResult EventDetailed()
        {
            ApplicationDbContext _dbContext = new ApplicationDbContext();
            var viewModel = new DbViewForDashboard { ContentItems = _dbContext.UserResponse5Aug.Select(m => m).ToList() };
            ViewBag.IdPrefix = _dbContext.SmsContent.Find("RegistrationTemplate")?.Value;
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
            var viewModel = new DbViewForQuery { ContentItems = _dbContext.QueryForm.Select(m => m).ToList()  };
            viewModel.ContentItems.Reverse();
            ViewBag.TotalQueries = _dbContext.QueryForm.Count();
            ViewBag.PendingReplies = _dbContext.QueryForm.Count(t => t.Status == "Pending");
            ViewBag.RepliedQueries = _dbContext.QueryForm.Count(t => t.Status == "Replied");
            ViewBag.CancelledQueries = _dbContext.QueryForm.Count(t => t.Status == "Cancelled");
            return View(viewModel);
        }

        public ActionResult QueryReply()
        {
            var queryId = HttpContext.Request.QueryString["QueryId"];
            if (!string.IsNullOrEmpty(queryId))
            {
                ApplicationDbContext _dbContext = new ApplicationDbContext();
                var viewModel = new EmailViewModel();
                var queryDetails = _dbContext.QueryForm.Find(Convert.ToInt32(queryId));
                if (queryDetails == null)
                {
                    return RedirectToAction("Query", "Admin");
                }
                viewModel = new EmailViewModel
                {
                    EmailBody = string.Format(_dbContext.SmsContent.Find("QueryReplyBody").Value, Environment.NewLine, queryDetails.Name, queryDetails.Query.Replace("<br/>",Environment.NewLine)),
                    EmailSubject = _dbContext.SmsContent.Find("QueryReplySubject").Value,
                    EmailTo = queryDetails.Email,
                    Id = int.Parse(queryId)
                            
                };
                return View(viewModel);
            }
            return RedirectToAction("Query", "Admin");
        }

        [HttpPost]
        public ActionResult CancelQuery(string queryId)
        {
            try
            {
                ApplicationDbContext _dbContext = new ApplicationDbContext();
                var queryDetails = _dbContext.QueryForm.Find(Convert.ToInt32(queryId));
                if (queryDetails.Status == "Cancelled")
                {
                    return Json(new { Code = 21 }, JsonRequestBehavior.AllowGet);
                }
                queryDetails.Status = "Cancelled";
                queryDetails.Response = "NA";
                _dbContext.SaveChanges();
                return Json(new { Code = 20 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Code = 3 }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult QueryReply(EmailViewModel input)
        {
            try
            {
                #region email
                MailMessage msg = new MailMessage();
                msg.To.Add(new MailAddress(input.EmailTo));
                msg.To.Add(new MailAddress("info@hitaambrish.com"));
                msg.From = new MailAddress("info@hitaambrish.com", "Hita Ambrish");
                msg.Subject = input.EmailSubject;
                msg.Body = input.EmailBody.Replace(Environment.NewLine, "<br/>"); 
                msg.IsBodyHtml = true;

                SmtpClient client = new SmtpClient();
                client.Credentials = new NetworkCredential("info@hitaambrish.com", "Sushant@123");
                client.Port = 25;
                client.Host = "relay-hosting.secureserver.net";
                client.Send(msg);
                #endregion

                ApplicationDbContext _dbContext = new ApplicationDbContext();
                var fullQueryData = _dbContext.QueryForm.Find(input.Id);
                fullQueryData.Status = "Replied";
                fullQueryData.Response = input.EmailBody.Replace(Environment.NewLine, "<br/>");
                _dbContext.SaveChanges();
                return Json(new { Code = 19 }, JsonRequestBehavior.AllowGet); //registration already cancelled.
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                Console.WriteLine(e);
                return Json(new { Code = 3 }, JsonRequestBehavior.AllowGet); //registration already cancelled.
            }
            
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