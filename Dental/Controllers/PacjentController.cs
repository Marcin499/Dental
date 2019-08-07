using DAL;
using DAL.Model;
using Dental.Models;
using System;
using System.Web.Mvc;

namespace Dental.Controllers
{
    public class PacjentController : Controller
    {
        Metody client = new Metody();

        public ActionResult MenuPacjent(string imie)
        {

            if (Session["Sesja"] != null)
            {

                ViewBag.Strona = "Dental - Menu";
                TempData["imie"] = imie;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }

        }

        public ActionResult Wizyta()
        {
            if (Session["Sesja"] != null)
            {
                ViewBag.Strona = "Dental - Wizyta";
                TempData.Keep();
                DodajWizyteModel model = new DodajWizyteModel();
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult WizytaGabinet(string miasto)
        {
            DodajWizyteModel model = new DodajWizyteModel(miasto);

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult WizytaGabinet2(string miasto)
        {
            DodajWizyteModel model = new DodajWizyteModel(miasto);

            return PartialView(model);
        }

        public ActionResult WizytaLekarz(string gabinet)
        {
            LekarzeModel model = new LekarzeModel(gabinet);

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult WizytaLekarz2(string gabinet)
        {
            LekarzeModel model = new LekarzeModel(gabinet);

            return PartialView(model);
        }

        public ActionResult WizytaGodzina(string lekarz)
        {
            LekarzeModel model = new LekarzeModel(lekarz);

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult WizytaGodzina2(string lekarz)
        {
            LekarzeModel model = new LekarzeModel(lekarz);

            return PartialView(model);
        }

        public ActionResult Historia()
        {
            if (Session["Sesja"] != null)
            {
                ViewBag.Strona = "Dental - Historia";
                TempData.Keep();
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult Cennik()
        {
            if (Session["Sesja"] != null)
            {
                ViewBag.Strona = "Dental - Cennik";
                TempData.Keep();
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult Kontakt()
        {
            if (Session["Sesja"] != null)
            {
                ViewBag.Strona = "Dental - Kontakt";
                TempData.Keep();
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult Profil()
        {
            if (Session["Sesja"] != null)
            {
                var id = Session["ID"];
                var wynikPacjentID = client.GetPacjentByID(Convert.ToInt32(id));
                var wynikAdresID = client.GetAdresByID(Convert.ToInt32(id));
                ViewBag.Strona = "Dental - Profil";
                TempData.Keep();


                EditPacjentModel editPacjentModel = new EditPacjentModel(wynikAdresID.Wojewodztwo)
                {
                    PacjentID = wynikPacjentID.PacjentID,
                    Imie = wynikPacjentID.Imie,
                    Nazwisko = wynikPacjentID.Nazwisko,
                    PESEL = wynikPacjentID.PESEL,
                    Telefon = wynikPacjentID.Telefon,
                    Email = wynikPacjentID.Email,
                    Haslo = wynikPacjentID.Haslo,
                    PowtorzHaslo = wynikPacjentID.PowtorzHaslo,
                    Miasto = wynikAdresID.Miasto,
                    Ulica = wynikAdresID.Ulica,
                    Numer = wynikAdresID.Numer,
                    Kod = wynikAdresID.Kod,
                    Wojewodztwo = wynikAdresID.Wojewodztwo
                };

                return View(editPacjentModel);
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }


        public ActionResult DeleteKonto(int dane)
        {
            if (Session["Sesja"] != null)
            {
                bool isOk = client.PacjentDelete(dane);

                return Json(isOk, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        [HttpPost]
        public ActionResult SaveEdit(EditPacjentModel model)
        {
            if (ModelState.IsValid)
            {
                if (Session["Sesja"] != null)
                {
                    Adres modelAdres = new Adres()
                    {
                        Miasto = model.Miasto,
                        Ulica = model.Ulica,
                        Wojewodztwo = model.Wojewodztwo,
                        Kod = model.Kod,
                        Numer = model.Numer

                    };

                    Pacjent modelPacjent = new Pacjent()
                    {
                        PacjentID = model.PacjentID,
                        Imie = model.Imie,
                        Nazwisko = model.Nazwisko,
                        Telefon = model.Telefon,
                        Email = model.Email,
                        Haslo = model.Haslo,
                        PESEL = model.PESEL,
                        PowtorzHaslo = model.PowtorzHaslo,
                        PacjentAdres = modelAdres
                    };

                    bool isOk = client.PacjentUpdate(modelPacjent);
                    if (isOk == true)
                    {
                        TempData["Success"] = "Dane zostały zaktualizowane!";
                        return RedirectToAction("Profil");
                    }
                    else
                    {
                        TempData["Success"] = "Błąd! Spróbuj ponownie!";
                        return RedirectToAction("Profil");
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Logowanie");
                }
            }
            else
            {
                return RedirectToAction("Profil", model);
            }
        }
    }
}