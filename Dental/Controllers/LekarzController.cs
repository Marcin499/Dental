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
                var wizyty = client.GetWizytaList().Where(a => a.Data == DateTime.Now.ToShortDateString() && a.LekarzID == (int)id && a.Stan != "Do rozliczenia" && a.Stan != "Zakończona");
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
                TempData["Wizyty"] = wizyty.Count();
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
                var wizyty = client.GetWizytaList().Where(a => a.Data == DateTime.Now.ToShortDateString() && a.LekarzID == (int)id && a.Stan == "Oczekuje w kolejce" || a.Stan == "W trakcie");
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

                if (pacjent == null)
                {
                    return View("Brak");
                }
                else
                {
                    var wiek = DateTime.Today.Year - pacjent.DataUrodzin.Year;
                    var wizyta = model.OrderByDescending(a => a.WizytaID).FirstOrDefault();
                    TempData["Ide"] = id;
                    TempData["Wiek"] = wiek;
                    TempData["Pacjent"] = pacjent.Imie + " " + pacjent.Nazwisko;
                    TempData["Wizyta"] = wizyta.WizytaID;
                    return View(modelWidok);
                }

            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult Leczenie(string pacjent, int wiek, int id, int wizyta)
        {
            if (Session["Sesja"] != null)
            {
                TempData["Wiek"] = wiek;
                TempData["Pacjent"] = pacjent;
                TempData["ID"] = id;
                TempData["Wizyta"] = wizyta;

                Wizyta wizyt = client.GetWizytaByID(wizyta);
                string stan = "W trakcie";
                Wizyta model = new Wizyta()
                {
                    WizytaID = wizyt.WizytaID,
                    PacjentID = wizyt.PacjentID,
                    LekarzID = wizyt.LekarzID,
                    GabinetID = wizyt.GabinetID,
                    Godzina = wizyt.Godzina,
                    Rodzaj = wizyt.Rodzaj,
                    Data = wizyt.Data,
                    Stan = stan,
                    Typ = wizyt.Typ,
                    Uwagi = wizyt.Uwagi,
                    DataUrodzenia = wizyt.DataUrodzenia
                };
                bool isOk = client.WizytaUpdate(model);

                TempData["PacjentID"] = model.PacjentID;
                return PartialView();
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

                RozpoznanieModel model = new RozpoznanieModel();


                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        [HttpPost]
        public ActionResult DodajRozpoznanie(string dane)
        {
            if (Session["Sesja"] != null)
            {
                Rozpoznanie model = new Rozpoznanie()
                {
                    Rozpoz = dane
                };

                bool isOk = client.RozpoznanieInsert(model);

                RozpoznanieModel list = new RozpoznanieModel();

                if (isOk == true)
                {
                    return PartialView(list);
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

        public ActionResult ZapisLeczenie(string zab1, string zab2, string zab3, string zab4, string dg, string lp, string rozp, string kat, string wizyta, string zabieg)
        {
            string[] proc = zabieg.Split(' ');

            if (proc.First() == "Higienizacja" || proc.First() == "Przegląd")
            {
                Leczenie model = new Leczenie()
                {
                    RodzajZebow = null,
                    GD = null,
                    LP = null,
                    Rozpoznanie = null,
                    Zab = 0,
                    WizytaID = Convert.ToInt32(wizyta),
                    Procedura = proc.First(),
                    Cena = Convert.ToInt32(proc.Last())
                };

                bool isOk = client.LeczenieInsert(model);
                TempData["Wizyta"] = wizyta;
                var lista = client.GetLeczenieByIDWizyta(Convert.ToInt32(wizyta));

                if (isOk == true)
                {
                    return PartialView("ListaLeczenia", lista);
                }
                else
                {
                    return View("Error");
                }
            }
            else
            {
                if (zab1 != "")
                {
                    string zab = zab1;

                    Leczenie model = new Leczenie()
                    {
                        RodzajZebow = kat,
                        GD = dg,
                        LP = lp,
                        Rozpoznanie = rozp,
                        Zab = Convert.ToInt32(zab),
                        WizytaID = Convert.ToInt32(wizyta),
                        Procedura = proc.First(),
                        Cena = Convert.ToInt32(proc.Last())
                    };

                    bool isOk = client.LeczenieInsert(model);
                    TempData["Wizyta"] = wizyta;
                    var lista = client.GetLeczenieByIDWizyta(Convert.ToInt32(wizyta));

                    if (isOk == true)
                    {
                        return PartialView("ListaLeczenia", lista);
                    }
                    else
                    {
                        return View("Error");
                    }
                }
                else if (zab2 != "")
                {
                    string zab = zab2;
                    Leczenie model = new Leczenie()
                    {
                        RodzajZebow = kat,
                        GD = dg,
                        LP = lp,
                        Rozpoznanie = rozp,
                        Zab = Convert.ToInt32(zab),
                        WizytaID = Convert.ToInt32(wizyta),
                        Procedura = proc.First(),
                        Cena = Convert.ToInt32(proc.Last())
                    };

                    bool isOk = client.LeczenieInsert(model);
                    TempData["Wizyta"] = wizyta;
                    var lista = client.GetLeczenieByIDWizyta(Convert.ToInt32(wizyta));

                    if (isOk == true)
                    {
                        return PartialView("ListaLeczenia", lista);
                    }
                    else
                    {
                        return View("Error");
                    }

                }
                else if (zab3 != "")
                {
                    string zab = zab3;
                    Leczenie model = new Leczenie()
                    {
                        RodzajZebow = kat,
                        GD = dg,
                        LP = lp,
                        Rozpoznanie = rozp,
                        Zab = Convert.ToInt32(zab),
                        WizytaID = Convert.ToInt32(wizyta),
                        Procedura = proc.First(),
                        Cena = Convert.ToInt32(proc.Last())
                    };

                    bool isOk = client.LeczenieInsert(model);
                    TempData["Wizyta"] = wizyta;
                    var lista = client.GetLeczenieByIDWizyta(Convert.ToInt32(wizyta));

                    if (isOk == true)
                    {
                        return PartialView("ListaLeczenia", lista);
                    }
                    else
                    {
                        return View("Error");
                    }
                }
                else if (zab4 != "")
                {
                    string zab = zab4;
                    Leczenie model = new Leczenie()
                    {
                        RodzajZebow = kat,
                        GD = dg,
                        LP = lp,
                        Rozpoznanie = rozp,
                        Zab = Convert.ToInt32(zab),
                        WizytaID = Convert.ToInt32(wizyta),
                        Procedura = proc.First(),
                        Cena = Convert.ToInt32(proc.Last())
                    };

                    bool isOk = client.LeczenieInsert(model);
                    TempData["Wizyta"] = wizyta;
                    var lista = client.GetLeczenieByIDWizyta(Convert.ToInt32(wizyta));

                    if (isOk == true)
                    {
                        return PartialView("ListaLeczenia", lista);
                    }
                    else
                    {
                        return View("Error");
                    }
                }
            }

            return View("Error");
        }

        public ActionResult Procedura()
        {
            if (Session["Sesja"] != null)
            {

                ZabiegiModel model = new ZabiegiModel();

                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult Cena(int wizyta)
        {
            var model = client.GetLeczenieByIDWizyta(wizyta);
            int suma = 0;

            foreach (var item in model)
            {
                suma += item.Cena;
            }

            TempData["Cena"] = suma;
            return PartialView();
        }

        public ActionResult ListaLeczenia(int wizyta)
        {
            if (Session["Sesja"] != null)
            {
                TempData["Wizyta"] = wizyta;
                var model = client.GetLeczenieByIDWizyta(wizyta);

                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult DeleteZab(int LeczenieID, int wizyta)
        {
            bool isOk = client.LeczenieDelete(LeczenieID);
            var lista = client.GetLeczenieByIDWizyta(wizyta);

            if (isOk == true)
            {
                return PartialView("ListaLeczenia", lista);
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Zeby(string kategoria, int id)
        {
            if (Session["Sesja"] != null)
            {
                TempData["ID"] = id;
                ZebyModel model = new ZebyModel(kategoria, id);

                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        [HttpPost]
        public ActionResult BrakujaceZeby()
        {
            if (Session["Sesja"] != null)
            {

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

        [HttpPost]
        public ActionResult ZamknijWizyte(int wizyta, string cena)
        {
            if (Session["Sesja"] != null)
            {
                string[] cenki = cena.Split(' ');
                Rachunek nowy = new Rachunek()
                {
                    Cena = Convert.ToInt32(cenki[5]),
                    KwotaDoZaplaty = 0
                };

                bool isOk = client.RachunekInsert(nowy);

                Wizyta wizyt = client.GetWizytaByID(wizyta);
                string stan = "Do rozliczenia";
                var ostatni = client.GetRachunekList().Last();
                Wizyta model = new Wizyta()
                {
                    WizytaID = wizyt.WizytaID,
                    PacjentID = wizyt.PacjentID,
                    LekarzID = wizyt.LekarzID,
                    GabinetID = wizyt.GabinetID,
                    Godzina = wizyt.Godzina,
                    Rodzaj = wizyt.Rodzaj,
                    Data = wizyt.Data,
                    Stan = stan,
                    Typ = wizyt.Typ,
                    Uwagi = wizyt.Uwagi,
                    DataUrodzenia = wizyt.DataUrodzenia,
                    RachunekID = ostatni.RachunekID

                };
                bool isOK = client.WizytaUpdate(model);

                return RedirectToAction("Wizyta", "Lekarz");
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult Historia(int pacjentID)
        {
            var wizyta = client.GetWizytaByPacjentID(pacjentID);
            var leczenie = client.GetLeczenieList();
            var lekarz = client.GetPesonelList();

            var model = from a in wizyta
                        join b in leczenie on a.WizytaID equals b.WizytaID
                        join c in lekarz on a.LekarzID equals c.PersonelID
                        select new HistoriaPacjentaModel()
                        {
                            WizytaID = a.WizytaID,
                            ImieL = c.Imie,
                            NazwiskoL = c.Nazwisko,
                            Data = a.Data,
                            RodzajZebow = b.RodzajZebow,
                            GD = b.GD,
                            LP = b.LP,
                            Zab = b.Zab,
                            Rozpoznanie = b.Rozpoznanie,
                            Procedura = b.Procedura,
                        };

            return View(model);
        }

        public ActionResult Pacjenci(int lekarzID)
        {
            var leczenie = client.GetWizytaByIDLekarz(lekarzID);

            var pacjenci = client.GetPacjentList();

            var model = from a in leczenie
                        join b in pacjenci on a.PacjentID equals b.PacjentID

                        select new PacjenciModel()
                        {
                            PacjentID = b.PacjentID,
                            Imie = b.Imie,
                            Nazwisko = b.Nazwisko,
                            DataUrodzenia = b.DataUrodzin.ToShortDateString(),
                            Telefon = b.Telefon
                        };

            var wynik = model.GroupBy(a => a.PacjentID).Select(a => a.First()).Distinct();

            return View(wynik);

        }
    }
}