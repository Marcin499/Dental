using DAL;
using DAL.Model;
using Dental.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Dental.Controllers
{
    public class PacjentController : BazowyController
    {
        Metody bazaMetod = new Metody();


        public ActionResult WizytaNew(string imie)
        {
            try
            {
                CheckSession();
                TempData["imie"] = imie;
                ViewBag.Strona = "Dental - Wizyta";
                TempData.Keep();
                DodajWizyteModel model = new DodajWizyteModel();
                return View(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult Wizyta(string imie)
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Wizyta";
                TempData.Keep();
                TempData["imie"] = imie;
                DodajWizyteModel model = new DodajWizyteModel();
                return View(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult WizytaGabinet(string miasto)
        {
            try
            {
                CheckSession();
                DodajWizyteModel model = new DodajWizyteModel(miasto);

                return PartialView(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        [HttpPost]
        public ActionResult WizytaGabinet2(string miasto)
        {
            try
            {
                CheckSession();
                DodajWizyteModel model = new DodajWizyteModel(miasto);

                return PartialView(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult WizytaLekarz(string gabinetid)
        {
            try
            {
                CheckSession();
                LekarzeModel model = new LekarzeModel(gabinetid);

                return PartialView(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        [HttpPost]
        public ActionResult WizytaLekarz2(string gabinet)
        {
            try
            {
                CheckSession();
                LekarzeModel model = new LekarzeModel(gabinet);

                return PartialView(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult WizytaGodzina()
        {
            try
            {
                CheckSession();
                DodajWizyteModel model = new DodajWizyteModel();

                return PartialView(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        [HttpPost]
        public ActionResult WizytaGodzina2(string data, int lekarz, string placowkaID)
        {
            try
            {
                CheckSession();
                WizytaGodzinaModel model = new WizytaGodzinaModel(data, lekarz, placowkaID);

                return PartialView(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult ListaWizyt()
        {
            try
            {
                CheckSession();
                var id = Session["ID"];
                ViewBag.Strona = "Anuluj wizyte";
                TempData.Keep();
                var model = bazaMetod.GetWizytaByPacjentID(Convert.ToInt32(id));

                var lekarz = bazaMetod.GetPesonelList();
                var gabinet = bazaMetod.GetPlacowkaList();

                var wynik = from a in model.Where(x => x.Stan == "Zaplanowana")
                            join c in lekarz on a.LekarzID equals c.PersonelID
                            join d in gabinet on a.GabinetID equals d.PlacowkaID
                            select new AnulowanieWizytyModel()
                            {
                                WizytaID = a.WizytaID,
                                Data = a.Data,
                                Godzina = a.Godzina,
                                Gabinet = d.Nazwa,
                                ImieLekarza = c.Imie,
                                NazwiskoLekarza = c.Nazwisko,
                                Stan = a.Stan
                            };

                return View(wynik);
            }
            catch (Exception)
            {

                return PartialView("Error");
            }
        }

        public ActionResult AnulujWizyte(int wizytaID)
        {
            try
            {
                CheckSession();
                Wizyta wizyta = bazaMetod.GetWizytaByID(wizytaID);
                string stan = "Anulowana";
                Wizyta model = new Wizyta()
                {
                    WizytaID = wizyta.WizytaID,
                    PacjentID = wizyta.PacjentID,
                    LekarzID = wizyta.LekarzID,
                    GabinetID = wizyta.GabinetID,
                    Godzina = wizyta.Godzina,
                    Rodzaj = wizyta.Rodzaj,
                    Data = wizyta.Data,
                    Stan = stan,
                    Typ = wizyta.Typ,
                    Uwagi = wizyta.Uwagi,
                    DataUrodzenia = wizyta.DataUrodzenia
                };
                bool isOk = bazaMetod.WizytaUpdate(model);

                if (isOk == true)
                {
                    TempData["Zapisano"] = "Wizyta z godziny: " + wizyta.Godzina + " została anulowana!";
                    return RedirectToAction("Wizyta");
                }
                else
                {
                    return PartialView("Error");
                }
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        [HttpPost]
        public ActionResult SaveWizyta(string gabinet, string lekarz, string data, string godzina, string rodzajWizyty, string typWizyty, string stan, string uwagi)
        {
            try
            {
                CheckSession();
                var dane = bazaMetod.GetPacjentByID(Convert.ToInt32(Session["ID"]));
                Wizyta model = new Wizyta()
                {
                    PacjentID = Convert.ToInt32(Session["ID"]),
                    GabinetID = Convert.ToInt32(gabinet),
                    LekarzID = Convert.ToInt32(lekarz),
                    Data = data,
                    Godzina = godzina,
                    Rodzaj = rodzajWizyty,
                    Typ = typWizyty,
                    Stan = stan,
                    Uwagi = uwagi,
                    DataUrodzenia = dane.DataUrodzin,
                };

                bool isOk = bazaMetod.WizytaInsert(model);
                var sms = new SMSController();

                //sms.WyslijSMSPotwierdzenie(data, godzina, dane.Telefon);
                if (isOk == true)
                {
                    return RedirectToAction("WizytaNew");

                }
                else
                {
                    TempData["Zapisano"] = "Bląd! Spróbuj jeszcze raz.";
                    return RedirectToAction("Wizyta");
                }

            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult Historia()
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Historia";
                TempData.Keep();
                int id = Convert.ToInt32(Session["ID"]);
                var model = bazaMetod.GetWizytaByPacjentID(id);

                var lekarz = bazaMetod.GetPesonelList();
                var gabinet = bazaMetod.GetPlacowkaList();
                var rachunek = bazaMetod.GetRachunekList();
                var wynik = from a in model
                            join b in rachunek on a.RachunekID equals b.RachunekID
                            join c in lekarz on a.LekarzID equals c.PersonelID
                            join d in gabinet on a.GabinetID equals d.PlacowkaID
                            select new WizytaHistoriaPacjenta()
                            {
                                PacjentID = a.PacjentID,
                                Gabinet = d.Nazwa,
                                ImieLekarz = c.Imie,
                                NazwiskoLekarz = c.Nazwisko,
                                Data = a.Data,
                                Godzina = a.Godzina,
                                Kwota = b.KwotaDoZaplaty,
                                FormaPlatnosci = b.FormaPlatnosci

                            };
                return View(wynik);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult InfoHistoriaPacjenta(int PacjentID, string Data)
        {
            try
            {
                CheckSession();
                var wizyta = bazaMetod.GetWizytaByPacjentID(PacjentID);
                var leczenie = bazaMetod.GetLeczenieList();
                var lekarz = bazaMetod.GetPesonelList();

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

                var mod = model.Where(a => a.Data == Data).ToList();

                return View(mod);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult Cennik()
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Cennik";
                TempData.Keep();
                PlacowkiModel model = new PlacowkiModel();
                return View(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult ListaCennikDefault()
        {
            try
            {
                CheckSession();
                var cennik = bazaMetod.GetCennikList();

                return PartialView(cennik);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        [HttpPost]
        public ActionResult ListaCennik(string gabinet)
        {
            try
            {
                CheckSession();
                var cennik = bazaMetod.GetCennikByIDPlacowki(Convert.ToInt32(gabinet));

                return PartialView(cennik);
            }
            catch (Exception)
            {

                return PartialView("Error");
            }
        }

        public ActionResult Kontakt()
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Kontakt";
                TempData.Keep();

                KontaktModel model = new KontaktModel();
                return View(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }


        public ActionResult ListaGabinetowDefault()
        {
            try
            {
                CheckSession();
                var wynikAdres = bazaMetod.GetAdresPlacowkaList();
                var wynikMiasto = bazaMetod.GetPlacowkaList();

                var model = from c in wynikAdres
                            join a in wynikMiasto on c.AdresID equals a.PlacowkaID
                            select new ListaPlacowkiModel()
                            {
                                Nazwa = a.Nazwa,
                                Miasto = c.Miasto,
                                Ulica = c.Ulica,
                                Wojewodztwo = c.Wojewodztwo,
                                Numer = c.Numer,
                                GodzOd = a.GodzOd,
                                GodzDo = a.GodzDo,
                                Telefon = a.Telefon,
                                Email = a.Email
                            };

                return PartialView(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }
        [HttpPost]
        public ActionResult ListaGabinetow(string miasto)
        {
            try
            {
                CheckSession();
                var wynikAdres = bazaMetod.GetAdresPlacowkaByCity(miasto);
                var wynikMiasto = bazaMetod.GetPlacowkaList();

                var model = from c in wynikAdres
                            join a in wynikMiasto on c.AdresID equals a.PlacowkaID
                            select new ListaPlacowkiModel()
                            {
                                Nazwa = a.Nazwa,
                                Miasto = c.Miasto,
                                Ulica = c.Ulica,
                                Wojewodztwo = c.Wojewodztwo,
                                Numer = c.Numer,
                                GodzOd = a.GodzOd,
                                GodzDo = a.GodzDo,
                                Telefon = a.Telefon,
                                Email = a.Email
                            };

                return PartialView(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult Profil()
        {
            try
            {
                CheckSession();
                var id = Session["ID"];
                var wynikPacjentID = bazaMetod.GetPacjentByID(Convert.ToInt32(id));
                var wynikAdresID = bazaMetod.GetAdresByID(Convert.ToInt32(id));
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
                    Wojewodztwo = wynikAdresID.Wojewodztwo,
                    DataUrodzenia = wynikPacjentID.DataUrodzin.ToShortDateString(),
                };

                return View(editPacjentModel);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }


        public ActionResult UsunKonto(int dane)
        {
            try
            {
                CheckSession();
                bool isOk = bazaMetod.PacjentDelete(dane);

                return Json(isOk, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        [HttpPost]
        public ActionResult SaveEdit(EditPacjentModel model)
        {
            try
            {
                CheckSession();
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
                            Imie = model.Imie.ToUpper(),
                            Nazwisko = model.Nazwisko.ToUpper(),
                            Telefon = model.Telefon,
                            Email = model.Email.ToLower(),
                            Haslo = model.Haslo,
                            PESEL = model.PESEL,
                            PowtorzHaslo = model.PowtorzHaslo,
                            PacjentAdres = modelAdres,
                            DataUrodzin = Convert.ToDateTime(model.DataUrodzenia),

                        };

                        bool isOk = bazaMetod.PacjentUpdate(modelPacjent, modelAdres);
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
            catch (Exception)
            {
                return PartialView("Error");
            }
        }
    }
}