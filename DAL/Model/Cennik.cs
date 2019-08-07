using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
    public class Cennik
    {
        [Key]
        public int ZabiegID { get; set; }

        public string Zabieg { get; set; }

        public string Kategoria { get; set; }

        public int Cena { get; set; }
    }
}
