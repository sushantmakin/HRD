using System;
using System.Linq;
using System.Web.Mvc;
using HitaRasDhara.Models;

namespace HitaRasDhara.Controllers
{
    public class UpcomingKathasController : Controller
    {
        // GET: UpcomingKathas
        public ActionResult Index()
        {
            var viewModel = new UpcomingKathaViewModel();
            ApplicationDbContext _dbContext = new ApplicationDbContext();
            var currTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow,
                TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            viewModel = new UpcomingKathaViewModel { KathaFeed = _dbContext.UpcomingKathaFeed.Select(m => m).Where(x => x.UnpublishDate > currTime).OrderBy(a => a.UnpublishDate).ToList() };
            ViewBag.Title = "Upcoming Katha Schedule | Shree Hita Ambrish Ji";
            ViewBag.Description = "Find the details of upcoming katha Schedule by Shree Hita Ambrish Ji.";
            return View(viewModel);
        }
    }
}