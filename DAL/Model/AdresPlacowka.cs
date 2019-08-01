using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
    public class AdresPlacowka
    {
        [Key]
        public int AdresID { get; set; }

        public string Miasto { get; set; }

        public string Wojewodztwo { get; set; }

        public string Ulica { get; set; }

        public string Numer { get; set; }

        public virtual Placowka AdresPlacowkaAdres { get; set; }
    }
}

