using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class Metody
    {
        Context context = new Context();
        #region Adres
        public bool AdresDelete(int id)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.Adres.Where(a => a.AdresID == id).First();

                    context.Adres.Remove(wynik);
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public bool AdresInsert(Adres adres)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Adres.Add(adres);

                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {

                    dbContextTransaction.Rollback();
                    return false;
                }

            }
        }

        public bool AdresUpdate(Adres adres)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.Adres.Where(a => a.AdresID == adres.AdresID).FirstOrDefault();
                    wynik.AdresID = adres.AdresID;
                    wynik.Miasto = adres.Miasto;
                    wynik.Ulica = adres.Ulica;
                    wynik.Numer = adres.Numer;
                    wynik.Wojewodztwo = adres.Wojewodztwo;
                    wynik.Kod = adres.Kod;

                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {

                    dbContextTransaction.Rollback();
                    return false;
                }

            }
        }

        public Adres GetAdresByID(int id)
        {
            return context.Adres.Where(a => a.AdresID == id).FirstOrDefault();
        }

        public List<Adres> GetAdresList()
        {
            return context.Adres.ToList();
        }
        #endregion

        #region Pacjent
        public Pacjent GetPacjentByID(int id)
        {
            return context.Pacjent.Where(a => a.PacjentID == id).FirstOrDefault();
        }

        public Pacjent GetPacjentEmail(string email)
        {
            return context.Pacjent.Where(a => a.Email == email).FirstOrDefault();
        }

        public List<Pacjent> GetPacjentList()
        {
            return context.Pacjent.ToList();
        }

        public bool PacjentDelete(int id)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.Pacjent.Where(a => a.PacjentID == id).First();

                    context.Pacjent.Remove(wynik);
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {

                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public bool PacjentInsert(Pacjent pacjent)
        {

            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Pacjent.Add(pacjent);

                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {

                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public bool PacjentUpdate(Pacjent pacjent)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.Pacjent.Where(a => a.PacjentID == pacjent.PacjentID).FirstOrDefault();
                    wynik.PacjentID = pacjent.PacjentID;
                    wynik.Imie = pacjent.Imie;
                    wynik.Nazwisko = pacjent.Nazwisko;
                    wynik.PESEL = pacjent.PESEL;
                    wynik.Telefon = pacjent.Telefon;
                    wynik.Typ = pacjent.Typ;
                    wynik.Email = pacjent.Email;
                    wynik.Haslo = pacjent.Haslo;


                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {

                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }
        #endregion

        #region Placowka
        public Placowka GetPlacowkaByID(int id)
        {
            return context.Placowka.Where(a => a.PlacowkaID == id).FirstOrDefault();
        }

        public List<Placowka> GetPlacowkaList()
        {
            return context.Placowka.ToList();
        }

        public bool PlacowkaDelete(int id)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.AdresPlacowka.Where(a => a.AdresID == id).First();
                    var wynik2 = context.Placowka.Where(a => a.PlacowkaID == id).First();
                    context.AdresPlacowka.Remove(wynik);
                    context.Placowka.Remove(wynik2);
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public bool PlacowkaInsert(Placowka placowka)
        {

            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Placowka.Add(placowka);

                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public bool PlacowkaUpdate(Placowka placowka, AdresPlacowka adres)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.Placowka.Where(a => a.PlacowkaID == placowka.PlacowkaID).FirstOrDefault();
                    wynik.PlacowkaID = placowka.PlacowkaID;
                    wynik.Nazwa = placowka.Nazwa;
                    wynik.Telefon = placowka.Telefon;
                    wynik.Email = placowka.Email;
                    wynik.GodzOd = placowka.GodzOd;
                    wynik.GodzDo = placowka.GodzDo;

                    var wynik2 = context.AdresPlacowka.Where(a => a.AdresID == placowka.PlacowkaID).FirstOrDefault();
                    wynik2.Wojewodztwo = adres.Wojewodztwo;
                    wynik2.Miasto = adres.Miasto;
                    wynik2.Ulica = adres.Ulica;
                    wynik2.Numer = adres.Numer;

                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }
        #endregion

        #region Personel
        public Personel GetPersonelByID(int id)
        {
            return context.Personel.Where(a => a.PersonelID == id).FirstOrDefault();
        }


        public List<Personel> GetPesonelList()
        {
            return context.Personel.ToList();
        }

        public Personel GetPersonelEmail(string email)
        {
            return context.Personel.Where(a => a.Email == email).FirstOrDefault();
        }
        public bool PersonelDelete(int id)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.AdresPersonel.Where(a => a.AdresID == id).First();
                    var wynik2 = context.Personel.Where(a => a.PersonelID == id).First();
                    context.AdresPersonel.Remove(wynik);
                    context.Personel.Remove(wynik2);
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public bool PersonelInsert(Personel personel)
        {

            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Personel.Add(personel);

                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public bool PersonelUpdate(Personel personel, AdresPersonel adres)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.Personel.Where(a => a.PersonelID == personel.PersonelID).FirstOrDefault();
                    wynik.PersonelID = personel.PersonelID;
                    wynik.Imie = personel.Imie;
                    wynik.Nazwisko = personel.Nazwisko;
                    wynik.Placowka = personel.Placowka;
                    wynik.Telefon = personel.Telefon;
                    wynik.Typ = personel.Typ;
                    wynik.Email = personel.Email;
                    wynik.Haslo = personel.Haslo;
                    wynik.PowtorzHaslo = personel.PowtorzHaslo;
                    wynik.Specjalizacja = personel.Specjalizacja;

                    var wynik2 = context.AdresPersonel.Where(a => a.AdresID == adres.AdresID).FirstOrDefault();
                    wynik2.AdresID = adres.AdresID;
                    wynik2.Wojewodztwo = adres.Wojewodztwo;
                    wynik2.Miasto = adres.Miasto;
                    wynik2.Ulica = adres.Ulica;
                    wynik2.Numer = adres.Numer;
                    wynik2.Kod = adres.Kod;

                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }
        #endregion

        #region AdresPlacowka
        public AdresPlacowka GetAdresPlacowkaByID(int id)
        {
            return context.AdresPlacowka.Where(a => a.AdresID == id).FirstOrDefault();
        }

        public List<AdresPlacowka> GetAdresPlacowkaByCity(string miasto)
        {
            return context.AdresPlacowka.Where(a => a.Miasto == miasto).ToList();
        }

        public List<AdresPlacowka> GetAdresPlacowkaList()
        {
            return context.AdresPlacowka.ToList();
        }
        #endregion

        #region AdresPersonel
        public AdresPersonel GetAdresPersonelByID(int id)
        {
            return context.AdresPersonel.Where(a => a.AdresID == id).FirstOrDefault();
        }


        public List<AdresPersonel> GetAdresPersonelList()
        {
            return context.AdresPersonel.ToList();
        }
        #endregion

        #region Cennik
        public Cennik GetCennikByID(int id)
        {
            return context.Cennik.Where(a => a.ZabiegID == id).FirstOrDefault();
        }

        public List<Cennik> GetCennikByKategoria(string kategoria)
        {
            return context.Cennik.Where(a => a.Kategoria == kategoria).ToList();
        }


        public List<Cennik> GetCennikList()
        {
            return context.Cennik.ToList();
        }

        public bool CennikDelete(int id)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.Cennik.Where(a => a.ZabiegID == id).First();
                    context.Cennik.Remove(wynik);

                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public bool CennikInsert(Cennik cennik)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Cennik.Add(cennik);

                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {

                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public bool CennikUpdate(Cennik cennik)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.Cennik.Where(a => a.ZabiegID == cennik.ZabiegID).FirstOrDefault();
                    wynik.Zabieg = cennik.Zabieg;
                    wynik.Kategoria = cennik.Kategoria;
                    wynik.Cena = cennik.Cena;

                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }
        #endregion

        #region Wizyta
        public Wizyta GetWizytaByID(int id)
        {
            return context.Wizyta.Where(a => a.WizytaID == id).FirstOrDefault();
        }

        public List<Wizyta> GetWizytaByPacjentID(int id)
        {
            return context.Wizyta.Where(a => a.PacjentID == id).ToList();
        }

        public List<Wizyta> GetWizytaByIDLekarz(int id)
        {
            return context.Wizyta.Where(a => a.LekarzID == id).ToList();
        }

        public List<Wizyta> GetWizytaList()
        {
            return context.Wizyta.ToList();
        }

        public bool WizytaDelete(Wizyta wizyta)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.Wizyta.Where(a => a.WizytaID == wizyta.WizytaID).First();
                    context.Wizyta.Remove(wynik);

                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public bool WizytaInsert(Wizyta wizyta)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Wizyta.Add(wizyta);

                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {

                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public bool WizytaUpdate(Wizyta wizyta)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.Wizyta.Where(a => a.WizytaID == wizyta.WizytaID).FirstOrDefault();
                    wynik.LekarzID = wizyta.LekarzID;
                    wynik.GabinetID = wizyta.GabinetID;
                    wynik.Data = wizyta.Data;
                    wynik.Godzina = wizyta.Godzina;
                    wynik.Stan = wizyta.Stan;
                    wynik.Typ = wizyta.Typ;
                    wynik.Rodzaj = wizyta.Rodzaj;
                    wynik.RachunekID = wizyta.RachunekID;


                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public List<Wizyta> GetWizytaByDateAndDoctor(string date, int lekarz)
        {
            var wynik = context.Wizyta.Where(a => a.Data == date && a.LekarzID == lekarz).ToList();

            return wynik;
        }
        #endregion

        #region Rachunek
        public Rachunek GetRachunekByID(int id)
        {
            return context.Rachunek.Where(a => a.RachunekID == id).FirstOrDefault();
        }

        public List<Rachunek> GetRachunekList()
        {
            return context.Rachunek.ToList();
        }

        public bool RachunekDelete(Rachunek rachunek)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.Rachunek.Where(a => a.RachunekID == rachunek.RachunekID).First();
                    context.Rachunek.Remove(wynik);

                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public bool RachunekInsert(Rachunek rachunek)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Rachunek.Add(rachunek);

                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {

                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public bool RachunekUpdate(Rachunek rachunek)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.Rachunek.Where(a => a.RachunekID == rachunek.RachunekID).FirstOrDefault();
                    wynik.RachunekID = rachunek.RachunekID;
                    wynik.Cena = rachunek.Cena;
                    wynik.Rabat = rachunek.Rabat;
                    wynik.KwotaDoZaplaty = rachunek.KwotaDoZaplaty;
                    wynik.FormaPlatnosci = rachunek.FormaPlatnosci;
                    wynik.Faktura = rachunek.Faktura;

                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }
        #endregion

        #region Zeby

        public List<Zeby> GetZebyList()
        {
            return context.Zeby.ToList();
        }
        #endregion

        #region Implant

        public List<Implant> GetImplantByID(int id)
        {
            return context.Implant.Where(a => a.IDPacjenta == id).ToList();
        }

        public bool ImplantInsert(Implant imp)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Implant.Add(imp);

                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {

                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }
        #endregion

        #region BrakZebow

        public List<BrakZebow> GetBrakZebowList()
        {
            return context.BrakZebow.ToList();
        }

        public List<BrakZebow> GetBrakZebowByID(int id)
        {
            return context.BrakZebow.Where(a => a.PacjentID == id).ToList();
        }

        public bool BrakZebowDelete(BrakZebow brakZebow)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.BrakZebow.Where(a => a.ZabID == brakZebow.ZabID).First();
                    context.BrakZebow.Remove(wynik);

                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public bool BrakZebowInsert(BrakZebow brakZebow)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.BrakZebow.Add(brakZebow);

                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {

                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public bool BrakZebowUpdate(BrakZebow brakZebow)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.BrakZebow.Where(a => a.ZabID == brakZebow.ZabID).FirstOrDefault();
                    wynik.ZabID = brakZebow.ZabID;
                    wynik.Kategoria = brakZebow.Kategoria;
                    wynik.GD = brakZebow.GD;
                    wynik.LP = brakZebow.LP;
                    wynik.Zab = brakZebow.Zab;


                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }
        #endregion

        #region Rozpoznanie

        public Rozpoznanie GetRozpoznanieByID(int id)
        {
            return context.Rozpoznanie.Where(a => a.RozpoznanieID == id).FirstOrDefault();
        }

        public List<Rozpoznanie> GetRozpoznanieList()
        {
            return context.Rozpoznanie.ToList();
        }

        public bool RozpoznanieDelete(Rozpoznanie rozpoznanie)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.Rozpoznanie.Where(a => a.RozpoznanieID == rozpoznanie.RozpoznanieID).First();
                    context.Rozpoznanie.Remove(wynik);

                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public bool RozpoznanieInsert(Rozpoznanie rozpoznanie)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Rozpoznanie.Add(rozpoznanie);

                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {

                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public bool RozpoznaieUpdate(Rozpoznanie rozpoznanie)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.Rozpoznanie.Where(a => a.RozpoznanieID == rozpoznanie.RozpoznanieID).FirstOrDefault();
                    wynik.RozpoznanieID = rozpoznanie.RozpoznanieID;
                    wynik.Rozpoz = rozpoznanie.Rozpoz;

                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }
        #endregion

        #region Leczenie

        public List<Leczenie> GetLeczenieByIDWizyta(int id)
        {
            return context.Leczenie.Where(a => a.WizytaID == id).ToList();
        }

        public List<Leczenie> GetLeczenieList()
        {
            return context.Leczenie.ToList();
        }

        public bool LeczenieDelete(int id)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.Leczenie.Where(a => a.LeczenieID == id).First();
                    context.Leczenie.Remove(wynik);

                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public bool LeczenieInsert(Leczenie leczenie)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Leczenie.Add(leczenie);

                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {

                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public bool LeczenieUpdate(Leczenie leczenie)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.Leczenie.Where(a => a.LeczenieID == leczenie.LeczenieID).FirstOrDefault();
                    wynik.LeczenieID = leczenie.LeczenieID;
                    wynik.GD = leczenie.GD;
                    wynik.LP = leczenie.LP;
                    wynik.Zab = leczenie.Zab;
                    wynik.WizytaID = leczenie.WizytaID;
                    wynik.Rozpoznanie = leczenie.Rozpoznanie;

                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }
        #endregion

        #region CredentialSMS
        public List<CredentialsSMS> GetCredentialSMSList()
        {
            return context.CredentialsSMS.ToList();
        }
        #endregion
    }
}
