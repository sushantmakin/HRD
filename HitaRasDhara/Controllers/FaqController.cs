
using System.Web.Mvc;

namespace HitaRasDhara.Controllers
{
    public class FaqController : Controller
    {
        // GET: Faq
        public ActionResult Index()
        {
            ViewBag.Title = "FAQ - Shree Hita Ambrish Ji | Spiritual Mentor | Official Website";
            ViewBag.Description =
                "The Official Website of Shree Hita Ambrish Ji with Upcoming Katha Schedule (Discourses), Photo Gallery, Youth Session, and all Katha & Bhajan Recordings.";
            return View();
        }
    }
}