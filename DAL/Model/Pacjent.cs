using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
    public class Pacjent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PacjentID { get; set; }
        [Required(ErrorMessage = "Proszę podać imię!")]
        [Display(Name = "Imię")]
        public string Imie { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwisko!")]
        public string Nazwisko { get; set; }
        [Required(ErrorMessage = "Proszę podać numer PESEL!"),
        MinLength(11, ErrorMessage = "PESEL nie może być krótszy niż 11 znaków!"), MaxLength(11, ErrorMessage = "PESEL nie może być dłuższy niż 11 znaków!")]
        public string PESEL { get; set; }
        [Required(ErrorMessage = "Proszę podać numer telefonu!")]
        public int Telefon { get; set; }
        [Display(Name = "Adres e-mail")]
        [Required(ErrorMessage = "Proszę podać adres e-mail!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail jest niepoprawny")]
        public string Email { get; set; }
        public string Typ { get; set; } = null;

        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Proszę podać hasło!")]
        public string Haslo { get; set; }
        [Display(Name = "Powtórz hasło")]
        [Required(ErrorMessage = "Hasło niezgadza sie z powyższym!")]
        public string PowtorzHaslo { get; set; }

        [NotMapped]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Zaznacz checkbox!")]
        public bool Check { get; set; }

        public virtual Adres PacjentAdres { get; set; }
    }
}
