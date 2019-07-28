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
                    var suma = 
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
    }
}
