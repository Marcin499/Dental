using DAL;
using DAL.Model;
using Dental.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace Dental.Controllers
{
    public class AdminController : BazowyController
    {
        Metody Miasto = new Metody();

        public ActionResult ListaPlacowki()
        {
            try
            {
                CheckSession();
                List<Placowka> getPlacowki = Miasto.GetPlacowkaList();
                var getAdres = Miasto.GetAdresPlacowkaList();

                var model = from p in getPlacowki
                            join ad in getAdres on p.PlacowkaID equals ad.AdresID
                            select new ListaPlacowkiModel { PlacowkaID = p.PlacowkaID, Nazwa = p.Nazwa, Telefon = p.Telefon, Email = p.Email, GodzOd = p.GodzOd, GodzDo = p.GodzDo, Wojewodztwo = ad.Wojewodztwo, Miasto = ad.Miasto, Ulica = ad.Ulica, Numer = ad.Numer };

                return PartialView(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult DodajPlacowke()
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Administracja";
                DodajPlacowkeModel model = new DodajPlacowkeModel();
                return View(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        [HttpPost]
        public ActionResult ZapiszPlacowka(DodajPlacowkeModel model)
        {
            try
            {
                CheckSession();
                if (ModelState.IsValid)
                {
                    CheckSession();
                    AdresPlacowka adresModel = new AdresPlacowka()
                    {
                        Wojewodztwo = model.Wojewodztwo,
                        Miasto = model.Miasto,
                        Ulica = model.Ulica,
                        Numer = model.Numer
                    };

                    Placowka placowkaModel = new Placowka()
                    {
                        Nazwa = model.Nazwa,
                        Telefon = model.Telefon,
                        Email = model.Email,
                        GodzOd = model.GodzOd,
                        GodzDo = model.GodzDo,
                        PlacowkaAdresPlacowka = adresModel

                    };

                    bool isOk = Miasto.PlacowkaInsert(placowkaModel);
                    if (isOk == true)
                    {
                        TempData["Zapisano"] = "Gabinet został dodany!";
                        return RedirectToAction("Administracja");
                    }
                    else
                    {
                        return PartialView("Error");
                    }
                }
                else
                {
                    return View("DodajPlacowke", model);
                }
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }


        public ActionResult DeletePlacowka(int PlacowkaID)
        {
            try
            {
                CheckSession();
                bool isOk = Miasto.PlacowkaDelete(PlacowkaID);

                if (isOk == true)
                {
                    TempData["Zapisano"] = "Gabinet został usunięty!";
                    return RedirectToAction("Administracja", "Admin");
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

        public ActionResult EditPlacowka(int PlacowkaID)
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Administracja";
                var modelPlacowki = Miasto.GetPlacowkaByID(PlacowkaID);
                var modelAdres = Miasto.GetAdresPlacowkaByID(PlacowkaID);

                EditPlacowkiModel model = new EditPlacowkiModel(modelAdres.Wojewodztwo, modelPlacowki.GodzOd, modelPlacowki.GodzDo)
                {
                    PlacowkaID = modelPlacowki.PlacowkaID,
                    Nazwa = modelPlacowki.Nazwa,
                    Telefon = modelPlacowki.Telefon,
                    Email = modelPlacowki.Email,
                    Wojewodztwo = modelAdres.Wojewodztwo,
                    Miasto = modelAdres.Miasto,
                    Ulica = modelAdres.Ulica,
                    Numer = modelAdres.Numer
                };
                return View(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        [HttpPost]
        public ActionResult SaveEditPlacowka(EditPlacowkiModel model)
        {
            try
            {
                CheckSession();
                if (ModelState.IsValid)
                {
                    AdresPlacowka modelAdrePlacowka = new AdresPlacowka()
                    {
                        Wojewodztwo = model.Wojewodztwo,
                        Miasto = model.Miasto,
                        Ulica = model.Ulica,
                        Numer = model.Numer
                    };

                    Placowka modelPlacowka = new Placowka()
                    {
                        PlacowkaID = model.PlacowkaID,
                        Nazwa = model.Nazwa,
                        Telefon = model.Telefon,
                        Email = model.Email,
                        GodzDo = model.GodzDo,
                        GodzOd = model.GodzOd

                    };

                    bool isOk = Miasto.PlacowkaUpdate(modelPlacowka, modelAdrePlacowka);

                    if (isOk == true)
                    {
                        TempData["Zapisano"] = "Gabinet został zaktualizowany!";
                        return RedirectToAction("Administracja", "Admin");
                    }
                    else
                    {
                        return PartialView("Error");
                    }
                }
                else
                {
                    return View("EditPlacowka", model);
                }
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult Wizyta()
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Wizyty";
                var dane = Miasto.GetWizytaList().Where(a => a.Data == DateTime.Now.AddDays(1).ToString("dd.MM.yyyy"));
                var init = new SMSController();
                foreach (var item in dane)
                {
                    if (item.Stan != "Wysłano przypomnienie")
                    {
                        //init.WyslijSMSPrzypomnienie(item);
                        Wizyta model = new Wizyta()
                        {
                            Data = item.Data,
                            DataUrodzenia = item.DataUrodzenia,
                            GabinetID = item.GabinetID,
                            Godzina = item.Godzina,
                            LekarzID = item.LekarzID,
                            PacjentID = item.PacjentID,
                            RachunekID = item.RachunekID,
                            Rodzaj = item.Rodzaj,
                            Typ = item.Typ,
                            Uwagi = item.Uwagi,
                            WizytaID = item.WizytaID,
                            Stan = "Wysłano przypomnienie"
                        };

                        bool isOk = Miasto.WizytaUpdate(model);
                    }
                }

                return View();
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
                var wizyty = Miasto.GetWizytaList().Where(a => a.Data == DateTime.Now.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture));
                var pacjenci = Miasto.GetPacjentList();
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

                return PartialView(model.Where(a => a.Stan != "Zakończona" && a.Stan != "Anulowana").ToList());
            }
            catch (Exception)
            {
                return PartialView("Error");
            }

        }


        public ActionResult UsunWizyte(int wizytaID)
        {
            try
            {
                CheckSession();
                Wizyta wizyta = Miasto.GetWizytaByID(wizytaID);
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
                bool isOk = Miasto.WizytaUpdate(model);

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

        public ActionResult PotwierdzWizyte(int wizytaID)
        {
            try
            {
                CheckSession();
                Wizyta wizyta = Miasto.GetWizytaByID(wizytaID);
                string stan = "Oczekuje w kolejce";
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
                bool isOk = Miasto.WizytaUpdate(model);

                if (isOk == true)
                {
                    TempData["Zapisano"] = "Wizyta  z godziny: " + wizyta.Godzina + " została potwierdzona!";
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

        public ActionResult RozliczWizyte(int wizytaID)
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Rozliczenie wizyty";
                var wizyta = Miasto.GetWizytaByID(wizytaID);

                var rachunek = Miasto.GetRachunekByID(wizyta.RachunekID);

                TempData["Wizyta"] = wizytaID;

                return PartialView(rachunek);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult KwotaDoZapłaty(int cena)
        {
            try
            {
                CheckSession();
                TempData["Kwota"] = cena;
                return PartialView();
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult Rabat(int rabat, decimal cena)
        {
            try
            {
                CheckSession();
                decimal obniżka = (cena / 100) * rabat;
                decimal kwotaPoObniżce = cena - obniżka;

                TempData["Kwota"] = kwotaPoObniżce;

                return PartialView();
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult NowaWizyta()
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Wizyta";
                NowaWizytaModel model = new NowaWizytaModel();

                return PartialView(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult SzybkaWizyta()
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Wizyta";
                SzybkaWizytaModel model = new SzybkaWizytaModel();

                return PartialView(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult ListaWyszukiwania(string imie, string nazwisko)
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Wizyta";
                if (imie != null && nazwisko != null)
                {
                    var model = Miasto.GetPacjentList().Where(a => a.Imie == imie || a.Nazwisko == nazwisko).ToList();
                    var adres = Miasto.GetAdresList();
                    var mod = from c in model
                              join a in adres on c.PacjentID equals a.AdresID
                              select new EditPacjentModel()
                              {
                                  PacjentID = c.PacjentID,
                                  Imie = c.Imie,
                                  Nazwisko = c.Nazwisko,
                                  Telefon = c.Telefon,
                                  Email = c.Email,
                                  PESEL = c.PESEL,
                                  Wojewodztwo = a.Wojewodztwo,
                                  Miasto = a.Miasto,
                                  Ulica = a.Ulica,
                                  Numer = a.Numer,
                                  Kod = a.Kod,
                                  DataUrodzenia = c.DataUrodzin.ToString()
                              };
                    var wynik = mod.ToList();


                    return PartialView(wynik);
                }
                else
                {
                    List<EditPacjentModel> lista = new List<EditPacjentModel>();

                    return PartialView(lista);
                }
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult NowaWizytaGabinet(string miasto)
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Wizyta";
                NowaWizytaModel model = new NowaWizytaModel(miasto);

                return PartialView(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        [HttpPost]
        public ActionResult NowaWizytaGabinet2(string miasto)
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Wizyta";
                NowaWizytaModel model = new NowaWizytaModel(miasto);

                return PartialView(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult NowaWizytaLekarz(string gabinetid)
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Wizyta";
                LekarzeModel model = new LekarzeModel(gabinetid);

                return PartialView(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        [HttpPost]
        public ActionResult NowaWizytaLekarz2(string gabinetid)
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Wizyta";
                LekarzeModel model = new LekarzeModel(gabinetid);

                return PartialView(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult NowaWizytaGodzina()
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
        public ActionResult NowaWizytaGodzina2(string data, int lekarz, string placowkaID)
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

        [HttpPost]
        public ActionResult NowaWizytaSave(string gabinet, string lekarz, string data, string godzina, string rodzajWizyty, string typWizyty, string stan, string uwagi, string imie, string nazwisko, string telefon)
        {
            try
            {
                ViewBag.Strona = "Dental - Wizyta";
                Adres adresModel = new Adres();
                Pacjent model = new Pacjent()
                {
                    Imie = imie.ToUpper(),
                    Nazwisko = nazwisko.ToUpper(),
                    Telefon = Convert.ToInt32(telefon),
                    PacjentAdres = adresModel,
                    DataUrodzin = Convert.ToDateTime("01.01.1900"),
                    Haslo = null,
                    PowtorzHaslo = null,
                    PESEL = null,
                    Typ = null

                };
                bool isOk = Miasto.PacjentInsert(model);
                var wynik = Miasto.GetPacjentList().Last();

                Wizyta wizytaModel = new Wizyta()
                {
                    PacjentID = wynik.PacjentID,
                    GabinetID = Convert.ToInt32(gabinet),
                    LekarzID = Convert.ToInt32(lekarz),
                    Data = data,
                    DataUrodzenia = Convert.ToDateTime("01.01.1900"),
                    Godzina = godzina,
                    Rodzaj = rodzajWizyty,
                    Stan = stan,
                    Typ = typWizyty,
                    Uwagi = "Uzupełnić dane!!!"
                };

                bool isOk2 = Miasto.WizytaInsert(wizytaModel);


                if (isOk == true)
                {
                    TempData["Zapisano"] = "Pacjent został dodany!";
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
        public ActionResult NowaWizytaSave2(string gabinet, string lekarz, string data, string godzina, string rodzajWizyty, string typWizyty, string stan, string uwagi, string imie, string nazwisko, string telefon, int pacjentID)
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Wizyta";
                var dataUrodzenia = Miasto.GetPacjentByID(pacjentID);
                Wizyta wizytaModel = new Wizyta()
                {
                    PacjentID = pacjentID,
                    GabinetID = Convert.ToInt32(gabinet),
                    LekarzID = Convert.ToInt32(lekarz),
                    Data = data,
                    Godzina = godzina,
                    Rodzaj = rodzajWizyty,
                    Stan = stan,
                    Typ = typWizyty,
                    DataUrodzenia = dataUrodzenia.DataUrodzin

                };

                bool isOk = Miasto.WizytaInsert(wizytaModel);


                if (isOk == true)
                {
                    TempData["Zapisano"] = "Pacjent został dodany!";
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
        public ActionResult EditDetale(int pacjentID)
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Menu";

                var modelPacjent = Miasto.GetPacjentByID(pacjentID);
                var adres = Miasto.GetAdresByID(modelPacjent.PacjentID);

                EditPacjentModel model = new EditPacjentModel()
                {
                    PacjentID = modelPacjent.PacjentID,
                    Imie = modelPacjent.Imie,
                    Nazwisko = modelPacjent.Nazwisko,
                    Telefon = modelPacjent.Telefon,
                    Email = modelPacjent.Email,
                    Miasto = adres.Miasto,
                    Wojewodztwo = adres.Wojewodztwo,
                    Ulica = adres.Ulica,
                    Numer = adres.Numer,
                    PESEL = modelPacjent.PESEL,
                    Kod = adres.Kod,

                };
                return View(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult WizytaHistoria(int historia)
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Wizyta";
                var model = Miasto.GetWizytaByPacjentID(historia);
                var pacjent = Miasto.GetPacjentList();
                var lekarz = Miasto.GetPesonelList();
                var gabinet = Miasto.GetPlacowkaList();
                var wynik = from a in model
                            join c in lekarz on a.LekarzID equals c.PersonelID
                            join d in gabinet on a.GabinetID equals d.PlacowkaID
                            select new WizytaHistoria()
                            {
                                Gabinet = d.Nazwa,
                                ImieLekarz = c.Imie,
                                NazwiskoLekarz = c.Nazwisko,
                                Data = a.Data,
                                Godzina = a.Godzina,
                                Stan = a.Stan

                            };

                return PartialView(wynik);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }
        public ActionResult ListaSzybkaWizyta(int pacjentID)
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Wizyta";
                SzybkaWizytaModel model = new SzybkaWizytaModel()
                {
                    PacjentID = pacjentID
                };

                return PartialView(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult DetaleWizyta(int wizytaID)
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Menu";
                var wizyta = Miasto.GetWizytaByID(wizytaID);
                var pacjent = wizyta.PacjentID;
                var modelPacjent = Miasto.GetPacjentByID(pacjent);
                var adres = Miasto.GetAdresByID(modelPacjent.PacjentID);

                EditPacjentModel model = new EditPacjentModel()
                {
                    PacjentID = modelPacjent.PacjentID,
                    Imie = modelPacjent.Imie,
                    Nazwisko = modelPacjent.Nazwisko,
                    Telefon = modelPacjent.Telefon,
                    Email = modelPacjent.Email,
                    Miasto = adres.Miasto,
                    Wojewodztwo = adres.Wojewodztwo,
                    Ulica = adres.Ulica,
                    Numer = adres.Numer,
                    PESEL = modelPacjent.PESEL,
                    Kod = adres.Kod,

                };
                TempData["Dane"] = model.PacjentID;
                List<EditPacjentModel> lista = new List<EditPacjentModel>();
                lista.Add(model);
                return View(lista);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        [HttpPost]
        public ActionResult DetaleEditSave(EditPacjentModel model)
        {
            try
            {
                CheckSession();
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
                    PESEL = model.PESEL,
                    PacjentAdres = modelAdres
                };

                bool isOk = Miasto.PacjentUpdateAdmin(modelPacjent, modelAdres);
                if (isOk == true)
                {
                    TempData["Zapisano"] = "Dane zostały zaktualizowane!";
                    return RedirectToAction("Wizyta");
                }
                else
                {
                    TempData["Zapisano"] = "Błąd! Spróbuj ponownie!";
                    return RedirectToAction("Wizyta");
                }
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }
        public ActionResult Personel()
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Personel";


                return View();
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult ListaPersonel()
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Pesonel";
                var getPesonel = Miasto.GetPesonelList();
                var getAdres = Miasto.GetAdresPersonelList();
                var getPlacowka = Miasto.GetPlacowkaList();
                var model = from p in getPesonel
                            join ad in getAdres on p.PersonelID equals ad.AdresID
                            join b in getPlacowka on p.Placowka equals b.PlacowkaID
                            select new ListaPersonelModel
                            {
                                PersonelID = p.PersonelID,
                                Imie = p.Imie,
                                Nazwisko = p.Nazwisko,
                                Placowka = b.Nazwa,
                                Telefon = p.Telefon,
                                Email = p.Email,
                                Haslo = p.Haslo,
                                Typ = p.Typ,
                                Specjalizacja = p.Specjalizacja,
                                Wojewodztwo = ad.Wojewodztwo,
                                Miasto = ad.Miasto,
                                Ulica = ad.Ulica,
                                Numer = ad.Numer,
                                Kod = ad.Kod
                            };

                return PartialView(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult DodajPersonel()
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Personel";
                DodajPersonelModel model = new DodajPersonelModel();
                return View(model);

            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        [HttpPost]
        public ActionResult ZapiszPersonel(DodajPersonelModel model)
        {
            try
            {
                CheckSession();
                var emailWynik = Miasto.GetPesonelList().Where(a => a.Email == model.Email);


                if (ModelState.IsValid && emailWynik.Count() == 0 || emailWynik == null)
                {
                    AdresPersonel adresModel = new AdresPersonel()
                    {
                        Wojewodztwo = model.Wojewodztwo.ToString(),
                        Miasto = model.Miasto,
                        Ulica = model.Ulica,
                        Numer = model.Numer,
                        Kod = model.Kod
                    };

                    Personel personelModel = new Personel()
                    {
                        Imie = model.Imie,
                        Nazwisko = model.Nazwisko,
                        Placowka = model.Placowka,
                        Typ = model.Typ.ToString(),
                        Specjalizacja = model.Specjalizacja.ToString(),
                        Telefon = model.Telefon,
                        Email = model.Email,
                        Haslo = model.Haslo,
                        PowtorzHaslo = model.PowtorzHaslo,
                        PersonelAdres = adresModel
                    };

                    bool isOk = Miasto.PersonelInsert(personelModel);
                    if (isOk == true)
                    {
                        TempData["Zapisano"] = "Pracownik został dodany!";
                        return RedirectToAction("Personel", "Admin");
                    }
                    else
                    {
                        return View("Error");
                    }
                }
                else
                {
                    TempData["Zapisano"] = "Adres email jest juz używany!";
                    return View("DodajPersonel", model);
                }
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult DeletePersonel(int PersonelID)
        {
            try
            {
                CheckSession();
                bool isOk = Miasto.PersonelDelete(PersonelID);

                if (isOk == true)
                {
                    TempData["Zapisano"] = "Pracownik został usunięty!";
                    return RedirectToAction("Personel", "Admin");
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

        public ActionResult EditPersonel(int PersonelID)
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Personel";
                var modelPersonel = Miasto.GetPersonelByID(PersonelID);
                var modelAdres = Miasto.GetAdresPersonelByID(PersonelID);

                EditPersonelModel model = new EditPersonelModel(modelPersonel.Placowka.ToString(), modelAdres.Wojewodztwo, modelPersonel.Typ, modelPersonel.Specjalizacja)
                {
                    PersonelID = modelPersonel.PersonelID,
                    Imie = modelPersonel.Imie,
                    Nazwisko = modelPersonel.Nazwisko,
                    Typ = modelPersonel.Typ,
                    Specjalizacja = modelPersonel.Specjalizacja,
                    Telefon = modelPersonel.Telefon,
                    Email = modelPersonel.Email,
                    Haslo = modelPersonel.Haslo,
                    PowtorzHaslo = modelPersonel.PowtorzHaslo,
                    Wojewodztwo = modelAdres.Wojewodztwo,
                    Miasto = modelAdres.Miasto,
                    Ulica = modelAdres.Ulica,
                    Numer = modelAdres.Numer,
                    Kod = modelAdres.Kod
                };
                return View(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        [HttpPost]
        public ActionResult SaveEditPersonel(EditPersonelModel model)
        {
            try
            {
                CheckSession();

                AdresPersonel modelAdresPersonel = new AdresPersonel()
                {
                    AdresID = model.PersonelID,
                    Wojewodztwo = model.Wojewodztwo.ToString(),
                    Miasto = model.Miasto,
                    Ulica = model.Ulica,
                    Numer = model.Numer,
                    Kod = model.Kod,
                };

                Personel modelPersonel = new Personel()
                {
                    PersonelID = model.PersonelID,
                    Imie = model.Imie,
                    Nazwisko = model.Nazwisko,
                    Placowka = model.Placowka,
                    Telefon = model.Telefon,
                    Email = model.Email,
                    Typ = model.Typ,
                    Specjalizacja = model.Specjalizacja,
                    Haslo = model.Haslo,
                    PowtorzHaslo = model.PowtorzHaslo,

                };

                bool isOk = Miasto.PersonelUpdate(modelPersonel, modelAdresPersonel);

                if (isOk == true)
                {
                    TempData["Zapisano"] = "Gabinet został zaktualizowany!";
                    return RedirectToAction("Personel", "Admin");
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
        public ActionResult Cennik()
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Cennik";
                PlacowkiModel model = new PlacowkiModel();

                return View(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }
                
        public ActionResult ListaZabiegowDefault()
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Cennik";
                var cennik = Miasto.GetCennikList();
                return PartialView(cennik);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        [HttpPost]
        public ActionResult ListaZabiegow(string gabinet)
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Cennik";
                var cennik = Miasto.GetCennikByIDPlacowki(Convert.ToInt32(gabinet));
                return PartialView(cennik);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult DodajZabieg()
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Cennik";
                DodajZabiegModel model = new DodajZabiegModel();
                return View(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        [HttpPost]
        public ActionResult SaveZabieg(DodajZabiegModel model)
        {
            try
            {
                CheckSession();
                if (ModelState.IsValid)
                {
                    Cennik cennikModel = new Cennik()
                    {
                        Zabieg = model.Zabieg,
                        PlacowkaID = Convert.ToInt32(model.Placowki),
                        Kategoria = model.Kategoria,
                        Cena = model.Cena,
                    };



                    bool isOk = Miasto.CennikInsert(cennikModel);
                    if (isOk == true)
                    {
                        TempData["Zapisano"] = "Zabieg został dodany!";
                        return RedirectToAction("Cennik", "Admin");
                    }
                    else
                    {
                        return PartialView("Error");
                    }
                }
                else
                {
                    return View("DodajPersonel", model);
                }
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }


        public ActionResult SaveRachunek(int id, decimal cena, string forma, string rabat, string kwota, int wizyta)
        {
            try
            {
                CheckSession();
                string[] kwot = kwota.Split(' ');
                if (rabat == "")
                {
                    rabat = "0";
                }
                Rachunek model = new Rachunek()
                {
                    RachunekID = id,
                    Cena = cena,
                    Rabat = Convert.ToInt32(rabat),
                    Faktura = false,
                    FormaPlatnosci = forma,
                    KwotaDoZaplaty = Convert.ToDecimal(kwot[5])
                };

                bool isOk = Miasto.RachunekUpdate(model);

                Wizyta wizyt = Miasto.GetWizytaByID(wizyta);
                string stan = "Zakończona";
                var ostatni = Miasto.GetRachunekList().Last();
                Wizyta model2 = new Wizyta()
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
                    RachunekID = ostatni.RachunekID,

                };
                bool isOK = Miasto.WizytaUpdate(model2);
                if (isOk == true)
                {
                    TempData["Zapisano"] = "Wizyta z godziny: " + model2.Godzina + " została zamknięta!";
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

        public ActionResult DeleteZabieg(int ZabiegID)
        {
            try
            {
                CheckSession();
                bool isOk = Miasto.CennikDelete(ZabiegID);

                if (isOk == true)
                {
                    TempData["Zapisano"] = "Zabieg został usunięty!";
                    return RedirectToAction("Cennik", "Admin");
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

        public ActionResult EditZabieg(int ZabiegID)
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Cennik";
                var modelZabieg = Miasto.GetCennikByID(ZabiegID);


                EditZabiegModel model = new EditZabiegModel(modelZabieg.Kategoria)
                {
                    Zabieg = modelZabieg.Zabieg,
                    Kategoria = modelZabieg.Kategoria,
                    Cena = modelZabieg.Cena,
                };
                return View(model);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        [HttpPost]
        public ActionResult SaveEditZabieg(EditZabiegModel model)
        {
            try
            {
                CheckSession();
                if (ModelState.IsValid)
                {
                    Cennik modelCennik = new Cennik()
                    {
                        ZabiegID = model.ZabiegID,
                        Zabieg = model.Zabieg,
                        Kategoria = model.Kategoria,
                        Cena = model.Cena
                    };

                    bool isOk = Miasto.CennikUpdate(modelCennik);

                    if (isOk == true)
                    {
                        TempData["Zapisano"] = "Zabieg został zaktualizowany!";
                        return RedirectToAction("Cennik", "Admin");
                    }
                    else
                    {
                        return PartialView("Error");
                    }
                }
                else
                {
                    return View("EditPlacowka", model);
                }
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }

        public ActionResult Administracja()
        {
            try
            {
                CheckSession();
                ViewBag.Strona = "Dental - Administracja";

                return View();
            }
            catch (Exception)
            {
                return PartialView("Error");
            }
        }
    }
}