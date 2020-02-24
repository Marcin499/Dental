
using DAL;
using DAL.Model;
using Dental.Models;
using System.Linq;
using System.Web.Mvc;

namespace Dental.Controllers
{
    public class LogowanieController : BazowyController
    {
        Metody bazaMetod = new Metody();

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
                var modelBaza = bazaMetod.GetPacjentList();
                var modelBazaPersonel = bazaMetod.GetPesonelList();

                var wynikEmail = modelBaza.Where(p => p.Email == model.Email).FirstOrDefault();
                var wynikEmail2 = modelBazaPersonel.Where(p => p.Email == model.Email).FirstOrDefault();

                var wynikTyp = bazaMetod.GetPacjentEmail(model.Email);

                if (wynikEmail == null)
                {
                    if (wynikEmail2 == null)
                    {
                        ViewBag.Message = "Błędne hasło lub email!";
                    }
                    else if (wynikEmail2.Haslo == model.Haslo)
                    {
                        var wynikTyp2 = bazaMetod.GetPersonelEmail(model.Email).Typ;

                        if (wynikTyp2 == "Administrator")
                        {
                            var imie = wynikEmail2.Imie;
                            var wynikID = bazaMetod.GetPersonelEmail(model.Email).PersonelID;
                            Session["ID"] = wynikID;
                            Session["Sesja"] = true;

                            return RedirectToAction("Wizyta", "Admin", new { imie });

                        }
                        else if (wynikTyp2 == "Personel")
                        {
                            var imie = wynikEmail2.Imie;
                            var wynikID = bazaMetod.GetPersonelEmail(model.Email).PersonelID;
                            Session["ID"] = wynikID;
                            Session["Sesja"] = true;
                            return RedirectToAction("MenuLekarz", "Lekarz", new { imie });
                        }
                    }
                    ViewBag.Message = "Błędne hasło lub email!";
                }
                else
                {
                    if (wynikEmail.Haslo == model.Haslo)
                    {
                        if (wynikTyp != null)
                        {
                            if (wynikTyp.Typ == null)
                            {
                                var imie = wynikEmail.Imie;
                                var wynikID = bazaMetod.GetPacjentEmail(model.Email).PacjentID;
                                Session["ID"] = wynikID;
                                Session["Sesja"] = true;
                                var pacjentID = wynikEmail.PacjentID;
                                return RedirectToAction("WizytaNew", "Pacjent", new { imie, pacjentID });
                            }
                        }
                    }
                    ViewBag.Message = "Błędne hasło lub email!";
                }

                return View("Login", model);
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
                var pobierz = bazaMetod.GetPacjentEmail(model.Email);

                if (pobierz == null)
                {
                    TempData["Niepoprawny"] = "Nie ma takiego adresu email";
                    return View("ResetHaslaView", model);
                }
                else if (model.Email == pobierz.Email)
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


                    bool isOk = bazaMetod.PacjentUpdateResetHasla(modelToInsert);
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
                var emailWynik = bazaMetod.GetPacjentList().Where(a => a.Email == model.Email);

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
                        Imie = model.Imie.ToUpper(),
                        Nazwisko = model.Nazwisko.ToUpper(),
                        PESEL = model.PESEL,
                        Telefon = model.Telefon,
                        Email = model.Email.ToLower(),
                        Haslo = model.Haslo,
                        PowtorzHaslo = model.PowtorzHaslo,
                        PacjentAdres = modelAdres,
                        DataUrodzin = model.DataUrodzin

                    };

                    bool isOkPacjent = bazaMetod.PacjentInsert(modelPacjent);


                    if (isOkPacjent == true)
                    {
                        Session["Sesja"] = true;
                        var wynikID = bazaMetod.GetPacjentEmail(model.Email).PacjentID;
                        Session["ID"] = wynikID;
                        return RedirectToAction("WizytaNew", "Pacjent", new { imie = model.Imie });
                    }
                    else
                    {
                        return PartialView("Error");
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