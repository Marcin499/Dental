using DAL;
using DAL.Model;
using Dental.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Dental.Controllers
{
    public class PacjentController : BaseController
    {
        Metody client = new Metody();

        public ActionResult Wizyta(string imie)
        {
            CheckSession();
            TempData["imie"] = imie;
            ViewBag.Strona = "Dental - Wizyta";
            TempData.Keep();
            DodajWizyteModel model = new DodajWizyteModel();
            return View(model);

        }

        public ActionResult WizytaGabinet(string miasto)
        {
            CheckSession();
            DodajWizyteModel model = new DodajWizyteModel(miasto);

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult WizytaGabinet2(string miasto)
        {
            CheckSession();
            DodajWizyteModel model = new DodajWizyteModel(miasto);

            return PartialView(model);
        }

        public ActionResult WizytaLekarz(string gabinetid)
        {
            CheckSession();
            LekarzeModel model = new LekarzeModel(gabinetid);

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult WizytaLekarz2(string gabinet)
        {
            CheckSession();
            LekarzeModel model = new LekarzeModel(gabinet);

            return PartialView(model);
        }

        public ActionResult WizytaGodzina()
        {
            CheckSession();
            DodajWizyteModel model = new DodajWizyteModel();

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult WizytaGodzina2(string data, int lekarz, string placowkaID)
        {
            CheckSession();
            WizytaGodzinaModel model = new WizytaGodzinaModel(data, lekarz, placowkaID);

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult SaveWizyta(string gabinet, string lekarz, string data, string godzina, string rodzajWizyty, string typWizyty, string stan, string uwagi)
        {
            CheckSession();
            var dataUrodzenia = client.GetPacjentByID(Convert.ToInt32(Session["ID"]));
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
                DataUrodzenia = dataUrodzenia.DataUrodzin
            };

            bool isOk = client.WizytaInsert(model);
            if (isOk == true)
            {
                TempData["Zapisano"] = "Utworzono nową wizyte!";
                return RedirectToAction("Wizyta");
            }
            else
            {
                TempData["Zapisano"] = "Bląd! Spróbuj jeszcze raz.";
                return RedirectToAction("Wizyta");
            }
        }

        public ActionResult Historia()
        {
            CheckSession();
            ViewBag.Strona = "Dental - Historia";
            TempData.Keep();
            int id = Convert.ToInt32(Session["ID"]);
            var model = client.GetWizytaByPacjentID(id);

            var lekarz = client.GetPesonelList();
            var gabinet = client.GetPlacowkaList();
            var rachunek = client.GetRachunekList();
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

        public ActionResult InfoHistoriaPacjenta(int PacjentID, string Data)
        {
            CheckSession();
            var wizyta = client.GetWizytaByPacjentID(PacjentID);
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

            var mod = model.Where(a => a.Data == Data).ToList();

            return View(mod);
        }

        public ActionResult Cennik()
        {
            CheckSession();
            ViewBag.Strona = "Dental - Cennik";
            TempData.Keep();
            CennikModel model = new CennikModel();
            return View(model);
        }

        public ActionResult ListaCennikDefault()
        {
            CheckSession();
            var wynikKategoria = client.GetCennikList();

            return PartialView(wynikKategoria);
        }

        [HttpPost]
        public ActionResult ListaCennik(string kategoria)
        {
            CheckSession();
            var wynikKategoria = client.GetCennikByKategoria(kategoria);

            return PartialView(wynikKategoria);
        }

        public ActionResult Kontakt()
        {
            CheckSession();
            ViewBag.Strona = "Dental - Kontakt";
            TempData.Keep();

            KontaktModel model = new KontaktModel();
            return View(model);
        }


        public ActionResult ListaGabinetowDefault()
        {
            CheckSession();
            var wynikAdres = client.GetAdresPlacowkaList();
            var wynikMiasto = client.GetPlacowkaList();

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
        [HttpPost]
        public ActionResult ListaGabinetow(string miasto)
        {
            CheckSession();
            var wynikAdres = client.GetAdresPlacowkaByCity(miasto);
            var wynikMiasto = client.GetPlacowkaList();

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

        public ActionResult Profil()
        {
            CheckSession();
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
                Wojewodztwo = wynikAdresID.Wojewodztwo,
                DataUrodzenia = wynikPacjentID.DataUrodzin,
            };

            return View(editPacjentModel);
        }


        public ActionResult DeleteKonto(int dane)
        {
            CheckSession();
            bool isOk = client.PacjentDelete(dane);

            return Json(isOk, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveEdit(EditPacjentModel model)
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
                        Imie = model.Imie,
                        Nazwisko = model.Nazwisko,
                        Telefon = model.Telefon,
                        Email = model.Email,
                        Haslo = model.Haslo,
                        PESEL = model.PESEL,
                        PowtorzHaslo = model.PowtorzHaslo,
                        PacjentAdres = modelAdres,
                        DataUrodzin = model.DataUrodzenia

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