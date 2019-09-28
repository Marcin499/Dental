using DAL;
using DAL.Model;
using Dental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Dental.Controllers
{
    public class AdminController : BaseController
    {
        Metody client = new Metody();

        public ActionResult ListaPlacowki()
        {
            CheckSession();
            List<Placowka> getPlacowki = client.GetPlacowkaList();
            var getAdres = client.GetAdresPlacowkaList();

            var model = from p in getPlacowki
                        join ad in getAdres on p.PlacowkaID equals ad.AdresID
                        select new ListaPlacowkiModel { PlacowkaID = p.PlacowkaID, Nazwa = p.Nazwa, Telefon = p.Telefon, Email = p.Email, GodzOd = p.GodzOd, GodzDo = p.GodzDo, Wojewodztwo = ad.Wojewodztwo, Miasto = ad.Miasto, Ulica = ad.Ulica, Numer = ad.Numer };

            return PartialView(model);
        }

        public ActionResult DodajPlacowke()
        {
            CheckSession();
            ViewBag.Strona = "Dental - Administracja";
            DodajPlacowkeModel model = new DodajPlacowkeModel();
            return View(model);

        }

        [HttpPost]
        public ActionResult SavePlacowka(DodajPlacowkeModel model)
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

                bool isOk = client.PlacowkaInsert(placowkaModel);
                if (isOk == true)
                {
                    TempData["Zapisano"] = "Gabinet został dodany!";
                    return RedirectToAction("Administracja");
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


        public ActionResult DeletePlacowka(int PlacowkaID)
        {
            CheckSession();
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

        public ActionResult EditPlacowka(int PlacowkaID)
        {
            CheckSession();
            ViewBag.Strona = "Dental - Administracja";
            var modelPlacowki = client.GetPlacowkaByID(PlacowkaID);
            var modelAdres = client.GetAdresPlacowkaByID(PlacowkaID);

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

        [HttpPost]
        public ActionResult SaveEditPlacowka(EditPlacowkiModel model)
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

                bool isOk = client.PlacowkaUpdate(modelPlacowka, modelAdrePlacowka);

                if (isOk == true)
                {
                    TempData["Zapisano"] = "Gabinet został zaktualizowany!";
                    return RedirectToAction("Administracja", "Admin");
                }
                else
                {
                    return View("Error");
                }
            }
            else
            {
                return View("EditPlacowka", model);
            }
        }

        public ActionResult Wizyta()
        {
            CheckSession();
            ViewBag.Strona = "Dental - Wizyty";

            return View();
        }

        public ActionResult ListaWizyt()
        {
            CheckSession();
            var wizyty = client.GetWizytaList().Where(a => a.Data == DateTime.Now.ToShortDateString());
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

            return PartialView(model.Where(a => a.Stan != "Zakończona" && a.Stan != "Anulowana").ToList());
        }


        public ActionResult UsunWizyte(int wizytaID)
        {
            CheckSession();
            Wizyta wizyta = client.GetWizytaByID(wizytaID);
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
            bool isOk = client.WizytaUpdate(model);

            if (isOk == true)
            {
                TempData["Zapisano"] = "Wizyta z godziny: " + wizyta.Godzina + " została anulowana!";
                return RedirectToAction("Wizyta");
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult PotwierdzWizyte(int wizytaID)
        {
            CheckSession();
            Wizyta wizyta = client.GetWizytaByID(wizytaID);
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
            bool isOk = client.WizytaUpdate(model);

            if (isOk == true)
            {
                TempData["Zapisano"] = "Wizyta  z godziny: " + wizyta.Godzina + " została potwierdzona!";
                return RedirectToAction("Wizyta");
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult RozliczWizyte(int wizytaID)
        {
            CheckSession();
            var wizyta = client.GetWizytaByID(wizytaID);

            var rachunek = client.GetRachunekByID(wizyta.RachunekID);

            TempData["Wizyta"] = wizytaID;

            return PartialView(rachunek);

        }

        public ActionResult KwotaDoZapłaty(int cena)
        {
            CheckSession();
            TempData["Kwota"] = cena;
            return PartialView();
        }

        public ActionResult Rabat(int rabat, decimal cena)
        {
            CheckSession();
            decimal obniżka = (cena / 100) * rabat;
            decimal kwotaPoObniżce = cena - obniżka;

            TempData["Kwota"] = kwotaPoObniżce;

            return PartialView();
        }

        public ActionResult NowaWizyta()
        {
            CheckSession();
            ViewBag.Strona = "Dental - Wizyta";
            NowaWizytaModel model = new NowaWizytaModel();

            return PartialView(model);
        }

        public ActionResult SzybkaWizyta()
        {
            CheckSession();
            ViewBag.Strona = "Dental - Wizyta";
            SzybkaWizytaModel model = new SzybkaWizytaModel();

            return PartialView(model);
        }

        public ActionResult ListaWyszukiwania(string imie, string nazwisko)
        {
            CheckSession();
            ViewBag.Strona = "Dental - Wizyta";
            if (imie != null && nazwisko != null)
            {
                var model = client.GetPacjentList().Where(a => a.Imie == imie || a.Nazwisko == nazwisko).ToList();
                var adres = client.GetAdresList();
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
                              DataUrodzenia = c.DataUrodzin
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

        public ActionResult NowaWizytaGabinet(string miasto)
        {
            CheckSession();
            ViewBag.Strona = "Dental - Wizyta";
            NowaWizytaModel model = new NowaWizytaModel(miasto);

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult NowaWizytaGabinet2(string miasto)
        {
            CheckSession();
            ViewBag.Strona = "Dental - Wizyta";
            NowaWizytaModel model = new NowaWizytaModel(miasto);

            return PartialView(model);
        }

        public ActionResult NowaWizytaLekarz(string gabinetid)
        {
            CheckSession();
            ViewBag.Strona = "Dental - Wizyta";
            LekarzeModel model = new LekarzeModel(gabinetid);

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult NowaWizytaLekarz2(string gabinetid)
        {
            CheckSession();
            ViewBag.Strona = "Dental - Wizyta";
            LekarzeModel model = new LekarzeModel(gabinetid);

            return PartialView(model);
        }

        public ActionResult NowaWizytaGodzina()
        {
            CheckSession();
            DodajWizyteModel model = new DodajWizyteModel();

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult NowaWizytaGodzina2(string data, int lekarz, string placowkaID)
        {
            CheckSession();
            WizytaGodzinaModel model = new WizytaGodzinaModel(data, lekarz, placowkaID);

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult NowaWizytaSave(string gabinet, string lekarz, string data, string godzina, string rodzajWizyty, string typWizyty, string stan, string uwagi, string imie, string nazwisko, string telefon)
        {
            ViewBag.Strona = "Dental - Wizyta";
            Adres adresModel = new Adres();
            Pacjent model = new Pacjent()
            {
                Imie = imie,
                Nazwisko = nazwisko,
                Telefon = Convert.ToInt32(telefon),
                PacjentAdres = adresModel
            };
            bool isOk = client.PacjentInsert(model);
            var wynik = client.GetPacjentList().Last();

            Wizyta wizytaModel = new Wizyta()
            {
                PacjentID = wynik.PacjentID,
                GabinetID = Convert.ToInt32(gabinet),
                LekarzID = Convert.ToInt32(lekarz),
                Data = data,
                Godzina = godzina,
                Rodzaj = rodzajWizyty,
                Stan = stan,
                Typ = typWizyty,
                Uwagi = "Uzupełnić dane!!!"
            };

            bool isOk2 = client.WizytaInsert(wizytaModel);


            if (isOk == true)
            {
                TempData["Zapisano"] = "Pacjent został dodany!";
                return RedirectToAction("Wizyta");
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult NowaWizytaSave2(string gabinet, string lekarz, string data, string godzina, string rodzajWizyty, string typWizyty, string stan, string uwagi, string imie, string nazwisko, string telefon, int pacjentID)
        {
            CheckSession();
            ViewBag.Strona = "Dental - Wizyta";
            var dataUrodzenia = client.GetPacjentByID(pacjentID);
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

            bool isOk = client.WizytaInsert(wizytaModel);


            if (isOk == true)
            {
                TempData["Zapisano"] = "Pacjent został dodany!";
                return RedirectToAction("Wizyta");
            }
            else
            {
                return View("Error");
            }
        }
        public ActionResult EditDetale(int pacjentID)
        {
            CheckSession();
            ViewBag.Strona = "Dental - Menu";

            var modelPacjent = client.GetPacjentByID(pacjentID);
            var adres = client.GetAdresByID(modelPacjent.PacjentID);

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

        public ActionResult WizytaHistoria(int historia)
        {
            CheckSession();
            ViewBag.Strona = "Dental - Wizyta";
            var model = client.GetWizytaByPacjentID(historia);
            var pacjent = client.GetPacjentList();
            var lekarz = client.GetPesonelList();
            var gabinet = client.GetPlacowkaList();
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
        public ActionResult ListaSzybkaWizyta(int pacjentID)
        {
            CheckSession();
            ViewBag.Strona = "Dental - Wizyta";
            SzybkaWizytaModel model = new SzybkaWizytaModel()
            {
                PacjentID = pacjentID
            };

            return PartialView(model);
        }

        public ActionResult DetaleWizyta(int wizytaID)
        {
            CheckSession();
            ViewBag.Strona = "Dental - Menu";
            var wizyta = client.GetWizytaByID(wizytaID);
            var pacjent = wizyta.PacjentID;
            var modelPacjent = client.GetPacjentByID(pacjent);
            var adres = client.GetAdresByID(modelPacjent.PacjentID);

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

        [HttpPost]
        public ActionResult DetaleEditSave(EditPacjentModel model)
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

            bool isOk = client.PacjentUpdate(modelPacjent);
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
        public ActionResult Personel()
        {
            CheckSession();
            ViewBag.Strona = "Dental - Pesonel";


            return View();
        }

        public ActionResult ListaPersonel()
        {
            CheckSession();
            ViewBag.Strona = "Dental - Pesonel";
            var getPesonel = client.GetPesonelList();
            var getAdres = client.GetAdresPersonelList();
            var model = from p in getPesonel
                        join ad in getAdres on p.PersonelID equals ad.AdresID
                        select new ListaPersonelModel
                        {
                            PersonelID = p.PersonelID,
                            Imie = p.Imie,
                            Nazwisko = p.Nazwisko,
                            Placowka = p.Placowka,
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

        public ActionResult DodajPersonel()
        {
            CheckSession();
            ViewBag.Strona = "Dental - Personel";
            DodajPersonelModel model = new DodajPersonelModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult SavePersonel(DodajPersonelModel model)
        {
            CheckSession();
            var emailWynik = client.GetPesonelList().Where(a => a.Email == model.Email);


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

                bool isOk = client.PersonelInsert(personelModel);
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

        public ActionResult DeletePersonel(int PersonelID)
        {
            CheckSession();
            bool isOk = client.PersonelDelete(PersonelID);

            if (isOk == true)
            {
                TempData["Zapisano"] = "Pracownik został usunięty!";
                return RedirectToAction("Personel", "Admin");
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult EditPersonel(int PersonelID)
        {
            CheckSession();
            ViewBag.Strona = "Dental - Personel";
            var modelPersonel = client.GetPersonelByID(PersonelID);
            var modelAdres = client.GetAdresPersonelByID(PersonelID);

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

        [HttpPost]
        public ActionResult SaveEditPersonel(EditPersonelModel model)
        {
            CheckSession();
            if (ModelState.IsValid)
            {
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

                bool isOk = client.PersonelUpdate(modelPersonel, modelAdresPersonel);

                if (isOk == true)
                {
                    TempData["Zapisano"] = "Gabinet został zaktualizowany!";
                    return RedirectToAction("Personel", "Admin");
                }
                else
                {
                    return View("Error");
                }
            }
            else
            {
                return View("EditPlacowka", model);
            }
        }
        public ActionResult Cennik()
        {
            CheckSession();
            ViewBag.Strona = "Dental - Cennik";

            return View();
        }

        public ActionResult ListaZabiegów()
        {
            CheckSession();
            ViewBag.Strona = "Dental - Cennik";
            var model = client.GetCennikList();
            return PartialView(model);
        }

        public ActionResult DodajZabieg()
        {
            CheckSession();
            ViewBag.Strona = "Dental - Cennik";
            DodajZabiegModel model = new DodajZabiegModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveZabieg(DodajZabiegModel model)
        {
            CheckSession();
            if (ModelState.IsValid)
            {
                Cennik cennikModel = new Cennik()
                {
                    Zabieg = model.Zabieg,
                    Kategoria = model.Kategoria,
                    Cena = model.Cena,
                };



                bool isOk = client.CennikInsert(cennikModel);
                if (isOk == true)
                {
                    TempData["Zapisano"] = "Zabieg został dodany!";
                    return RedirectToAction("Cennik", "Admin");
                }
                else
                {
                    return View("Error");
                }
            }
            else
            {
                return View("DodajPersonel", model);
            }
        }


        public ActionResult SaveRachunek(int id, decimal cena, string forma, int rabat, string kwota, int wizyta)
        {
            CheckSession();
            string[] kwot = kwota.Split(' ');
            Rachunek model = new Rachunek()
            {
                RachunekID = id,
                Cena = cena,
                Rabat = rabat,
                Faktura = false,
                FormaPlatnosci = forma,
                KwotaDoZaplaty = Convert.ToDecimal(kwot[5])
            };

            bool isOk = client.RachunekUpdate(model);

            Wizyta wizyt = client.GetWizytaByID(wizyta);
            string stan = "Zakończona";
            var ostatni = client.GetRachunekList().Last();
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
            bool isOK = client.WizytaUpdate(model2);
            if (isOk == true)
            {
                TempData["Zapisano"] = "Wizyta z godziny: " + model2.Godzina + " została zamknięta!";
                return RedirectToAction("Wizyta", "Admin");
            }
            else
            {
                return View("Error");
            }

        }

        public ActionResult DeleteZabieg(int ZabiegID)
        {
            CheckSession();
            bool isOk = client.CennikDelete(ZabiegID);

            if (isOk == true)
            {
                TempData["Zapisano"] = "Zabieg został usunięty!";
                return RedirectToAction("Cennik", "Admin");
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult EditZabieg(int ZabiegID)
        {
            CheckSession();
            ViewBag.Strona = "Dental - Cennik";
            var modelZabieg = client.GetCennikByID(ZabiegID);


            EditZabiegModel model = new EditZabiegModel(modelZabieg.Kategoria)
            {
                Zabieg = modelZabieg.Zabieg,
                Kategoria = modelZabieg.Kategoria,
                Cena = modelZabieg.Cena,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveEditZabieg(EditZabiegModel model)
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

                bool isOk = client.CennikUpdate(modelCennik);

                if (isOk == true)
                {
                    TempData["Zapisano"] = "Zabieg został zaktualizowany!";
                    return RedirectToAction("Cennik", "Admin");
                }
                else
                {
                    return View("Error");
                }
            }
            else
            {
                return View("EditPlacowka", model);
            }
        }

        public ActionResult Administracja()
        {
            CheckSession();
            ViewBag.Strona = "Dental - Administracja";

            return View();
        }
    }
}