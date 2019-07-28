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
                var wynikTyp = client.GetPacjentEmail(model.Email).Typ;
                if (wynikEmail.Count() == 1 && wynikHasło.Count() == 1 && wynikTyp == null)
                {
                    var imie = modelBaza.FirstOrDefault().Imie;
                    var wynikID = client.GetPacjentEmail(model.Email).PacjentID;
                    Session["ID"] = wynikID;
                    Session["Sesja"] = true;
                    return RedirectToAction("MenuPacjent", "Pacjent", new { imie });
                }
                else if (wynikEmail.Count() == 1 && wynikHasło.Count() == 1 && wynikTyp == "Admin")
                {
                    var imie = modelBaza.FirstOrDefault().Imie;
                    var wynikID = client.GetPacjentEmail(model.Email).PacjentID;
                    Session["ID"] = wynikID;
                    Session["Sesja"] = true;
                    return RedirectToAction("MenuAdmin", "Admin", new { imie });

                }
                else if (wynikEmail.Count() == 1 && wynikHasło.Count() == 1 && wynikTyp == "Lekarz")
                {
                    var imie = modelBaza.FirstOrDefault().Imie;
                    var wynikID = client.GetPacjentEmail(model.Email).PacjentID;
                    Session["ID"] = wynikID;
                    Session["Sesja"] = true;
                    return RedirectToAction("MenuLekarz", "Lekarz", new { imie });
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
                        TempData["Niepoprawny"] = "Bład, spróbuj ponownie.";
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
                var emailWynik = client.GetPacjentList().Where(a => a.Email == model.Email);
                if (emailWynik.Count() == 0 || emailWynik == null)
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
                        Session["Sesja"] = true;
                        var wynikID = client.GetPacjentEmail(model.Email).PacjentID;
                        Session["ID"] = wynikID;
                        return RedirectToAction("MenuPacjent", "Pacjent", new { imie = model.Imie });
                    }
                    else
                    {
                        return View("Error");
                    }
                }
                else
                {
                    ViewBag.Message = "Adres email jest juz używany!";
                    return View("Rejestracja", model);
                }

            }
            return View("Rejestracja", model);
        }

    }
}