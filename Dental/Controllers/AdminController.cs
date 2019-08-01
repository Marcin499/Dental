using DAL;
using DAL.Model;
using Dental.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Dental.Controllers
{
    public class AdminController : Controller
    {
        Metody client = new Metody();
        public ActionResult MenuAdmin()
        {
            if (Session["Sesja"] != null)
            {

                ViewBag.Strona = "Dental - Menu";
                Placowka model = new Placowka();
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult ListaPlacowki()
        {
            //List<Placowka> lista = new List<Placowka>();
            //lista.Add(new Placowka { PlacowkaID = 1, Miejscowosc = "Katowice", Nazwa = "Zabek", Telefon = 123456, Email = "adsadad" });
            List<Placowka> getPlacowki = client.GetPlacowkaList();
            var getAdres = client.GetAdresPlacowkaList();

            var model = from p in getPlacowki
                        join ad in getAdres on p.PlacowkaID equals ad.AdresID
                        select new ListaPlacowkiModel { PlacowkaID = p.PlacowkaID, Nazwa = p.Nazwa, Telefon = p.Telefon, Email = p.Email, Wojewodztwo = ad.Wojewodztwo, Miasto = ad.Miasto, Ulica = ad.Ulica, Numer = ad.Numer };

            return PartialView(model);
        }

        public ActionResult DodajPlacowke()
        {
            if (Session["Sesja"] != null)
            {

                ViewBag.Strona = "Dental - Dodaj Gabinet";
                DodajPlacowkeModel model = new DodajPlacowkeModel();
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        [HttpPost]
        public ActionResult SavePlacowka(DodajPlacowkeModel model)
        {
            if (Session["Sesja"] != null)
            {
                if (ModelState.IsValid)
                {
                    AdresPlacowka adresModel = new AdresPlacowka()
                    {
                        Wojewodztwo = model.Wojewodztwo.ToString(),
                        Miasto = model.Miasto,
                        Ulica = model.Ulica,
                        Numer = model.Numer
                    };

                    Placowka placowkaModel = new Placowka()
                    {
                        Nazwa = model.Numer,
                        Telefon = model.Telefon,
                        Email = model.Email,
                        PlacowkaAdresPlacowka = adresModel
                    };

                    bool isOk = client.PlacowkaInsert(placowkaModel);
                    if (isOk == true)
                    {
                        TempData["Zapisano"] = "Gabinet został dodany!";
                        return RedirectToAction("Administracja", "Admin");
                    }
                    else
                    {
                        return View("Error");
                    }
                }
                else
                {
                    return View("DodajPlacowke", model);
                }

            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }


        public ActionResult DeletePlacowka(int PlacowkaID)
        {
            if (Session["Sesja"] != null)
            {
                bool isOk = client.PlacowkaDelete(PlacowkaID);

                if (isOk == true)
                {
                    TempData["Zapisano"] = "Gabinet został usunięty!";
                    return RedirectToAction("Administracja", "Admin");
                }
                else
                {
                    return View("Error");
                }
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

                ViewBag.Strona = "Dental - Menu";

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult Personel()
        {
            if (Session["Sesja"] != null)
            {

                ViewBag.Strona = "Dental - Menu";

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

                ViewBag.Strona = "Dental - Menu";

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult Administracja()
        {
            if (Session["Sesja"] != null)
            {

                ViewBag.Strona = "Dental - Menu";

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult Zabiegi()
        {
            if (Session["Sesja"] != null)
            {

                ViewBag.Strona = "Dental - Menu";

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

    }
}