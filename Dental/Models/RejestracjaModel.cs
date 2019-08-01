using System.ComponentModel.DataAnnotations;

namespace Dental.Models
{
    #region RejestracjaModel
    public class RejestracjaModel
    {
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
        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Proszę podać hasło!")]
        public string Haslo { get; set; }
        [Display(Name = "Powtórz hasło")]
        [System.ComponentModel.DataAnnotations.Compare("Haslo", ErrorMessage = "Hasła nie są zgodne!")]
        public string PowtorzHaslo { get; set; }
        [Required(ErrorMessage = "Proszę podać miasto!")]
        public string Miasto { get; set; }
        [Display(Name = "Województwo")]
        [Required(ErrorMessage = "Proszę wybrac województwo!")]
        public Wojewodztwa Wojewodztwo { get; set; }
        [Required(ErrorMessage = "Proszę podać ulicę!")]
        public string Ulica { get; set; }
        [Display(Name = "Numer domu lub mieszkania")]
        [Required(ErrorMessage = "Prosze podać numer domu badź mieszkania!")]
        public string Numer { get; set; }
        [Display(Name = "Kod pocztowy")]
        [Required(ErrorMessage = "Prosze podać kod pocztowy")]
        public string Kod { get; set; }
        [System.ComponentModel.DataAnnotations.Compare("True", ErrorMessage = "Zatwiedź warunki!")]
        public bool Check { get; set; }
        public bool True { get; set; }

        public RejestracjaModel()
        {
            this.True = true;
        }
    }
    #endregion

    #region Województwa
    public enum Wojewodztwa
    {
        Dolnośląskie,
        Kujawsko_Pomorskie,
        Lubelskie,
        Lubuskie,
        Łódzkie,
        Małopolskie,
        Mazowieckie,
        Opolskie,
        Podkarpackie,
        Podlaskie,
        Pomorskiem,
        Śląskie,
        Świetokrzyskie,
        Warmińsko_Mazurskie,
        Wielkopolskie,
        Zachodniopomorskie
    }
    #endregion

    #region LogowanieModel
    public class LogowanieModel
    {
        [Display(Name = "Adres e-mail")]
        [Required(ErrorMessage = "Proszę podać adres e-mail!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail jest niepoprawny")]
        public string Email { get; set; }
        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Proszę podać hasło!")]
        public string Haslo { get; set; }
    }
    #endregion

    #region ResetHaslaLogowanieModel
    public class ResetHaslaLogowanieModel
    {
        [Display(Name = "Adres e-mail")]
        [Required(ErrorMessage = "Proszę podać adres e-mail!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail jest niepoprawny")]
        public string Email { get; set; }
        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Proszę podać hasło!")]
        public string Haslo { get; set; }
        [System.ComponentModel.DataAnnotations.Compare("Haslo", ErrorMessage = "Hasła nie są zgodne!")]
        public string PowtorzHaslo { get; set; }
    }
    #endregion

    #region EditPacjentModel
    public class EditPacjentModel
    {
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
        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Proszę podać hasło!")]
        public string Haslo { get; set; }
        [Display(Name = "Powtórz hasło")]
        [System.ComponentModel.DataAnnotations.Compare("Haslo", ErrorMessage = "Hasła nie są zgodne!")]
        public string PowtorzHaslo { get; set; }
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
    }
    #endregion

    #region ListaPlacowkiModel
    public class ListaPlacowkiModel
    {
        public int PlacowkaID { get; set; }

        public string Nazwa { get; set; }

        public int Telefon { get; set; }

        public string Email { get; set; }

        public string Miasto { get; set; }

        public string Wojewodztwo { get; set; }

        public string Ulica { get; set; }

        public string Numer { get; set; }
    }
    #endregion

    #region DodajPlacowkeModel
    public class DodajPlacowkeModel
    {
        public int PlacowkaID { get; set; }

        public string Nazwa { get; set; }

        public int Telefon { get; set; }

        public string Email { get; set; }

        public string Miasto { get; set; }

        public Wojewodztwa Wojewodztwo { get; set; }

        public string Ulica { get; set; }

        public string Numer { get; set; }
    }
    #endregion
}