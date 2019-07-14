using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
    public class Adres
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdresID { get; set; }
        public int PacjentId { get; set; }
        [Required(ErrorMessage = "Proszę podać miasto!")]
        public string Miasto { get; set; }
        [Display(Name = "Województwo")]
        [Required(ErrorMessage = "Proszę wybrac województwo!")]
        public string Wojewodztwo { get; set; }
        [Required(ErrorMessage = "Proszę podać ulicę!")]
        public string Ulica { get; set; }
        [Display(Name = "Numer domu lub mieszkania")]
        [Required(ErrorMessage = "Prosze podać numer domu badź mieszkania!")]
        public string Numer { get; set; }
        [Display(Name = "Kod pocztowy")]
        [Required(ErrorMessage = "Prosze podać kod pocztowy")]
        public string Kod { get; set; }

        public virtual Pacjent AdresPacjent { get; set; }
    }
}
