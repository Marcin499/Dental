using DAL;
using DAL.Model;
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
                TempData["Ide"] = id;
                TempData["Wiek"] = wiek;
                TempData["Pacjent"] = pacjent.Imie + " " + pacjent.Nazwisko;
                return View(modelWidok);
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult Leczenie(string pacjent, int wiek, int id)
        {
            if (Session["Sesja"] != null)
            {
                TempData["Wiek"] = wiek;
                TempData["Pacjent"] = pacjent;
                TempData["ID"] = id;


                return View();
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult ListaZebow(int id)
        {
            if (Session["Sesja"] != null)
            {
                TempData["ID"] = id;
                KategoriaModel model = new KategoriaModel();
                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult Rozpoznanie()
        {
            if (Session["Sesja"] != null)
            {

                return PartialView();
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult ListaLeczenia()
        {
            if (Session["Sesja"] != null)
            {

                return PartialView();
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        [HttpPost]
        public ActionResult Zeby(string kategoria)
        {
            if (Session["Sesja"] != null)
            {
                ZebyModel model = new ZebyModel(kategoria);

                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        [HttpPost]
        public ActionResult BrakujaceZeby(int id)
        {
            if (Session["Sesja"] != null)
            {
                TempData["ID"] = id;
                ZebyModel model = new ZebyModel();

                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        [HttpPost]
        public ActionResult SaveBrakujace(string gl, string gp, string dl, string dp, string szczeka, string zuchwa, string id)
        {
            if (Session["Sesja"] != null)
            {
                var pacjent = client.GetPersonelByID(Convert.ToInt32(id));
                if (szczeka == "true")
                {
                    for (int i = 1; i <= 8; i++)
                    {
                        BrakZebow model = new BrakZebow()
                        {
                            Kategoria = "Stałe",
                            GD = "Górne",
                            LP = "Prawa",
                            PacjentID = pacjent.PersonelID,
                            Zab = i,
                        };
                        bool isOk = client.BrakZebowInsert(model);
                    }

                    for (int i = 1; i <= 8; i++)
                    {
                        BrakZebow model = new BrakZebow()
                        {
                            Kategoria = "Stałe",
                            GD = "Górne",
                            LP = "Lewa",
                            PacjentID = pacjent.PersonelID,
                            Zab = i,
                        };
                        bool isOk = client.BrakZebowInsert(model);
                    }
                }
                else if (zuchwa == "true")
                {
                    for (int i = 1; i <= 8; i++)
                    {
                        BrakZebow model = new BrakZebow()
                        {
                            Kategoria = "Stałe",
                            GD = "Dolne",
                            LP = "Prawa",
                            PacjentID = pacjent.PersonelID,
                            Zab = i,
                        };
                        bool isOk = client.BrakZebowInsert(model);
                    }

                    for (int i = 1; i <= 8; i++)
                    {
                        BrakZebow model = new BrakZebow()
                        {
                            Kategoria = "Stałe",
                            GD = "Dolne",
                            LP = "Lewa",
                            PacjentID = pacjent.PersonelID,
                            Zab = i,
                        };
                        bool isOk = client.BrakZebowInsert(model);
                    }
                }
                else if (gl != "")
                {

                    BrakZebow model = new BrakZebow()
                    {
                        Kategoria = "Stałe",
                        GD = "Górne",
                        LP = "Lewa",
                        PacjentID = pacjent.PersonelID,
                        Zab = Convert.ToInt32(gl),
                    };
                    bool isOk = client.BrakZebowInsert(model);
                }
                else if (gp != "")
                {
                    BrakZebow model = new BrakZebow()
                    {
                        Kategoria = "Stałe",
                        GD = "Górne",
                        LP = "Prawa",
                        PacjentID = pacjent.PersonelID,
                        Zab = Convert.ToInt32(gp),
                    };
                    bool isOk = client.BrakZebowInsert(model);
                }
                else if (dp != "")
                {
                    BrakZebow model = new BrakZebow()
                    {
                        Kategoria = "Stałe",
                        GD = "Dolne",
                        LP = "Prawa",
                        PacjentID = pacjent.PersonelID,
                        Zab = Convert.ToInt32(dp),
                    };
                    bool isOk = client.BrakZebowInsert(model);
                }
                else if (dl != "")
                {
                    BrakZebow model = new BrakZebow()
                    {
                        Kategoria = "Stałe",
                        GD = "Dolne",
                        LP = "Lewa",
                        PacjentID = pacjent.PersonelID,
                        Zab = Convert.ToInt32(dp),
                    };
                    bool isOk = client.BrakZebowInsert(model);
                }

                return PartialView();
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

    }
}