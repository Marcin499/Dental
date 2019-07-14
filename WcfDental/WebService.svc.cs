
using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WcfDental
{

    public class WebService : IService
    {
        #region Pacjent
        Context context = new Context();

        public Pacjent GetPacjentByID(int id)
        {
            return context.Pacjents.Where(a => a.PacjentID == id).FirstOrDefault();
        }

        public List<Pacjent> GetPacjentList()
        {
            return context.Pacjents.ToList();
        }

        public void PacjentDelete(int id)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var wynik = context.Pacjents.Where(a => a.PacjentID == id).First();
                    context.Pacjents.Remove(wynik);
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    dbContextTransaction.Rollback();
                }
            }
        }

        public void PacjentInsert(Pacjent pacjent)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Pacjents.Add(pacjent);
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    dbContextTransaction.Rollback();
                }
            }
        }

        public void PacjentUpdate(Pacjent pacjent)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
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
                }
                catch (Exception)
                {

                    dbContextTransaction.Rollback();
                }
            }
        }
        #endregion
    }
}
