using System;

namespace DAL.Model
{
    public class Pacjent
    {

        public int PacjentID { get; set; }

        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public string PESEL { get; set; }

        public DateTime DataUrodzin { get; set; }

        public int Telefon { get; set; }

        public string Email { get; set; }
        public string Typ { get; set; }

        public string Haslo { get; set; }

        public string PowtorzHaslo { get; set; }

        public virtual Adres PacjentAdres { get; set; }
    }
}
