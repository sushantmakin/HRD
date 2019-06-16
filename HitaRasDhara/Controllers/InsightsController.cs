
using System.Linq;
using System.Web.Mvc;
using HitaRasDhara.Models;

namespace HitaRasDhara.Controllers
{
    public class InsightsController : Controller
    {
        // GET: Insights
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HitaSpot()
        {
            var viewModel = new SadhakSanjeevaniViewModel();
            ApplicationDbContext _dbContext = new ApplicationDbContext();
            viewModel = new SadhakSanjeevaniViewModel
            {
                SadhakSanjeevaniFeed =
                    _dbContext.SadhakSanjeevaniFeed.Select(a => a).Where(s => s.VisibleOnInsidePage).ToList()
            };
            ViewBag.Title = "Hita Spot - Shree Hita Ambrish Ji | Insights | Hita Ras Dhara | Official Website";
            ViewBag.Description =
                "Catch up with Shree Hita Ambrish Ji through Articles, Quotes, Latest Videos , Insights on official website of Shree Hita Ambrish Ji.";
            return View(viewModel);
        }

        public ActionResult Quotes()
        {
            ViewBag.Title = "Quotes - Shree Hita Ambrish Ji | Quotes | Hita Ras Dhara | Official Website";
            ViewBag.Description =
                " Inspirational Quotes by Shree Hita Ambrish Ji providing intense wisdom about life. Catch up with Shree Hita Ambrish Ji through Articles, Quotes, Latest Videos , Insights on official website of Shree Hita Ambrish Ji.";
            return View();
        }

        public ActionResult Articles()
        {
            ViewBag.Title = "Articles - Shree Hita Ambrish Ji | Hita Ras Dhara | Official Website";
            ViewBag.Description =
                "Shree Hita Ambrish Ji's blogs is a collection of his enlightening discourses addressing various aspects of one's life and queries on the path of spiritual journey. Catch up with Shree Hita Ambrish Ji through Articles, Quotes, Latest Videos , Insights on official website of Shree Hita Ambrish Ji.";
            return View();
        }

        public ActionResult Videos()
        {
            return View();
        }

        public ActionResult Audios()
        {
            return View();
        }
    }
}