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

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult ListaPlacowki()
        {
            List<Placowka> getPlacowki = client.GetPlacowkaList();
            var getAdres = client.GetAdresPlacowkaList();

            var model = from p in getPlacowki
                        join ad in getAdres on p.PlacowkaID equals ad.AdresID
                        select new ListaPlacowkiModel { PlacowkaID = p.PlacowkaID, Nazwa = p.Nazwa, Telefon = p.Telefon, Email = p.Email, GodzOd = p.GodzOd, GodzDo = p.GodzDo, Wojewodztwo = ad.Wojewodztwo, Miasto = ad.Miasto, Ulica = ad.Ulica, Numer = ad.Numer };

            return PartialView(model);
        }

        public ActionResult DodajPlacowke()
        {
            if (Session["Sesja"] != null)
            {

                ViewBag.Strona = "Dental - Administracja";
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

        public ActionResult EditPlacowka(int PlacowkaID)
        {
            if (Session["Sesja"] != null)
            {

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
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        [HttpPost]
        public ActionResult SaveEditPlacowka(EditPlacowkiModel model)
        {
            if (Session["Sesja"] != null)
            {
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
                ViewBag.Strona = "Dental - Pesonel";

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult ListaPersonel()
        {
            if (Session["Sesja"] != null)
            {
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
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult DodajPersonel()
        {
            if (Session["Sesja"] != null)
            {

                ViewBag.Strona = "Dental - Personel";
                DodajPersonelModel model = new DodajPersonelModel();
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        [HttpPost]
        public ActionResult SavePersonel(DodajPersonelModel model)
        {
            if (Session["Sesja"] != null)
            {
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
                        Placowka = model.Placowka.ToString(),
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
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult DeletePersonel(int PersonelID)
        {
            if (Session["Sesja"] != null)
            {
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
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult EditPersonel(int PersonelID)
        {
            if (Session["Sesja"] != null)
            {

                ViewBag.Strona = "Dental - Personel";
                var modelPersonel = client.GetPersonelByID(PersonelID);
                var modelAdres = client.GetAdresPersonelByID(PersonelID);

                EditPersonelModel model = new EditPersonelModel(modelPersonel.Placowka, modelAdres.Wojewodztwo, modelPersonel.Typ, modelPersonel.Specjalizacja)
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
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        [HttpPost]
        public ActionResult SaveEditPersonel(EditPersonelModel model)
        {
            if (Session["Sesja"] != null)
            {
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

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult ListaZabiegów()
        {
            if (Session["Sesja"] != null)
            {

                ViewBag.Strona = "Dental - Cennik";
                var model = client.GetCennikList();
                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult DodajZabieg()
        {
            if (Session["Sesja"] != null)
            {

                ViewBag.Strona = "Dental - Cennik";
                DodajZabiegModel model = new DodajZabiegModel();
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        [HttpPost]
        public ActionResult SaveZabieg(DodajZabiegModel model)
        {
            if (Session["Sesja"] != null)
            {
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
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult DeleteZabieg(int ZabiegID)
        {
            if (Session["Sesja"] != null)
            {
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
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult EditZabieg(int ZabiegID)
        {
            if (Session["Sesja"] != null)
            {

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
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        [HttpPost]
        public ActionResult SaveEditZabieg(EditZabiegModel model)
        {
            if (Session["Sesja"] != null)
            {
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
            else
            {
                return RedirectToAction("Login", "Logowanie");
            }
        }

        public ActionResult Administracja()
        {
            if (Session["Sesja"] != null)
            {

                ViewBag.Strona = "Dental - Administracja";

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