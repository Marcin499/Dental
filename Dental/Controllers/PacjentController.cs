using System.Web.Mvc;

namespace Dental.Controllers
{
    public class PacjentController : Controller
    {
        
        public ActionResult MenuPacjentView(string imie)
        {
            ViewBag.Strona = "Dental - Menu";
            ViewBag.Zaloguj = imie;
            return View();
        }
    }
}