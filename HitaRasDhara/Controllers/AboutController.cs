using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HitaRasDhara.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            ViewBag.Title = "Shree Hita Ambrish Ji | Spiritual Mentor | Official Website";
            ViewBag.Description =
                "The Official Website of Shree Hita Ambrish Ji with Upcoming Katha Schedule (Discourses), Photo Gallery, Youth Session, and all Katha & Bhajan Recordings.";
            return View();
        }

        public ActionResult HitaAmbrishJi()
        {
            ViewBag.Title = "About Shree Hita Ambrish Ji | Spiritual Mentor";
            ViewBag.Description = "Shree Hita Ambrish ji is a charismatic young spiritual Mentor from Vrindavan, with a refreshing take on devotion to the divine.";
            return View();
        }

        public ActionResult ShreeRadhaVallabhJi()
        {
            ViewBag.Title = "About Shree Radhavallabh Lal | History of Shree Radhavallabh Lal Ji | Shree Hita Ambrish Ji";
            ViewBag.Description =
                "Love in its tangible form appeared as Shree Radhavallabh Lal in Shree Vishvanath’s (Lord Shiva) heart.The adoration of Shree Radhavallabh Lal is the adoration of absolute love";
            return View();
        }

        public ActionResult HitaTheEternal()
        {
            ViewBag.Title = "About Hita The Eternal | Shree Hita Ambrish Ji";
            ViewBag.Description =
                "Hita Ras Dhara ! A team of devoted followers  channelizing their energy in spreading the fragrance of the divine Love.";
            return View();
        }

        public ActionResult HitaRasDhara()
        {
            ViewBag.Title = "About Hita Ras Dhara | Shree Hita Ambrish Ji";
            ViewBag.Description =
                "Hita Ras Dhara ! A team of devoted followers  channelizing their energy in spreading the fragrance of the divine Love.";
            return View();
        }
    }
}