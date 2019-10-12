using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
    [Table("AdresPersonel")]
    public class AdresPersonel
    {
       [Key]
        public int AdresID { get; set; }

        public string Miasto { get; set; }

        public string Wojewodztwo { get; set; }

        public string Ulica { get; set; }

        public string Numer { get; set; }

        public string Kod { get; set; }

        public virtual Personel AdresPesonel { get; set; }
    }
}