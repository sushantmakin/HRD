using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HitaRasDhara.Controllers
{
    public class PrivacyController : Controller
    {
        // GET: Privacy
        public ActionResult Index()
        {
            ViewBag.Title = "Privacy Policy - Shree Hita Ambrish Ji | Spiritual Mentor | Official Website";
            ViewBag.Description =
                "The Official Website of Shree Hita Ambrish Ji with Upcoming Katha Schedule (Discourses), Photo Gallery, Youth Session, and all Katha & Bhajan Recordings.";
            return View();
        }
    }
}