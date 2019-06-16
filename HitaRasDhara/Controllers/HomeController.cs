using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HitaRasDhara.Models;

namespace HitaRasDhara.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var viewModel = new UpcomingKathaViewModel();
            ApplicationDbContext _dbContext = new ApplicationDbContext();
            var currTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow,
                TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            viewModel = new UpcomingKathaViewModel
            {
                KathaFeed = 
                    _dbContext.UpcomingKathaFeed.Select(m => m).Where(x => x.UnpublishDate > currTime).
                        OrderBy(a => a.UnpublishDate).ToList().GetRange(0, 3)
            };
            ViewBag.SadhakSanjeevaniFeed = new SadhakSanjeevaniViewModel
            {
                SadhakSanjeevaniFeed =
                    _dbContext.SadhakSanjeevaniFeed.Select(a => a).Where(s => s.VisibleOnHome).ToList()
            };
            ViewBag.Title = "Shree Hita Ambrish Ji | Spiritual Mentor | Official Website";
            ViewBag.Description =
                "The Official Website of Shree Hita Ambrish Ji with Upcoming Katha Schedule (Discourses), Photo Gallery, Youth Session, and all Katha & Bhajan Recordings.";
            return View(viewModel);
        }
        public ActionResult Reprint()
        {
            return Redirect("~/");
        }
        public ActionResult CancelRegistration()
        {
            return Redirect("~/");
        }
    }
}