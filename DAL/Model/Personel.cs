using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
    [Table("Personel")]
    public class Personel
    {
        public int PersonelID { get; set; }

        public int Placowka { get; set; }

        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public int Telefon { get; set; }

        public string Email { get; set; }

        public string Typ { get; set; }

        public string Specjalizacja { get; set; }

        public string Haslo { get; set; }

        public string PowtorzHaslo { get; set; }

        public virtual AdresPersonel PersonelAdres { get; set; }
    }
}
