using System.Web.Mvc;

namespace HitaRasDhara.Controllers
{
    public class VisionController : Controller
    {
        // GET: Vision
        public ActionResult Index()
        {
            ViewBag.Title = "Shree Hita Ambrish Ji - Vision | Path of eternal love | Hita Ras Dhara | Official Website";
            ViewBag.Description =
                "Shree Hita Ambrish Ji's vision for humanity includes offering eternal love by rejuvenating spiritual sciences especially among youth. ";
            return View();
        }
    }
}