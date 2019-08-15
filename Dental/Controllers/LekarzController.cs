using DAL;
using Dental.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Dental.Controllers
{
    public class LekarzController : Controller
    {
        Metody client = new Metody();
        public ActionResult MenuLekarz()
        {
            if (Session["Sesja"] != null)
            {

                ViewBag.Strona = "Dental - Kalendarz";
                var id = Session["ID"];
                var listaWizyt = client.GetWizytaByDateAndDoctor(DateTime.Now.ToShortDateString(), Convert.ToInt32(id));
                var wizyty = client.GetWizytaList().Where(a => a.Data == DateTime.Now.ToShortDateString() && a.LekarzID == (int)id);
                var pacjenci = client.GetPacjentList();
                var model = from c in wizyty
                            join a in pacjenci on c.PacjentID equals a.PacjentID
                            select new ListaWizytModel()
                            {
                                WizytaID = c.WizytaID,
                                Imie = a.Imie,
                                Nazwisko = a.Nazwisko,
                                PESEL = a.PESEL,
                                Godzina = c.Godzina,
                                Stan = c.Stan,
                                Uwagi = c.Uwagi
                            };

                TempData["Data"] = DateTime.Today.ToShortDateString();
                TempData["Wizyty"] = listaWizyt.Count;
                TempData.Keep();

                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }


        public ActionResult ListaWizyty(string data)
        {
            ViewBag.Strona = "Dental - Kalendarz";
            var id = Session["ID"];
            var listaWizyt = client.GetWizytaByDateAndDoctor(data, Convert.ToInt32(id));
            var wizyty = client.GetWizytaList().Where(a => a.Data == data && a.LekarzID == (int)id);
            var pacjenci = client.GetPacjentList();
            var model = from c in wizyty
                        join a in pacjenci on c.PacjentID equals a.PacjentID
                        select new ListaWizytModel()
                        {
                            WizytaID = c.WizytaID,
                            Imie = a.Imie,
                            Nazwisko = a.Nazwisko,
                            PESEL = a.PESEL,
                            Godzina = c.Godzina,
                            Stan = c.Stan,
                            Uwagi = c.Uwagi
                        };

            TempData["Data"] = data;
            TempData["Wizyty"] = listaWizyt.Count;
            TempData.Keep();
            return PartialView(model);

        }

        public ActionResult Wizyta()
        {
            if (Session["Sesja"] != null)
            {
                ViewBag.Strona = "Dental - Wizyta";
                var id = Session["ID"];
                var listaWizyt = client.GetWizytaByDateAndDoctor(DateTime.Now.ToShortDateString(), Convert.ToInt32(id));
                var wizyty = client.GetWizytaList().Where(a => a.Data == DateTime.Now.ToShortDateString() && a.LekarzID == (int)id && a.Stan == "Oczekuje w kolejce");
                var pacjenci = client.GetPacjentList();
                var model = from c in wizyty
                            join a in pacjenci on c.PacjentID equals a.PacjentID
                            select new ListaWizytModel()
                            {
                                WizytaID = c.WizytaID,
                                Imie = a.Imie,
                                Nazwisko = a.Nazwisko,
                                PESEL = a.PESEL,
                                Godzina = c.Godzina,
                                Stan = c.Stan,
                                Uwagi = c.Uwagi,
                                DataUrodzin = c.DataUrodzenia
                            };

                var modelWidok = model.OrderByDescending(a => a.Godzina);
                var pacjent = model.OrderByDescending(a => a.Godzina).FirstOrDefault();
                var wiek = DateTime.Today.Year - pacjent.DataUrodzin.Year;
                TempData["Wiek"] = wiek;
                TempData["Pacjent"] = pacjent.Imie + " " + pacjent.Nazwisko;
                return View(modelWidok);
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }
    }


}