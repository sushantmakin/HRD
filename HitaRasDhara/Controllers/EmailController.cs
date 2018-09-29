using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HitaRasDhara.Models;

namespace HitaRasDhara.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(EmailViewModel input)
        {
            var msg = input.EmailBody.Replace(Environment.NewLine,"<br/>");
            return Json(new { Code = msg }, JsonRequestBehavior.AllowGet); //registration already cancelled.
        }
    }
}