using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
    [Table("Cennik")]
    public class Cennik
    {
        [Key]
        public int ZabiegID { get; set; }

        public string Zabieg { get; set; }

        public string Kategoria { get; set; }

        public int Cena { get; set; }
    }
}
