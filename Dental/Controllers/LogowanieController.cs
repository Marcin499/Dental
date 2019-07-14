using Dental.ServiceReference;
using System.Web.Mvc;

namespace Dental.Controllers
{
    public class LogowanieController : Controller
    {
        ServiceClient client = new ServiceClient();
        public ActionResult Login()
        {
            ViewBag.Strona = "Strona głowna";
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}