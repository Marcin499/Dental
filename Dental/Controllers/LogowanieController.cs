

using DAL.Model;
using Dental.Models;
using System.Web.Mvc;

namespace Dental.Controllers
{
    public class LogowanieController : Controller
    {
        readonly DentalReference.DentalServiceClient client = new DentalReference.DentalServiceClient();
        public ActionResult Login()
        {
            ViewBag.Strona = "Dental - Logowanie";
            Pacjent model = new Pacjent();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(Pacjent pac)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Strona = "Dental - Rejestracja";

                RejestracjaModel model = new RejestracjaModel
                {
                    Email = pac.Email,
                    Hasło = pac.Haslo,
                    PowtorzHaslo = pac.PowtorzHaslo
                };
                return View(model);
            }
            return View(pac);

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}