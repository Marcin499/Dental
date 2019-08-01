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
                    var wynik = context.Adress.Where(a => a.AdresID == id).First();

                    context.Adress.Remove(wynik);
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
                    context.Adress.Add(adres);

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
                    var wynik = context.Adress.Where(a => a.AdresID == adres.AdresID).FirstOrDefault();
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
            return context.Adress.Where(a => a.AdresID == id).FirstOrDefault();
        }

        public List<Adres> GetAdresList()
        {
            return context.Adress.ToList();
        }
        #endregion

        #region Pacjent
        public Pacjent GetPacjentByID(int id)
        {
            return context.Pacjents.Where(a => a.PacjentID == id).FirstOrDefault();
        }

        public Pacjent GetPacjentEmail(string email)
        {
            return context.Pacjents.Where(a => a.Email == email).FirstOrDefault();
        }

        public List<Pacjent> GetPacjentList()
        {
            return context.Pacjents.ToList();
        }

        public bool PacjentDelete(int id)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.Pacjents.Where(a => a.PacjentID == id).First();

                    context.Pacjents.Remove(wynik);
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
                    context.Pacjents.Add(pacjent);

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
                    var wynik = context.Pacjents.Where(a => a.PacjentID == pacjent.PacjentID).FirstOrDefault();
                    wynik.PacjentID = pacjent.PacjentID;
                    wynik.Imie = pacjent.Imie;
                    wynik.Nazwisko = pacjent.Nazwisko;
                    wynik.PESEL = pacjent.PESEL;
                    wynik.Telefon = pacjent.Telefon;
                    wynik.Typ = pacjent.Typ;
                    wynik.Email = pacjent.Email;
                    wynik.Haslo = pacjent.Haslo;
                    wynik.PowtorzHaslo = pacjent.PowtorzHaslo;

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
            return context.Placowkas.Where(a => a.PlacowkaID == id).FirstOrDefault();
        }


        public List<Placowka> GetPlacowkaList()
        {
            return context.Placowkas.ToList();
        }

        public bool PlacowkaDelete(int id)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.AdresPlacowkas.Where(a => a.AdresID == id).First();

                    context.AdresPlacowkas.Remove(wynik);
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
                    context.Placowkas.Add(placowka);

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

        public bool PlacowkaUpdate(Placowka placowka)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.Placowkas.Where(a => a.PlacowkaID == placowka.PlacowkaID).FirstOrDefault();
                    wynik.PlacowkaID = placowka.PlacowkaID;
                    wynik.Nazwa = placowka.Nazwa;
                    wynik.Telefon = placowka.Telefon;

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
            return context.Pesonels.Where(a => a.PersonelID == id).FirstOrDefault();
        }


        public List<Personel> GetPesonelList()
        {
            return context.Pesonels.ToList();
        }

        public bool PersonelDelete(int id)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.Pesonels.Where(a => a.PersonelID == id).First();

                    context.Pesonels.Remove(wynik);
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

        public bool PesonelInsert(Personel personel)
        {

            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Pesonels.Add(personel);

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

        public bool PersonelUpdate(Personel personel)
        {
            using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.Pesonels.Where(a => a.PersonelID == personel.PersonelID).FirstOrDefault();
                    wynik.PersonelID = personel.PersonelID;
                    wynik.Imie = personel.Imie;
                    wynik.Nazwisko = personel.Nazwisko;
                    wynik.PlacowkaID = personel.PlacowkaID;
                    wynik.Telefon = personel.Telefon;
                    wynik.Typ = personel.Typ;
                    wynik.Email = personel.Email;
                    wynik.Haslo = personel.Haslo;
                    wynik.PowtorzHaslo = personel.PowtorzHaslo;
                    wynik.Specjalizacja = personel.Specjalizacja;

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
            return context.AdresPlacowkas.Where(a => a.AdresID == id).FirstOrDefault();
        }


        public List<AdresPlacowka> GetAdresPlacowkaList()
        {
            return context.AdresPlacowkas.ToList();
        }
        #endregion
    }
}
