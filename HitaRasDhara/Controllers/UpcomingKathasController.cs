using System;
using System.Web.Mvc;

namespace HitaRasDhara.Controllers
{
    public class UpcomingKathasController : Controller
    {
        // GET: UpcomingKathas
        public ActionResult Index()
        {
            return RedirectPermanent(Url.Action("Index", "UpcomingDiscourses"));
        }
    }
}

