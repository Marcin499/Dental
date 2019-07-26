using DAL;
using DAL.Model;
using Dental.Models;
using System.Linq;
using System.Web.Mvc;

namespace Dental.Controllers
{
    public class LogowanieController : Controller
    {
        Metody client = new Metody();

        public ActionResult Login()
        {
            ViewBag.Strona = "Dental - Logowanie";
            LogowanieModel model = new LogowanieModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Logowanie(LogowanieModel model)
        {
            if (ModelState.IsValid)
            {
                var modelBaza = client.GetPacjentList();
                var wynikEmail = modelBaza.Where(p => p.Email == model.Email);
                var wynikHasło = modelBaza.Where(p => p.Haslo == model.Haslo);
                if (wynikEmail.Count() == 1 && wynikHasło.Count() == 1)
                {
                    var imie = modelBaza.FirstOrDefault().Imie;
                    return RedirectToAction("MenuPacjentView", "Pacjent", new { imie = imie });
                }
                else
                {
                    ViewBag.Message = "Błędne hasło lub email!";
                    return View("Login", model);

                }
            }
            return View("Login", model);
        }

        public ActionResult ResetHaslaView()
        {
            ResetHaslaLogowanieModel model = new ResetHaslaLogowanieModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult ResetHasla(ResetHaslaLogowanieModel model)
        {
            if (ModelState.IsValid)
            {
                var pobierz = client.GetPacjentEmail(model.Email);
                if (model.Email == pobierz.Email)
                {
                    Pacjent modelToInsert = new Pacjent()
                    {
                        PacjentID = pobierz.PacjentID,
                        Imie = pobierz.Imie,
                        Nazwisko = pobierz.Nazwisko,
                        Email = pobierz.Email,
                        PESEL = pobierz.PESEL,
                        Haslo = model.Haslo,
                        PowtorzHaslo = model.PowtorzHaslo,
                        Telefon = pobierz.Telefon

                    };

                    bool isOk = client.PacjentUpdate(modelToInsert);
                    if (isOk == true)
                    {
                        TempData["PoprawnyReset"] = "Poprawnie zresetowano hasło!";
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        ViewBag.Message = "Bład, spróbuj ponownie.";
                        return View("ResetHaslaView", model);
                    }

                }

            }
            return View("ResetHaslaView", model);
        }

        public ActionResult Rejestracja()
        {
            ViewBag.Strona = "Dental - Rejestracja";
            RejestracjaModel model = new RejestracjaModel();
            return View(model);
        }


        [HttpPost]
        public ActionResult SaveRejestracja(RejestracjaModel model)
        {
            if (ModelState.IsValid)
            {
                Adres modelAdres = new Adres()
                {

                    Miasto = model.Miasto,
                    Wojewodztwo = model.Wojewodztwo.ToString(),
                    Ulica = model.Ulica,
                    Numer = model.Numer,
                    Kod = model.Kod
                };

                Pacjent modelPacjent = new Pacjent()
                {
                    Imie = model.Imie,
                    Nazwisko = model.Nazwisko,
                    PESEL = model.PESEL,
                    Telefon = model.Telefon,
                    Email = model.Email,
                    Haslo = model.Haslo,
                    PowtorzHaslo = model.PowtorzHaslo,
                    PacjentAdres = modelAdres

                };

                bool isOkPacjent = client.PacjentInsert(modelPacjent);


                if (isOkPacjent == true)
                {
                    return RedirectToAction("MenuPacjentView", "Pacjent");
                }
                else
                {
                    return View("Error");
                }
            }
            return View("Rejestracja", model);
        }


    }
}