using System.ComponentModel.DataAnnotations;

namespace Dental.Models
{
    public class RejestracjaModel
    {
        [Display(Name = "Imię")]
        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public int PESEL { get; set; }

        public int Telefon { get; set; }

        public string Email { get; set; }

        public string Hasło { get; set; }

        [Display(Name = "Powtórz hasło")]
        public string PowtorzHaslo { get; set; }

        public string Miasto { get; set; }

        public Wojewodztwa Wojewodztwo { get; set; }

        public string Ulica { get; set; }

        public string Numer { get; set; }

        public string Kod { get; set; }

        public RejestracjaModel()
        {


        }

    }

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
}