using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
    [Table("Rozpoznanie")]
    public class Rozpoznanie
    {
        public int RozpoznanieID { get; set; }

        public string Rozpoz { get; set; }
    }
}
