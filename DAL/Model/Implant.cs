using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
    [Table("Implant")]
    public class Implant
    {
        [Key]
        public int IDImplantu { get; set; }

        public int IDPacjenta { get; set; }

        public string GD { get; set; }

        public string LP { get; set; }

        public int Zab { get; set; }
    }
}
