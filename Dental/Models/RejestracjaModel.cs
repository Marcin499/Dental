using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

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
        public string Wojewodztwo { get; set; }
        public List<SelectListItem> ListaWojewodztwa { get; set; }
        [Required(ErrorMessage = "Proszę podać ulicę!")]
        public string Ulica { get; set; }
        [Required(ErrorMessage = "Proszę podać date urodzenia!")]
        public DateTime DataUrodzin { get; set; }
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
            this.ListaWojewodztwa = InitWojewodztwa();
        }

        private List<SelectListItem> InitWojewodztwa()
        {
            List<SelectListItem> lista = new List<SelectListItem>
            {
                new SelectListItem() { Value = "Dolnośląskie", Text = "Dolnośląskie" },
                new SelectListItem() { Value = "Kujawsko-Pomorskie", Text = "Kujawsko-Pomorskie" },
                new SelectListItem() { Value = "Lubelskie", Text = "Lubelskie" },
                new SelectListItem() { Value = "Lubuskie", Text = "Lubuskie" },
                new SelectListItem() { Value = "Łódzkie", Text = "Łódzkie" },
                new SelectListItem() { Value = "Małopolskie", Text = "Małopolskie" },
                new SelectListItem() { Value = "Mazowieckie", Text = "Mazowieckie" },
                new SelectListItem() { Value = "Opolskie", Text = "Opolskie" },
                new SelectListItem() { Value = "Podkarpackie", Text = "Podkarpackie" },
                new SelectListItem() { Value = "Podlaskie", Text = "Podlaskie" },
                new SelectListItem() { Value = "Pomorskiem", Text = "Pomorskiem" },
                new SelectListItem() { Value = "Śląskie", Text = "Śląskie" },
                new SelectListItem() { Value = "Świętokrzyskie", Text = "Świętokrzyskie" },
                new SelectListItem() { Value = "Warmińsko-Mazurskie", Text = "Warmińsko-Mazurskie" },
                new SelectListItem() { Value = "Wielkopolskie", Text = "Wielkopolskie" },
                new SelectListItem() { Value = "Zachodniopomorskie", Text = "Zachodniopomorskie" }
            };
            return lista;
        }
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
        [Required(ErrorMessage = "Proszę podać date urodzenia!")]
        public string DataUrodzenia { get; set; }
        [Display(Name = "Województwo")]
        [Required(ErrorMessage = "Proszę wybrac województwo!")]
        public string Wojewodztwo { get; set; }
        public List<SelectListItem> ListaWojewodztwa { get; set; }
        [Required(ErrorMessage = "Proszę podać ulicę!")]
        public string Ulica { get; set; }
        [Display(Name = "Numer domu lub mieszkania")]
        [Required(ErrorMessage = "Prosze podać numer domu badź mieszkania!")]
        public string Numer { get; set; }
        [Display(Name = "Kod pocztowy")]
        [Required(ErrorMessage = "Prosze podać kod pocztowy")]
        public string Kod { get; set; }

        public EditPacjentModel()
        {
            this.ListaWojewodztwa = InitWojewodztwa();
        }

        public EditPacjentModel(string wojewodztwo)
        {
            this.ListaWojewodztwa = InitWojewodztwa(wojewodztwo);
        }

        private List<SelectListItem> InitWojewodztwa()
        {
            List<SelectListItem> lista = new List<SelectListItem>
            {
                new SelectListItem() { Value = "Dolnośląskie", Text = "Dolnośląskie" },
                new SelectListItem() { Value = "Kujawsko-Pomorskie", Text = "Kujawsko-Pomorskie" },
                new SelectListItem() { Value = "Lubelskie", Text = "Lubelskie" },
                new SelectListItem() { Value = "Lubuskie", Text = "Lubuskie" },
                new SelectListItem() { Value = "Łódzkie", Text = "Łódzkie" },
                new SelectListItem() { Value = "Małopolskie", Text = "Małopolskie" },
                new SelectListItem() { Value = "Mazowieckie", Text = "Mazowieckie" },
                new SelectListItem() { Value = "Opolskie", Text = "Opolskie" },
                new SelectListItem() { Value = "Podkarpackie", Text = "Podkarpackie" },
                new SelectListItem() { Value = "Podlaskie", Text = "Podlaskie" },
                new SelectListItem() { Value = "Pomorskiem", Text = "Pomorskiem" },
                new SelectListItem() { Value = "Śląskie", Text = "Śląskie" },
                new SelectListItem() { Value = "Świętokrzyskie", Text = "Świętokrzyskie" },
                new SelectListItem() { Value = "Warmińsko-Mazurskie", Text = "Warmińsko-Mazurskie" },
                new SelectListItem() { Value = "Wielkopolskie", Text = "Wielkopolskie" },
                new SelectListItem() { Value = "Zachodniopomorskie", Text = "Zachodniopomorskie" }
            };
            return lista;
        }

        private List<SelectListItem> InitWojewodztwa(string wojewodztwo)
        {
            List<SelectListItem> lista = new List<SelectListItem>
            {
                new SelectListItem() { Value = "Dolnośląskie", Text = "Dolnośląskie" },
                new SelectListItem() { Value = "Kujawsko-Pomorskie", Text = "Kujawsko-Pomorskie" },
                new SelectListItem() { Value = "Lubelskie", Text = "Lubelskie" },
                new SelectListItem() { Value = "Lubuskie", Text = "Lubuskie" },
                new SelectListItem() { Value = "Łódzkie", Text = "Łódzkie" },
                new SelectListItem() { Value = "Małopolskie", Text = "Małopolskie" },
                new SelectListItem() { Value = "Mazowieckie", Text = "Mazowieckie" },
                new SelectListItem() { Value = "Opolskie", Text = "Opolskie" },
                new SelectListItem() { Value = "Podkarpackie", Text = "Podkarpackie" },
                new SelectListItem() { Value = "Podlaskie", Text = "Podlaskie" },
                new SelectListItem() { Value = "Pomorskiem", Text = "Pomorskiem" },
                new SelectListItem() { Value = "Śląskie", Text = "Śląskie" },
                new SelectListItem() { Value = "Świętokrzyskie", Text = "Świętokrzyskie" },
                new SelectListItem() { Value = "Warmińsko-Mazurskie", Text = "Warmińsko-Mazurskie" },
                new SelectListItem() { Value = "Wielkopolskie", Text = "Wielkopolskie" },
                new SelectListItem() { Value = "Zachodniopomorskie", Text = "Zachodniopomorskie" }
            };

            List<SelectListItem> nowa = new List<SelectListItem>();
            foreach (var item in lista)
            {
                nowa.Add(new SelectListItem() { Value = item.Value, Text = item.Text, Selected = item.Text == wojewodztwo });
            }
            return nowa;
        }
    }
    #endregion

    #region ListaPlacowkiModel
    public class ListaPlacowkiModel
    {
        public int PlacowkaID { get; set; }

        public string Nazwa { get; set; }

        public int Telefon { get; set; }

        public string Email { get; set; }

        public string GodzOd { get; set; }

        public string GodzDo { get; set; }

        public string Miasto { get; set; }

        public string Wojewodztwo { get; set; }

        public string Ulica { get; set; }

        public string Numer { get; set; }

    }
    #endregion

    #region PlacowkiModel
    public class PlacowkiModel
    {
        public int Placowki { get; set; }
        public List<SelectListItem> ListaPlacowki { get; set; }

        public PlacowkiModel()
        {
            this.ListaPlacowki = InitPlacowki();
        }

        private List<SelectListItem> InitPlacowki()
        {
            Metody client = new Metody();
            List<SelectListItem> lista = new List<SelectListItem>();
            var placowka = client.GetPlacowkaList();

            foreach (var pl in placowka)
            {
                lista.Add(new SelectListItem() { Value = pl.PlacowkaID.ToString(), Text = pl.Nazwa });

            }
            return lista;
        }
    }

    #endregion

    #region DodajPlacowkeModel
    public class DodajPlacowkeModel
    {

        [Required(ErrorMessage = "Proszę podać nazwę!")]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Proszę podać numer telefonu!")]
        public int Telefon { get; set; }
        [Required(ErrorMessage = "Proszę podać adres e-mail!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail jest niepoprawny")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Ustaw godzinę otwarcia!")]
        public string GodzOd { get; set; }
        public List<SelectListItem> ListaGodz { get; set; }
        [Required(ErrorMessage = "Ustaw godzinę zamknięcia!")]
        public string GodzDo { get; set; }
        [Required(ErrorMessage = "Proszę podać miasto!")]
        public string Miasto { get; set; }
        [Required(ErrorMessage = "Proszę wybrac województwo!")]
        public string Wojewodztwo { get; set; }
        public List<SelectListItem> ListaWojewodztwa { get; set; }
        [Required(ErrorMessage = "Proszę podać ulicę!")]
        public string Ulica { get; set; }
        [Required(ErrorMessage = "Prosze podać numer domu badź mieszkania!")]
        public string Numer { get; set; }

        public DodajPlacowkeModel()
        {
            this.ListaWojewodztwa = InitWojewodztwa();
            this.ListaGodz = InitGodziny();
        }

        private List<SelectListItem> InitGodziny()
        {
            List<SelectListItem> lista = new List<SelectListItem>()
           {
               new SelectListItem(){Value = "06.00", Text = "06.00"},
               new SelectListItem(){Value = "07.00", Text = "07.00"},
               new SelectListItem(){Value = "08.00", Text = "08.00"},
               new SelectListItem(){Value = "09.00", Text = "09.00"},
               new SelectListItem(){Value = "10.00", Text = "10.00"},
               new SelectListItem(){Value = "11.00", Text = "11.00"},
               new SelectListItem(){Value = "12.00", Text = "12.00"},
               new SelectListItem(){Value = "13.00", Text = "13.00"},
               new SelectListItem(){Value = "14.00", Text = "14.00"},
               new SelectListItem(){Value = "15.00", Text = "15.00"},
               new SelectListItem(){Value = "16.00", Text = "16.00"},
               new SelectListItem(){Value = "17.00", Text = "17.00"},
               new SelectListItem(){Value = "18.00", Text = "18.00"},
               new SelectListItem(){Value = "19.00", Text = "19.00"},
               new SelectListItem(){Value = "20.00", Text = "20.00"},
               new SelectListItem(){Value = "21.00", Text = "21.00"},
               new SelectListItem(){Value = "22.00", Text = "22.00"},
               new SelectListItem(){Value = "23.00", Text = "23.00"},
           };

            return lista;
        }

        private List<SelectListItem> InitWojewodztwa()
        {
            List<SelectListItem> lista = new List<SelectListItem>
            {
                new SelectListItem() { Value = "Dolnośląskie", Text = "Dolnośląskie" },
                new SelectListItem() { Value = "Kujawsko-Pomorskie", Text = "Kujawsko-Pomorskie" },
                new SelectListItem() { Value = "Lubelskie", Text = "Lubelskie" },
                new SelectListItem() { Value = "Lubuskie", Text = "Lubuskie" },
                new SelectListItem() { Value = "Łódzkie", Text = "Łódzkie" },
                new SelectListItem() { Value = "Małopolskie", Text = "Małopolskie" },
                new SelectListItem() { Value = "Mazowieckie", Text = "Mazowieckie" },
                new SelectListItem() { Value = "Opolskie", Text = "Opolskie" },
                new SelectListItem() { Value = "Podkarpackie", Text = "Podkarpackie" },
                new SelectListItem() { Value = "Podlaskie", Text = "Podlaskie" },
                new SelectListItem() { Value = "Pomorskiem", Text = "Pomorskiem" },
                new SelectListItem() { Value = "Śląskie", Text = "Śląskie" },
                new SelectListItem() { Value = "Świętokrzyskie", Text = "Świętokrzyskie" },
                new SelectListItem() { Value = "Warmińsko-Mazurskie", Text = "Warmińsko-Mazurskie" },
                new SelectListItem() { Value = "Wielkopolskie", Text = "Wielkopolskie" },
                new SelectListItem() { Value = "Zachodniopomorskie", Text = "Zachodniopomorskie" }
            };
            return lista;
        }
    }
    #endregion

    #region ListaPersonelModel
    public class ListaPersonelModel
    {
        public int PersonelID { get; set; }

        public string Placowka { get; set; }

        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public int Telefon { get; set; }

        public string Email { get; set; }

        public string Typ { get; set; }

        public string Specjalizacja { get; set; }

        public string Haslo { get; set; }

        public string Miasto { get; set; }

        public string Wojewodztwo { get; set; }

        public string Ulica { get; set; }

        public string Numer { get; set; }

        public string Kod { get; set; }
    }
    #endregion

    #region DodajPersonelModel
    public class DodajPersonelModel
    {

        public List<SelectListItem> PlacowkaList { get; set; }
        [Required(ErrorMessage = "Proszę wybrać gabinet!")]
        public int Placowka { get; set; }
        [Required(ErrorMessage = "Proszę podać imię!")]
        public string Imie { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwisko!")]
        public string Nazwisko { get; set; }
        [Required(ErrorMessage = "Proszę podać numer telefonu!")]
        public int Telefon { get; set; }
        [Required(ErrorMessage = "Proszę podać adres e-mail!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail jest niepoprawny")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Proszę wybrać typ!")]
        public string Typ { get; set; }
        public List<SelectListItem> ListaTyp { get; set; }

        public string Specjalizacja { get; set; }
        public List<SelectListItem> ListaSpecjalizacji { get; set; }
        [Required(ErrorMessage = "Proszę podać hasło!")]
        public string Haslo { get; set; }
        [System.ComponentModel.DataAnnotations.Compare("Haslo", ErrorMessage = "Hasła nie są zgodne!")]
        public string PowtorzHaslo { get; set; }
        [Required(ErrorMessage = "Proszę podać miasto!")]
        public string Miasto { get; set; }

        public string Wojewodztwo { get; set; }
        public List<SelectListItem> ListaWojewodztwa { get; set; }
        [Required(ErrorMessage = "Proszę podać ulicę!")]
        public string Ulica { get; set; }
        [Required(ErrorMessage = "Prosze podać numer domu badź mieszkania!")]
        public string Numer { get; set; }
        [Required(ErrorMessage = "Prosze podać kod pocztowy")]
        public string Kod { get; set; }

        public DodajPersonelModel()
        {
            this.PlacowkaList = InitPlacowka();
            this.ListaWojewodztwa = InitWojewodztwa();
            this.ListaTyp = InitTyp();
            this.ListaSpecjalizacji = InitSpecjalizacje();
        }

        private List<SelectListItem> InitSpecjalizacje()
        {
            List<SelectListItem> lista = new List<SelectListItem>
            {
                new SelectListItem() { Value = " Brak", Text = " Brak" },
                new SelectListItem() { Value = "Chirurgia", Text = "Chirurgia" },
                new SelectListItem() { Value = "Chirurgia szczękowo twarzowa", Text = "Chirurgia szczękowo twarzowa" },
                new SelectListItem() { Value = "Ortodoncja", Text = "Ortodoncja" },
                new SelectListItem() { Value = "Pedodoncja", Text = "Pedodoncja" },
                new SelectListItem() { Value = "Pielęgniarka", Text = "Pielęgniarka" },
                new SelectListItem() { Value = "Protetyka stomatologiczna", Text = "Protetyka stomatologiczna" },
                new SelectListItem() { Value = "Stomatologia", Text = "Stomatologia" },
                new SelectListItem() { Value = "Stomatologia zachowawcza z endodoncją", Text = "Stomatologia zachowawcza z endodoncją" }
            };

            return lista;
        }
        private List<SelectListItem> InitTyp()
        {
            List<SelectListItem> lista = new List<SelectListItem>
            {
                new SelectListItem() { Value = "Administrator", Text = "Administrator" },
                new SelectListItem() { Value = "Personel", Text = "Personel" }
            };

            return lista;
        }
        private List<SelectListItem> InitWojewodztwa()
        {
            List<SelectListItem> lista = new List<SelectListItem>
            {
                new SelectListItem() { Value = "Dolnośląskie", Text = "Dolnośląskie" },
                new SelectListItem() { Value = "Kujawsko-Pomorskie", Text = "Kujawsko-Pomorskie" },
                new SelectListItem() { Value = "Lubelskie", Text = "Lubelskie" },
                new SelectListItem() { Value = "Lubuskie", Text = "Lubuskie" },
                new SelectListItem() { Value = "Łódzkie", Text = "Łódzkie" },
                new SelectListItem() { Value = "Małopolskie", Text = "Małopolskie" },
                new SelectListItem() { Value = "Mazowieckie", Text = "Mazowieckie" },
                new SelectListItem() { Value = "Opolskie", Text = "Opolskie" },
                new SelectListItem() { Value = "Podkarpackie", Text = "Podkarpackie" },
                new SelectListItem() { Value = "Podlaskie", Text = "Podlaskie" },
                new SelectListItem() { Value = "Pomorskiem", Text = "Pomorskiem" },
                new SelectListItem() { Value = "Śląskie", Text = "Śląskie" },
                new SelectListItem() { Value = "Świętokrzyskie", Text = "Świętokrzyskie" },
                new SelectListItem() { Value = "Warmińsko-Mazurskie", Text = "Warmińsko-Mazurskie" },
                new SelectListItem() { Value = "Wielkopolskie", Text = "Wielkopolskie" },
                new SelectListItem() { Value = "Zachodniopomorskie", Text = "Zachodniopomorskie" }
            };
            return lista;
        }
        private List<SelectListItem> InitPlacowka()
        {
            Metody client = new Metody();
            List<SelectListItem> lista = new List<SelectListItem>();
            var model = client.GetPlacowkaList();

            foreach (var item in model)
            {
                lista.Add(new SelectListItem() { Value = item.PlacowkaID.ToString(), Text = item.Nazwa });
            }

            return lista;
        }
    }
    #endregion

    #region EditPersonelModel
    public class EditPersonelModel
    {
        public int PersonelID { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwę gabinetu!")]
        public int Placowka { get; set; }

        public List<SelectListItem> PlacowkaList { get; set; }
        [Required(ErrorMessage = "Proszę podać imię!")]
        public string Imie { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwisko!")]
        public string Nazwisko { get; set; }
        [Required(ErrorMessage = "Proszę podać numer telefonu!")]
        public int Telefon { get; set; }
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail jest niepoprawny")]
        public string Email { get; set; }

        public string Typ { get; set; }
        public List<SelectListItem> ListaTyp { get; set; }

        public string Specjalizacja { get; set; }
        public List<SelectListItem> ListaSpecjalizacji { get; set; }
        public string Haslo { get; set; }
        [System.ComponentModel.DataAnnotations.Compare("Haslo", ErrorMessage = "Hasła nie są zgodne!")]
        public string PowtorzHaslo { get; set; }
        [Required(ErrorMessage = "Proszę podać miasto!")]
        public string Miasto { get; set; }

        public string Wojewodztwo { get; set; }
        public List<SelectListItem> ListaWojewodztwa { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwe ulicy!")]
        public string Ulica { get; set; }
        [Required(ErrorMessage = "Proszę podać numer!")]
        public string Numer { get; set; }
        [Required(ErrorMessage = "Proszę podać kod pocztowy!")]
        public string Kod { get; set; }
        public EditPersonelModel()
        {

        }

        public EditPersonelModel(string placowka, string wojewodztwo, string typ, string specjalizacja)
        {
            this.PlacowkaList = InitPlacowka(placowka);
            this.ListaWojewodztwa = InitWojewodztwa(wojewodztwo);
            this.ListaTyp = InitTyp(typ);
            this.ListaSpecjalizacji = InitSpecjalizacje(specjalizacja);
        }

        private List<SelectListItem> InitSpecjalizacje(string specjalizacja)
        {
            List<SelectListItem> lista = new List<SelectListItem>
            {
                new SelectListItem() { Value = " Brak", Text = " Brak" },
                new SelectListItem() { Value = "Chirurgia", Text = "Chirurgia" },
                new SelectListItem() { Value = "Chirurgia szczękowo twarzowa", Text = "Chirurgia szczękowo twarzowa" },
                new SelectListItem() { Value = "Ortodoncja", Text = "Ortodoncja" },
                new SelectListItem() { Value = "Pedodoncja", Text = "Pedodoncja" },
                new SelectListItem() { Value = "Pielęgniarka", Text = "Pielęgniarka" },
                new SelectListItem() { Value = "Protetyka stomatologiczna", Text = "Protetyka stomatologiczna" },
                new SelectListItem() { Value = "Stomatologia", Text = "Stomatologia" },
                new SelectListItem() { Value = "Stomatologia zachowawcza z endodoncją", Text = "Stomatologia zachowawcza z endodoncją" }
            };

            List<SelectListItem> nowa = new List<SelectListItem>();
            foreach (var item in lista)
            {
                nowa.Add(new SelectListItem() { Value = item.Value, Text = item.Text, Selected = item.Text == specjalizacja });
            }
            return nowa;
        }

        private List<SelectListItem> InitTyp(string typ)
        {
            List<SelectListItem> lista = new List<SelectListItem>
            {
                new SelectListItem() { Value = "Administrator", Text = "Administrator" },
                new SelectListItem() { Value = "Personel", Text = "Personel" }
            };

            List<SelectListItem> nowa = new List<SelectListItem>();
            foreach (var item in lista)
            {
                nowa.Add(new SelectListItem() { Value = item.Value, Text = item.Text, Selected = item.Text == typ });
            }
            return nowa;
        }

        private List<SelectListItem> InitPlacowka(string placowka)
        {
            Metody client = new Metody();
            List<SelectListItem> lista = new List<SelectListItem>();
            var model = client.GetPlacowkaList();

            foreach (var item in model)
            {
                lista.Add(new SelectListItem() { Value = item.PlacowkaID.ToString(), Text = item.Nazwa, Selected = item.Nazwa == placowka });
            }
            return lista;
        }

        private List<SelectListItem> InitWojewodztwa(string wojewodztwo)
        {
            List<SelectListItem> lista = new List<SelectListItem>
            {
                new SelectListItem() { Value = "Dolnośląskie", Text = "Dolnośląskie" },
                new SelectListItem() { Value = "Kujawsko-Pomorskie", Text = "Kujawsko-Pomorskie" },
                new SelectListItem() { Value = "Lubelskie", Text = "Lubelskie" },
                new SelectListItem() { Value = "Lubuskie", Text = "Lubuskie" },
                new SelectListItem() { Value = "Łódzkie", Text = "Łódzkie" },
                new SelectListItem() { Value = "Małopolskie", Text = "Małopolskie" },
                new SelectListItem() { Value = "Mazowieckie", Text = "Mazowieckie" },
                new SelectListItem() { Value = "Opolskie", Text = "Opolskie" },
                new SelectListItem() { Value = "Podkarpackie", Text = "Podkarpackie" },
                new SelectListItem() { Value = "Podlaskie", Text = "Podlaskie" },
                new SelectListItem() { Value = "Pomorskiem", Text = "Pomorskiem" },
                new SelectListItem() { Value = "Śląskie", Text = "Śląskie" },
                new SelectListItem() { Value = "Świętokrzyskie", Text = "Świętokrzyskie" },
                new SelectListItem() { Value = "Warmińsko-Mazurskie", Text = "Warmińsko-Mazurskie" },
                new SelectListItem() { Value = "Wielkopolskie", Text = "Wielkopolskie" },
                new SelectListItem() { Value = "Zachodniopomorskie", Text = "Zachodniopomorskie" }
            };

            List<SelectListItem> nowa = new List<SelectListItem>();
            foreach (var item in lista)
            {
                nowa.Add(new SelectListItem() { Value = item.Value, Text = item.Text, Selected = item.Text == wojewodztwo });
            }
            return nowa;
        }
    }
    #endregion

    #region EditPlacowkiModel
    public class EditPlacowkiModel
    {
        public int PlacowkaID { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwe gabinetu!")]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Proszę podać numer telefonu!")]
        public int Telefon { get; set; }
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail jest niepoprawny")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Ustaw godzinę otwarcia!")]
        public string GodzOd { get; set; }
        public List<SelectListItem> ListaGodzOd { get; set; }
        public List<SelectListItem> ListaGodzDo { get; set; }
        [Required(ErrorMessage = "Ustaw godzinę zamknięcia!")]
        public string GodzDo { get; set; }
        [Required(ErrorMessage = "Proszę podać miasto!")]
        public string Miasto { get; set; }
        public string Wojewodztwo { get; set; }
        public List<SelectListItem> ListaWojewodztwa { get; set; }
        [Required(ErrorMessage = "Proszę podać ulicę!")]
        public string Ulica { get; set; }
        [Required(ErrorMessage = "Proszę podać numer!")]
        public string Numer { get; set; }

        public EditPlacowkiModel()
        {

        }

        public EditPlacowkiModel(string wojewodztwo, string godzinaOd, string godzinaDo)
        {
            this.ListaWojewodztwa = InitWojewodztwa(wojewodztwo);
            this.ListaGodzOd = InitGodzinyOd(godzinaOd);
            this.ListaGodzDo = InitGodzinyDo(godzinaDo);

        }

        private List<SelectListItem> InitGodzinyDo(string godzinaDo)
        {
            List<SelectListItem> lista = new List<SelectListItem>()
           {
               new SelectListItem(){Value = "6.00", Text = "6.00"},
               new SelectListItem(){Value = "7.00", Text = "7.00"},
               new SelectListItem(){Value = "8.00", Text = "8.00"},
               new SelectListItem(){Value = "9.00", Text = "9.00"},
               new SelectListItem(){Value = "10.00", Text = "10.00"},
               new SelectListItem(){Value = "11.00", Text = "11.00"},
               new SelectListItem(){Value = "12.00", Text = "12.00"},
               new SelectListItem(){Value = "13.00", Text = "13.00"},
               new SelectListItem(){Value = "14.00", Text = "14.00"},
               new SelectListItem(){Value = "15.00", Text = "15.00"},
               new SelectListItem(){Value = "16.00", Text = "16.00"},
               new SelectListItem(){Value = "17.00", Text = "17.00"},
               new SelectListItem(){Value = "18.00", Text = "18.00"},
               new SelectListItem(){Value = "19.00", Text = "19.00"},
               new SelectListItem(){Value = "20.00", Text = "20.00"},
               new SelectListItem(){Value = "21.00", Text = "21.00"},
               new SelectListItem(){Value = "22.00", Text = "22.00"},
               new SelectListItem(){Value = "23.00", Text = "23.00"},
            };
            List<SelectListItem> nowa = new List<SelectListItem>();
            foreach (var item in lista)
            {
                nowa.Add(new SelectListItem() { Value = item.Value, Text = item.Text, Selected = item.Text == godzinaDo });
            }
            return nowa;
        }

        private List<SelectListItem> InitGodzinyOd(string godzinaOd)
        {
            List<SelectListItem> lista = new List<SelectListItem>()
           {
               new SelectListItem(){Value = "6.00", Text = "6.00"},
               new SelectListItem(){Value = "7.00", Text = "7.00"},
               new SelectListItem(){Value = "8.00", Text = "8.00"},
               new SelectListItem(){Value = "9.00", Text = "9.00"},
               new SelectListItem(){Value = "10.00", Text = "10.00"},
               new SelectListItem(){Value = "11.00", Text = "11.00"},
               new SelectListItem(){Value = "12.00", Text = "12.00"},
               new SelectListItem(){Value = "13.00", Text = "13.00"},
               new SelectListItem(){Value = "14.00", Text = "14.00"},
               new SelectListItem(){Value = "15.00", Text = "15.00"},
               new SelectListItem(){Value = "16.00", Text = "16.00"},
               new SelectListItem(){Value = "17.00", Text = "17.00"},
               new SelectListItem(){Value = "18.00", Text = "18.00"},
               new SelectListItem(){Value = "19.00", Text = "19.00"},
               new SelectListItem(){Value = "20.00", Text = "20.00"},
               new SelectListItem(){Value = "21.00", Text = "21.00"},
               new SelectListItem(){Value = "22.00", Text = "22.00"},
               new SelectListItem(){Value = "23.00", Text = "23.00"},
            };
            List<SelectListItem> nowa = new List<SelectListItem>();
            foreach (var item in lista)
            {
                nowa.Add(new SelectListItem() { Value = item.Value, Text = item.Text, Selected = item.Text == godzinaOd });
            }
            return nowa;
        }



        private List<SelectListItem> InitWojewodztwa(string wojewodztwo)
        {
            List<SelectListItem> lista = new List<SelectListItem>
            {
                new SelectListItem() { Value = "Dolnośląskie", Text = "Dolnośląskie" },
                new SelectListItem() { Value = "Kujawsko-Pomorskie", Text = "Kujawsko-Pomorskie" },
                new SelectListItem() { Value = "Lubelskie", Text = "Lubelskie" },
                new SelectListItem() { Value = "Lubuskie", Text = "Lubuskie" },
                new SelectListItem() { Value = "Łódzkie", Text = "Łódzkie" },
                new SelectListItem() { Value = "Małopolskie", Text = "Małopolskie" },
                new SelectListItem() { Value = "Mazowieckie", Text = "Mazowieckie" },
                new SelectListItem() { Value = "Opolskie", Text = "Opolskie" },
                new SelectListItem() { Value = "Podkarpackie", Text = "Podkarpackie" },
                new SelectListItem() { Value = "Podlaskie", Text = "Podlaskie" },
                new SelectListItem() { Value = "Pomorskiem", Text = "Pomorskiem" },
                new SelectListItem() { Value = "Śląskie", Text = "Śląskie" },
                new SelectListItem() { Value = "Świętokrzyskie", Text = "Świętokrzyskie" },
                new SelectListItem() { Value = "Warmińsko-Mazurskie", Text = "Warmińsko-Mazurskie" },
                new SelectListItem() { Value = "Wielkopolskie", Text = "Wielkopolskie" },
                new SelectListItem() { Value = "Zachodniopomorskie", Text = "Zachodniopomorskie" }
            };

            List<SelectListItem> nowa = new List<SelectListItem>();
            foreach (var item in lista)
            {
                nowa.Add(new SelectListItem() { Value = item.Value, Text = item.Text, Selected = item.Text == wojewodztwo });
            }
            return nowa;
        }
    }
    #endregion

    #region ListaZabiegówModel
    public class ListaZabiegow
    {
        public int ZabiegID { get; set; }

        public string Zabieg { get; set; }

        public string Kategoria { get; set; }

        public int Cena { get; set; }
    }
    #endregion

    #region ZabiegiModel
    public class ZabiegiModel
    {
        public int ZabiegID { get; set; }

        public string Zabieg { get; set; }
        public List<SelectListItem> ListaZabiegi { get; set; }

        public ZabiegiModel()
        {
            this.ListaZabiegi = InitZabiegi();
        }

        private List<SelectListItem> InitZabiegi()
        {
            Metody client = new Metody();
            List<SelectListItem> lista = new List<SelectListItem>();

            var model = client.GetCennikList();

            foreach (var item in model)
            {
                lista.Add(new SelectListItem() { Value = item.Zabieg + " " + item.Cena.ToString(), Text = item.Zabieg + " " + item.Kategoria, });
            }

            return lista;
        }
    }
    #endregion

    #region DodajZabiegModel
    public class DodajZabiegModel
    {
        public int ZabiegID { get; set; }

        public string Zabieg { get; set; }

        public string Kategoria { get; set; }
        public List<SelectListItem> ListKategorie { get; set; }

        public string Placowki { get; set; }
        public List<SelectListItem> ListPlacowki { get; set; }

        public int Cena { get; set; }

        public DodajZabiegModel()
        {
            this.ListKategorie = InitKategorie();
            this.ListPlacowki = InitPlacowki();
        }

        private List<SelectListItem> InitPlacowki()
        {
            Metody client = new Metody();
            List<SelectListItem> lista = new List<SelectListItem>();
            var model = client.GetPlacowkaList();

            foreach (var item in model)
            {
                lista.Add(new SelectListItem() { Value = item.PlacowkaID.ToString(), Text = item.Nazwa });
            }
            return lista;
        }

        private List<SelectListItem> InitKategorie()
        {
            List<SelectListItem> lista = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "Stomatologia", Text = "Stomatologia"},
                new SelectListItem(){Value = "Ortodoncja", Text = "Ortodoncja"},
                new SelectListItem(){Value = "Protetyka", Text = "Protetyka"}
            };
            return lista;
        }
    }

    #endregion

    #region EditZabiegModel
    public class EditZabiegModel
    {
        public int ZabiegID { get; set; }

        public string Zabieg { get; set; }

        public string Kategoria { get; set; }
        public List<SelectListItem> ListKategorie { get; set; }

        public int Cena { get; set; }

        public EditZabiegModel()
        {

        }

        public EditZabiegModel(string kategoria)
        {
            this.ListKategorie = InitKategorie(kategoria);
        }

        private List<SelectListItem> InitKategorie(string kategoria)
        {
            List<SelectListItem> lista = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "Stomatologia", Text = "Stomatologia"},
                new SelectListItem(){Value = "Ortodoncja", Text = "Ortodoncja"},
                new SelectListItem(){Value = "Protetyka", Text = "Protetyka"}
            };

            List<SelectListItem> nowa = new List<SelectListItem>();
            foreach (var item in lista)
            {
                nowa.Add(new SelectListItem() { Value = item.Value, Text = item.Text, Selected = item.Text == kategoria });
            }
            return lista;
        }
    }
    #endregion

    #region DodajWizyteModel
    public class DodajWizyteModel
    {
        public int WizytaID { get; set; }

        public string Miasto { get; set; }
        public List<SelectListItem> ListaMiast { get; set; }

        public string GabinetID { get; set; }
        public List<SelectListItem> ListaGabinetow { get; set; }

        public string Data { get; set; }

        public string Godzina { get; set; }
        public List<SelectListItem> ListaGodzin { get; set; }

        public string Typ { get; set; }
        public List<SelectListItem> ListaTypy { get; set; }
        public string Stan { get; set; } = "Zaplanowana";

        public string Rodzaj { get; set; }
        public List<SelectListItem> ListaRodzajow { get; set; }

        public string Uwagi { get; set; }

        public DodajWizyteModel()
        {
            this.ListaMiast = InitMiasta();
            this.ListaRodzajow = InitRodzaj();
            this.ListaTypy = InitTypy();
        }
        public DodajWizyteModel(string miasto)
        {
            this.ListaGabinetow = InitGabinety(miasto);
            this.ListaTypy = InitTypy();
            this.ListaRodzajow = InitRodzaj();
            this.ListaMiast = InitMiasta();
        }

        private List<SelectListItem> InitGabinety(string miasto)
        {
            Metody client = new Metody();
            List<SelectListItem> lista = new List<SelectListItem>();
            var placowka = client.GetPlacowkaList();
            var wynik = client.GetAdresPlacowkaList().Where(a => a.Miasto == miasto).ToList();
            foreach (var pl in placowka)
            {
                foreach (var adr in wynik)
                {
                    if (pl.PlacowkaID == adr.AdresID)
                    {
                        lista.Add(new SelectListItem() { Value = pl.PlacowkaID.ToString(), Text = pl.Nazwa });
                    }
                }
            }
            return lista;
        }

        private List<SelectListItem> InitMiasta()
        {
            Metody client = new Metody();
            List<SelectListItem> lista = new List<SelectListItem>();
            var model = client.GetAdresPlacowkaList().Select(a => a.Miasto).Distinct();

            foreach (var item in model)
            {
                lista.Add(new SelectListItem() { Value = item.ToString(), Text = item.ToString() });
            }
            return lista;
        }

        private List<SelectListItem> InitRodzaj()
        {
            List<SelectListItem> lista = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "Pierwsza wizyta", Text= "Pierwsza wizyta"},
                new SelectListItem() {Value = "Wizyta stomatologiczna", Text= "Wizyta stomatologiczna"},
            };
            return lista;
        }
        private List<SelectListItem> InitTypy()
        {
            List<SelectListItem> lista = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "Wizyta prywatna", Text= "Wizyta prywatna"},
                new SelectListItem() {Value = "Wizyta NFZ", Text= "Wizyta NFZ"},
            };
            return lista;
        }
    }
    #endregion

    #region LekarzePartialModel
    public class LekarzeModel
    {
        public string LekarzID { get; set; }
        public List<SelectListItem> ListaLekarzy { get; set; }
        public LekarzeModel()
        {

        }

        public LekarzeModel(string gabinet)
        {
            this.ListaLekarzy = InitLekarz(gabinet);
        }

        private List<SelectListItem> InitLekarz(string gabinet)
        {
            try
            {
                Metody client = new Metody();
                List<SelectListItem> lista = new List<SelectListItem>();
                var personel = client.GetPesonelList();
                var wynik = personel.Where(a => a.Typ == "Personel" && a.Specjalizacja != "Brak");
                var filter = wynik.Where(a => a.Specjalizacja != "Pielęgniarka");
                foreach (var item in filter)
                {
                    if (item.Placowka == Convert.ToInt32(gabinet))
                    {
                        lista.Add(new SelectListItem() { Value = item.PersonelID.ToString(), Text = item.Imie + " " + item.Nazwisko });
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                List<SelectListItem> lista = new List<SelectListItem>()
                {
                    new SelectListItem() {Value = ex.ToString(), Text = "Błąd! Powtórz" }
                };
                Console.WriteLine(ex.Message);
                return lista;
            }

        }
    }
    #endregion

    #region WizytaGodzinaModel
    public class WizytaGodzinaModel
    {
        public string Godzina { get; set; }
        public List<SelectListItem> ListaGodzin { get; set; }

        public WizytaGodzinaModel(string data, int lekarz, string name)
        {
            this.ListaGodzin = InitGodziny(data, lekarz, name);
        }

        private List<SelectListItem> InitGodziny(string data, int lekarz, string placowkaID)
        {
            Metody client = new Metody();
            List<SelectListItem> lista = new List<SelectListItem>();
            List<string> lista2 = new List<string>();

            var gabinet = client.GetPlacowkaByID(Convert.ToInt32(placowkaID));
            if (gabinet.GodzOd.Length == 5)
            {
                string gabinetString = gabinet.GodzOd.Substring(0, 2);
                int godzinaOD = Convert.ToInt32(gabinetString);


                if (gabinet.GodzDo.Length == 5)
                {
                    string gabinetString2 = gabinet.GodzDo.Substring(0, 2);
                    int godzinaDo = Convert.ToInt32(gabinetString2);

                    var daty = client.GetWizytaByDateAndDoctor(data, lekarz);

                    List<int> godziny = new List<int>()
                        {
                             6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23
                         };

                    if (daty.Count() != 0)
                    {
                        foreach (var item in godziny)
                        {
                            if (item >= godzinaOD && item <= godzinaDo)
                            {
                                lista2.Add(item.ToString());
                            }
                        }

                        foreach (var item2 in daty)
                        {
                            foreach (string i in lista2.ToList())
                            {
                                if (item2.Godzina.Length == 5)
                                {
                                    if (item2.Godzina.Substring(0, 2) == i.ToString())

                                    {
                                        lista2.Remove(i);
                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {
                                    if (item2.Godzina.Substring(0, 1) == i.ToString())

                                    {
                                        lista2.Remove(i);
                                    }
                                    else
                                    {

                                    }
                                }

                            }
                        }

                        foreach (var id in lista2)
                        {
                            if (id.Length == 2)
                            {
                                lista.Add(new SelectListItem() { Value = id + ":00", Text = id + ":00" });
                            }
                            else
                            {
                                lista.Add(new SelectListItem() { Value = "0" + id + ":00", Text = id + ":00" });
                            }

                        }
                    }
                    else
                    {
                        foreach (var item2 in godziny)
                        {
                            if (item2 >= godzinaOD && item2 <= godzinaDo)
                            {
                                if (item2.ToString().Length == 2)
                                {
                                    lista.Add(new SelectListItem() { Value = item2.ToString() + ":00", Text = item2.ToString() + ":00" });
                                }
                                else
                                {
                                    lista.Add(new SelectListItem() { Value = "0" + item2.ToString() + ":00", Text = "0" + item2.ToString() + ":00" });
                                }
                            }

                        }
                    }
                }
                else
                {
                    string gabinetString2 = gabinet.GodzDo.Substring(0, 1);
                    int godzinaDo = Convert.ToInt32(gabinetString2);

                    var daty = client.GetWizytaByDateAndDoctor(data, lekarz);

                    List<int> godziny = new List<int>()
                        {
                             6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23
                          };


                    if (daty.Count() != 0)
                    {
                        foreach (var item in godziny)
                        {
                            if (item >= godzinaOD && item <= godzinaDo)
                            {
                                lista2.Add(item.ToString());
                            }
                        }

                        foreach (var item2 in daty)
                        {
                            foreach (string i in lista2.ToList())
                            {
                                if (item2.Godzina.Length == 5)
                                {
                                    if (item2.Godzina.Substring(0, 2) == i.ToString())

                                    {
                                        lista2.Remove(i);
                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {
                                    if (item2.Godzina.Substring(0, 1) == i.ToString())

                                    {
                                        lista2.Remove(i);
                                    }
                                    else
                                    {

                                    }
                                }

                            }
                        }

                        foreach (var id in lista2)
                        {
                            if (id.Length == 2)
                            {
                                lista.Add(new SelectListItem() { Value = id + ":00", Text = id + ":00" });
                            }
                            else
                            {
                                lista.Add(new SelectListItem() { Value = "0" + id + ":00", Text = id + ":00" });
                            }
                        }
                    }
                    else
                    {
                        foreach (var item2 in godziny)
                        {
                            if (item2.ToString().Length == 2)
                            {
                                lista.Add(new SelectListItem() { Value = item2.ToString() + ":00", Text = item2.ToString() + ":00" });
                            }
                            else
                            {
                                lista.Add(new SelectListItem() { Value = "0" + item2.ToString() + ":00", Text = "0" + item2.ToString() + ":00" });
                            }
                        }
                    }

                }
            }
            else
            {
                string gabinetString = gabinet.GodzOd.Substring(0, 1);
                int godzinaOD = Convert.ToInt32(gabinetString);


                if (gabinet.GodzDo.Length == 5)
                {
                    string gabinetString2 = gabinet.GodzDo.Substring(0, 2);
                    int godzinaDo = Convert.ToInt32(gabinetString2);

                    var daty = client.GetWizytaByDateAndDoctor(data, lekarz);

                    List<int> godziny = new List<int>()
                         {
                              6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23
                          };

                    if (daty.Count() != 0)
                    {

                        foreach (var item in godziny)
                        {
                            if (item >= godzinaOD && item <= godzinaDo)
                            {
                                lista2.Add(item.ToString());
                            }
                        }

                        foreach (var item2 in daty)
                        {
                            foreach (string i in lista2.ToList())
                            {
                                if (item2.Godzina.Length == 5)
                                {
                                    if (item2.Godzina.Substring(0, 2) == i.ToString())

                                    {
                                        lista2.Remove(i);
                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {
                                    if (item2.Godzina.Substring(0, 1) == i.ToString())

                                    {
                                        lista2.Remove(i);
                                    }
                                    else
                                    {

                                    }
                                }

                            }
                        }

                        foreach (var id in lista2)
                        {
                            if (id.Length == 2)
                            {
                                lista.Add(new SelectListItem() { Value = id + ":00", Text = id + ":00" });
                            }
                            else
                            {
                                lista.Add(new SelectListItem() { Value = "0" + id + ":00", Text = id + ":00" });
                            }
                        }

                    }
                    else
                    {
                        foreach (var item2 in godziny)
                        {
                            if (item2 >= godzinaOD && item2 <= godzinaDo)
                            {
                                if (item2.ToString().Length == 2)
                                {
                                    lista.Add(new SelectListItem() { Value = item2.ToString() + ":00", Text = item2.ToString() + ":00" });
                                }
                                else
                                {
                                    lista.Add(new SelectListItem() { Value = "0" + item2.ToString() + ":00", Text = "0" + item2.ToString() + ":00" });
                                };
                            }

                        }
                    }
                }
                else
                {
                    string gabinetString2 = gabinet.GodzDo.Substring(0, 1);
                    int godzinaDo = Convert.ToInt32(gabinetString2);

                    var daty = client.GetWizytaByDateAndDoctor(data, lekarz);
                    List<int> godziny = new List<int>()
                          {
                             6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23
                          };

                    if (daty.Count() != 0)
                    {
                        foreach (var item in godziny)
                        {
                            if (item >= godzinaOD && item <= godzinaDo)
                            {
                                lista2.Add(item.ToString());
                            }
                        }

                        foreach (var item2 in daty)
                        {
                            foreach (string i in lista2.ToList())
                            {
                                if (item2.Godzina.Length == 5)
                                {
                                    if (item2.Godzina.Substring(0, 2) == i.ToString())

                                    {
                                        lista2.Remove(i);
                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {
                                    if (item2.Godzina.Substring(0, 1) == i.ToString())

                                    {
                                        lista2.Remove(i);
                                    }
                                    else
                                    {

                                    }
                                }

                            }
                        }

                        foreach (var id in lista2)
                        {
                            if (id.Length == 2)
                            {
                                lista.Add(new SelectListItem() { Value = id + ":00", Text = id + ":00" });
                            }
                            else
                            {
                                lista.Add(new SelectListItem() { Value = "0" + id + ":00", Text = id + ":00" });
                            }
                        }
                    }
                    else
                    {
                        foreach (var item2 in godziny)
                        {
                            if (item2.ToString().Length == 2)
                            {
                                lista.Add(new SelectListItem() { Value = "0" + item2.ToString() + ":00", Text = item2.ToString() + ":00" });
                            }
                            else
                            {
                                lista.Add(new SelectListItem() { Value = "0" + item2.ToString() + ":00", Text = "0" + item2.ToString() + ":00" });
                            }
                        }
                    }
                }
            }
            return lista;
        }
    }
    #endregion

    #region KontaktModel
    public class KontaktModel
    {
        public string Miasto { get; set; }
        public List<SelectListItem> ListaMiast { get; set; }

        public KontaktModel()
        {
            this.ListaMiast = InitMiasta();
        }

        private List<SelectListItem> InitMiasta()
        {
            Metody client = new Metody();
            List<SelectListItem> lista = new List<SelectListItem>();
            var model = client.GetAdresPlacowkaList().Select(a => a.Miasto).Distinct();

            foreach (var item in model)
            {
                lista.Add(new SelectListItem() { Value = item.ToString(), Text = item.ToString() });
            }
            return lista;
        }
    }
    #endregion

    #region ListaMiastaModel
    public class ListaMiastModel
    {
        public string Nazwa { get; set; }

        public int Telefon { get; set; }

        public string Email { get; set; }

        public string GodzOd { get; set; }

        public string GodzDo { get; set; }

        public string Miasto { get; set; }

        public string Wojewodztwo { get; set; }

        public string Ulica { get; set; }

        public string Numer { get; set; }
    }
    #endregion

    #region CennikModel
    public class CennikModel
    {
        public string Zabieg { get; set; }

        public string Kategoria { get; set; }
        public List<SelectListItem> ListaKategorie { get; set; }

        public int Cena { get; set; }

        public CennikModel()
        {
            this.ListaKategorie = InitKategorie();
        }

        private List<SelectListItem> InitKategorie()
        {
            List<SelectListItem> lista = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "Stomatologia", Text = "Stomatologia"},
                new SelectListItem(){Value = "Ortodoncja", Text = "Ortodoncja"},
                new SelectListItem(){Value = "Protetyka", Text = "Protetyka"}
            };
            return lista;
        }
    }
    #endregion

    #region ListaWizytModel
    public class ListaWizytModel
    {
        public int WizytaID { get; set; }

        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public string PESEL { get; set; }

        public string Godzina { get; set; }

        public string Stan { get; set; }

        public int Cena { get; set; } = 0;

        public string Uwagi { get; set; }

        public DateTime DataUrodzin { get; set; }
    }
    #endregion

    #region NowaWizytaModel
    public class NowaWizytaModel
    {

        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public int Telefon { get; set; }

        public string Data { get; set; }

        public string Miasto { get; set; }
        public List<SelectListItem> ListaMiast { get; set; }

        public string LekarzID { get; set; }
        public List<SelectListItem> ListaLekarzy { get; set; }

        public string GabinetID { get; set; }
        public List<SelectListItem> ListaGabinetow { get; set; }

        public string Godzina { get; set; }
        public List<SelectListItem> ListaGodzin { get; set; }

        public string Typ { get; set; }
        public List<SelectListItem> ListaTypy { get; set; }
        public string Stan { get; set; } = "Zaplanowana";

        public string Rodzaj { get; set; }
        public List<SelectListItem> ListaRodzajow { get; set; }

        public int Cena { get; set; } = 0;

        public string Uwagi { get; set; }

        public NowaWizytaModel()
        {
            this.ListaMiast = InitMiasta();
            this.ListaTypy = InitTypy();
            this.ListaRodzajow = InitRodzaj();
        }

        public NowaWizytaModel(string miasto)
        {
            this.ListaGabinetow = InitGabinety(miasto);
            this.ListaTypy = InitTypy();
            this.ListaRodzajow = InitRodzaj();
        }

        public NowaWizytaModel(string data, int lekarz, string name, string gabinet, string miasto)
        {
            this.ListaMiast = InitMiasta();
            this.ListaGodzin = InitGodziny(data, lekarz, name);
            this.ListaLekarzy = InitLekarz(gabinet);
            this.ListaGabinetow = InitGabinety(miasto);
            this.ListaTypy = InitTypy();
            this.ListaRodzajow = InitRodzaj();
        }

        private List<SelectListItem> InitRodzaj()
        {
            List<SelectListItem> lista = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "Pierwsza wizyta", Text= "Pierwsza wizyta"},
                new SelectListItem() {Value = "Wizyta stomatologiczna", Text= "Wizyta stomatologiczna"},
            };
            return lista;
        }
        private List<SelectListItem> InitTypy()
        {
            List<SelectListItem> lista = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "Wizyta prywatna", Text= "Wizyta prywatna"},
                new SelectListItem() {Value = "Wizyta NFZ", Text= "Wizyta NFZ"},
            };
            return lista;
        }

        private List<SelectListItem> InitGabinety(string miasto)
        {
            Metody client = new Metody();
            List<SelectListItem> lista = new List<SelectListItem>();
            var placowka = client.GetPlacowkaList();
            var wynik = client.GetAdresPlacowkaList().Where(a => a.Miasto == miasto).ToList();
            foreach (var pl in placowka)
            {
                foreach (var adr in wynik)
                {
                    if (pl.PlacowkaID == adr.AdresID)
                    {
                        lista.Add(new SelectListItem() { Value = pl.PlacowkaID.ToString(), Text = pl.Nazwa });
                    }
                }
            }
            return lista;
        }

        private List<SelectListItem> InitLekarz(string gabinet)
        {
            try
            {
                Metody client = new Metody();
                List<SelectListItem> lista = new List<SelectListItem>();
                var personel = client.GetPesonelList();
                var wynik = personel.Where(a => a.Typ == "Personel" && a.Specjalizacja != "Brak");
                var filter = wynik.Where(a => a.Specjalizacja != "Pielęgniarka");
                foreach (var item in filter)
                {
                    if (item.Placowka == Convert.ToInt32(gabinet))
                    {
                        lista.Add(new SelectListItem() { Value = item.PersonelID.ToString(), Text = item.Imie + " " + item.Nazwisko });
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                List<SelectListItem> lista = new List<SelectListItem>()
                {
                    new SelectListItem() {Value = ex.ToString(), Text = "Błąd! Powtórz" }
                };
                Console.WriteLine(ex.Message);
                return lista;
            }

        }

        private List<SelectListItem> InitMiasta()
        {
            Metody client = new Metody();
            List<SelectListItem> lista = new List<SelectListItem>();
            var model = client.GetAdresPlacowkaList().Select(a => a.Miasto).Distinct();

            foreach (var item in model)
            {
                lista.Add(new SelectListItem() { Value = item.ToString(), Text = item.ToString() });
            }
            return lista;
        }

        private List<SelectListItem> InitGodziny(string data, int lekarz, string placowkaID)
        {
            Metody client = new Metody();
            List<SelectListItem> lista = new List<SelectListItem>();
            List<string> lista2 = new List<string>();

            var gabinet = client.GetPlacowkaByID(Convert.ToInt32(placowkaID));
            if (gabinet.GodzOd.Length == 5)
            {
                string gabinetString = gabinet.GodzOd.Substring(0, 2);
                int godzinaOD = Convert.ToInt32(gabinetString);


                if (gabinet.GodzDo.Length == 5)
                {
                    string gabinetString2 = gabinet.GodzDo.Substring(0, 2);
                    int godzinaDo = Convert.ToInt32(gabinetString2);

                    var daty = client.GetWizytaByDateAndDoctor(data, lekarz);

                    List<int> godziny = new List<int>()
                        {
                             6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23
                         };

                    if (daty.Count() != 0)
                    {
                        foreach (var item in godziny)
                        {
                            if (item >= godzinaOD && item <= godzinaDo)
                            {
                                lista2.Add(item.ToString());
                            }
                        }

                        foreach (var item2 in daty)
                        {
                            foreach (string i in lista2.ToList())
                            {
                                if (item2.Godzina.Length == 5)
                                {
                                    if (item2.Godzina.Substring(0, 2) == i.ToString())

                                    {
                                        lista2.Remove(i);
                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {
                                    if (item2.Godzina.Substring(0, 1) == i.ToString())

                                    {
                                        lista2.Remove(i);
                                    }
                                    else
                                    {

                                    }
                                }

                            }
                        }

                        foreach (var id in lista2)
                        {
                            lista.Add(new SelectListItem() { Value = id + ":00", Text = id + ":00" });
                        }
                    }
                    else
                    {
                        foreach (var item2 in godziny)
                        {
                            if (item2 >= godzinaOD && item2 <= godzinaDo)
                            {
                                lista.Add(new SelectListItem() { Value = item2.ToString() + ":00", Text = item2.ToString() + ":00" });
                            }

                        }
                    }
                }
                else
                {
                    string gabinetString2 = gabinet.GodzDo.Substring(0, 1);
                    int godzinaDo = Convert.ToInt32(gabinetString2);

                    var daty = client.GetWizytaByDateAndDoctor(data, lekarz);

                    List<int> godziny = new List<int>()
                        {
                             6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23
                          };


                    if (daty.Count() != 0)
                    {
                        foreach (var item in godziny)
                        {
                            if (item >= godzinaOD && item <= godzinaDo)
                            {
                                lista2.Add(item.ToString());
                            }
                        }

                        foreach (var item2 in daty)
                        {
                            foreach (string i in lista2.ToList())
                            {
                                if (item2.Godzina.Length == 5)
                                {
                                    if (item2.Godzina.Substring(0, 2) == i.ToString())

                                    {
                                        lista2.Remove(i);
                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {
                                    if (item2.Godzina.Substring(0, 1) == i.ToString())

                                    {
                                        lista2.Remove(i);
                                    }
                                    else
                                    {

                                    }
                                }

                            }
                        }

                        foreach (var id in lista2)
                        {
                            lista.Add(new SelectListItem() { Value = id + ":00", Text = id + ":00" });
                        }
                    }
                    else
                    {
                        foreach (var item2 in godziny)
                        {
                            if (item2 >= godzinaOD && item2 <= godzinaDo)
                            {
                                lista.Add(new SelectListItem() { Value = item2.ToString() + ":00", Text = item2.ToString() + ":00" });
                            }

                        }
                    }

                }
            }
            else
            {
                string gabinetString = gabinet.GodzOd.Substring(0, 1);
                int godzinaOD = Convert.ToInt32(gabinetString);


                if (gabinet.GodzDo.Length == 5)
                {
                    string gabinetString2 = gabinet.GodzDo.Substring(0, 2);
                    int godzinaDo = Convert.ToInt32(gabinetString2);

                    var daty = client.GetWizytaByDateAndDoctor(data, lekarz);

                    List<int> godziny = new List<int>()
                         {
                              6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23
                          };

                    if (daty.Count() != 0)
                    {

                        foreach (var item in godziny)
                        {
                            if (item >= godzinaOD && item <= godzinaDo)
                            {
                                lista2.Add(item.ToString());
                            }
                        }

                        foreach (var item2 in daty)
                        {
                            foreach (string i in lista2.ToList())
                            {
                                if (item2.Godzina.Length == 5)
                                {
                                    if (item2.Godzina.Substring(0, 2) == i.ToString())

                                    {
                                        lista2.Remove(i);
                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {
                                    if (item2.Godzina.Substring(0, 1) == i.ToString())

                                    {
                                        lista2.Remove(i);
                                    }
                                    else
                                    {

                                    }
                                }

                            }
                        }

                        foreach (var id in lista2)
                        {
                            lista.Add(new SelectListItem() { Value = id + ":00", Text = id + ":00" });
                        }

                    }
                    else
                    {
                        foreach (var item2 in godziny)
                        {
                            if (item2 >= godzinaOD && item2 <= godzinaDo)
                            {
                                lista.Add(new SelectListItem() { Value = item2.ToString() + ":00", Text = item2.ToString() + ":00" });
                            }

                        }
                    }
                }
                else
                {
                    string gabinetString2 = gabinet.GodzDo.Substring(0, 1);
                    int godzinaDo = Convert.ToInt32(gabinetString2);

                    var daty = client.GetWizytaByDateAndDoctor(data, lekarz);
                    List<int> godziny = new List<int>()
                          {
                             6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23
                          };

                    if (daty.Count() != 0)
                    {
                        foreach (var item in godziny)
                        {
                            if (item >= godzinaOD && item <= godzinaDo)
                            {
                                lista2.Add(item.ToString());
                            }
                        }

                        foreach (var item2 in daty)
                        {
                            foreach (string i in lista2.ToList())
                            {
                                if (item2.Godzina.Length == 5)
                                {
                                    if (item2.Godzina.Substring(0, 2) == i.ToString())

                                    {
                                        lista2.Remove(i);
                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {
                                    if (item2.Godzina.Substring(0, 1) == i.ToString())

                                    {
                                        lista2.Remove(i);
                                    }
                                    else
                                    {

                                    }
                                }

                            }
                        }

                        foreach (var id in lista2)
                        {
                            lista.Add(new SelectListItem() { Value = id + ":00", Text = id + ":00" });
                        }
                    }
                    else
                    {
                        foreach (var item2 in godziny)
                        {
                            if (item2 >= godzinaOD && item2 <= godzinaDo)
                            {
                                lista.Add(new SelectListItem() { Value = item2.ToString() + ":00", Text = item2.ToString() + ":00" });
                            }

                        }
                    }
                }
            }
            return lista;
        }
        #endregion
    }
    #region SzybkaWizytaModel
    public class SzybkaWizytaModel
    {
        public int PacjentID { get; set; }

        public string Imie { get; set; }
        public List<SelectListItem> ListaImion { get; set; }

        public string Nazwisko { get; set; }
        public List<SelectListItem> ListaNazwisk { get; set; }

        public string Data { get; set; }

        public string Miasto { get; set; }
        public List<SelectListItem> ListaMiast { get; set; }

        public string LekarzID { get; set; }
        public List<SelectListItem> ListaLekarzy { get; set; }

        public string GabinetID { get; set; }
        public List<SelectListItem> ListaGabinetow { get; set; }

        public string Godzina { get; set; }
        public List<SelectListItem> ListaGodzin { get; set; }

        public string Typ { get; set; }
        public List<SelectListItem> ListaTypy { get; set; }
        public string Stan { get; set; } = "Zaplanowana";

        public string Rodzaj { get; set; }
        public List<SelectListItem> ListaRodzajow { get; set; }

        public int Cena { get; set; } = 0;

        public string Uwagi { get; set; }

        public SzybkaWizytaModel()
        {
            this.ListaMiast = InitMiasta();
            this.ListaTypy = InitTypy();
            this.ListaRodzajow = InitRodzaj();
        }

        public SzybkaWizytaModel(string miasto)
        {
            this.ListaGabinetow = InitGabinety(miasto);
            this.ListaTypy = InitTypy();
            this.ListaRodzajow = InitRodzaj();
        }

        public SzybkaWizytaModel(string data, int lekarz, string name, string gabinet, string miasto)
        {
            this.ListaMiast = InitMiasta();
            this.ListaGodzin = InitGodziny(data, lekarz, name);
            this.ListaLekarzy = InitLekarz(gabinet);
            this.ListaGabinetow = InitGabinety(miasto);
            this.ListaTypy = InitTypy();
            this.ListaRodzajow = InitRodzaj();
        }

        private List<SelectListItem> InitRodzaj()
        {
            List<SelectListItem> lista = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "Pierwsza wizyta", Text= "Pierwsza wizyta"},
                new SelectListItem() {Value = "Wizyta stomatologiczna", Text= "Wizyta stomatologiczna"},
            };
            return lista;
        }
        private List<SelectListItem> InitTypy()
        {
            List<SelectListItem> lista = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "Wizyta prywatna", Text= "Wizyta prywatna"},
                new SelectListItem() {Value = "Wizyta NFZ", Text= "Wizyta NFZ"},
            };
            return lista;
        }

        private List<SelectListItem> InitGabinety(string miasto)
        {
            Metody client = new Metody();
            List<SelectListItem> lista = new List<SelectListItem>();
            var placowka = client.GetPlacowkaList();
            var wynik = client.GetAdresPlacowkaList().Where(a => a.Miasto == miasto).ToList();
            foreach (var pl in placowka)
            {
                foreach (var adr in wynik)
                {
                    if (pl.PlacowkaID == adr.AdresID)
                    {
                        lista.Add(new SelectListItem() { Value = pl.PlacowkaID.ToString(), Text = pl.Nazwa });
                    }
                }
            }
            return lista;
        }

        private List<SelectListItem> InitLekarz(string gabinet)
        {
            try
            {
                Metody client = new Metody();
                List<SelectListItem> lista = new List<SelectListItem>();
                var personel = client.GetPesonelList();
                var wynik = personel.Where(a => a.Typ == "Personel" && a.Specjalizacja != "Brak");
                var filter = wynik.Where(a => a.Specjalizacja != "Pielęgniarka");
                foreach (var item in filter)
                {
                    if (item.Placowka == Convert.ToInt32(gabinet))
                    {
                        lista.Add(new SelectListItem() { Value = item.PersonelID.ToString(), Text = item.Imie + " " + item.Nazwisko });
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                List<SelectListItem> lista = new List<SelectListItem>()
                {
                    new SelectListItem() {Value = ex.ToString(), Text = "Błąd! Powtórz" }
                };
                Console.WriteLine(ex.Message);
                return lista;
            }

        }

        private List<SelectListItem> InitMiasta()
        {
            Metody client = new Metody();
            List<SelectListItem> lista = new List<SelectListItem>();
            var model = client.GetAdresPlacowkaList().Select(a => a.Miasto).Distinct();

            foreach (var item in model)
            {
                lista.Add(new SelectListItem() { Value = item.ToString(), Text = item.ToString() });
            }
            return lista;
        }

        private List<SelectListItem> InitGodziny(string data, int lekarz, string placowkaID)
        {
            Metody client = new Metody();
            List<SelectListItem> lista = new List<SelectListItem>();
            List<string> lista2 = new List<string>();

            var gabinet = client.GetPlacowkaByID(Convert.ToInt32(placowkaID));
            if (gabinet.GodzOd.Length == 5)
            {
                string gabinetString = gabinet.GodzOd.Substring(0, 2);
                int godzinaOD = Convert.ToInt32(gabinetString);


                if (gabinet.GodzDo.Length == 5)
                {
                    string gabinetString2 = gabinet.GodzDo.Substring(0, 2);
                    int godzinaDo = Convert.ToInt32(gabinetString2);

                    var daty = client.GetWizytaByDateAndDoctor(data, lekarz);

                    List<int> godziny = new List<int>()
                        {
                             6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23
                         };

                    if (daty.Count() != 0)
                    {
                        foreach (var item in godziny)
                        {
                            if (item >= godzinaOD && item <= godzinaDo)
                            {
                                lista2.Add(item.ToString());
                            }
                        }

                        foreach (var item2 in daty)
                        {
                            foreach (string i in lista2.ToList())
                            {
                                if (item2.Godzina.Length == 5)
                                {
                                    if (item2.Godzina.Substring(0, 2) == i.ToString())

                                    {
                                        lista2.Remove(i);
                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {
                                    if (item2.Godzina.Substring(0, 1) == i.ToString())

                                    {
                                        lista2.Remove(i);
                                    }
                                    else
                                    {

                                    }
                                }

                            }
                        }

                        foreach (var id in lista2)
                        {
                            lista.Add(new SelectListItem() { Value = id + ":00", Text = id + ":00" });
                        }
                    }
                    else
                    {
                        foreach (var item2 in godziny)
                        {
                            if (item2 >= godzinaOD && item2 <= godzinaDo)
                            {
                                lista.Add(new SelectListItem() { Value = item2.ToString() + ":00", Text = item2.ToString() + ":00" });
                            }

                        }
                    }
                }
                else
                {
                    string gabinetString2 = gabinet.GodzDo.Substring(0, 1);
                    int godzinaDo = Convert.ToInt32(gabinetString2);

                    var daty = client.GetWizytaByDateAndDoctor(data, lekarz);

                    List<int> godziny = new List<int>()
                        {
                             6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23
                          };


                    if (daty.Count() != 0)
                    {
                        foreach (var item in godziny)
                        {
                            if (item >= godzinaOD && item <= godzinaDo)
                            {
                                lista2.Add(item.ToString());
                            }
                        }

                        foreach (var item2 in daty)
                        {
                            foreach (string i in lista2.ToList())
                            {
                                if (item2.Godzina.Length == 5)
                                {
                                    if (item2.Godzina.Substring(0, 2) == i.ToString())

                                    {
                                        lista2.Remove(i);
                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {
                                    if (item2.Godzina.Substring(0, 1) == i.ToString())

                                    {
                                        lista2.Remove(i);
                                    }
                                    else
                                    {

                                    }
                                }

                            }
                        }

                        foreach (var id in lista2)
                        {
                            lista.Add(new SelectListItem() { Value = id + ":00", Text = id + ":00" });
                        }
                    }
                    else
                    {
                        foreach (var item2 in godziny)
                        {
                            if (item2 >= godzinaOD && item2 <= godzinaDo)
                            {
                                lista.Add(new SelectListItem() { Value = item2.ToString() + ":00", Text = item2.ToString() + ":00" });
                            }

                        }
                    }

                }
            }
            else
            {
                string gabinetString = gabinet.GodzOd.Substring(0, 1);
                int godzinaOD = Convert.ToInt32(gabinetString);


                if (gabinet.GodzDo.Length == 5)
                {
                    string gabinetString2 = gabinet.GodzDo.Substring(0, 2);
                    int godzinaDo = Convert.ToInt32(gabinetString2);

                    var daty = client.GetWizytaByDateAndDoctor(data, lekarz);

                    List<int> godziny = new List<int>()
                         {
                              6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23
                          };

                    if (daty.Count() != 0)
                    {

                        foreach (var item in godziny)
                        {
                            if (item >= godzinaOD && item <= godzinaDo)
                            {
                                lista2.Add(item.ToString());
                            }
                        }

                        foreach (var item2 in daty)
                        {
                            foreach (string i in lista2.ToList())
                            {
                                if (item2.Godzina.Length == 5)
                                {
                                    if (item2.Godzina.Substring(0, 2) == i.ToString())

                                    {
                                        lista2.Remove(i);
                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {
                                    if (item2.Godzina.Substring(0, 1) == i.ToString())

                                    {
                                        lista2.Remove(i);
                                    }
                                    else
                                    {

                                    }
                                }

                            }
                        }

                        foreach (var id in lista2)
                        {
                            lista.Add(new SelectListItem() { Value = id + ":00", Text = id + ":00" });
                        }

                    }
                    else
                    {
                        foreach (var item2 in godziny)
                        {
                            if (item2 >= godzinaOD && item2 <= godzinaDo)
                            {
                                lista.Add(new SelectListItem() { Value = item2.ToString() + ":00", Text = item2.ToString() + ":00" });
                            }

                        }
                    }
                }
                else
                {
                    string gabinetString2 = gabinet.GodzDo.Substring(0, 1);
                    int godzinaDo = Convert.ToInt32(gabinetString2);

                    var daty = client.GetWizytaByDateAndDoctor(data, lekarz);
                    List<int> godziny = new List<int>()
                          {
                             6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23
                          };

                    if (daty.Count() != 0)
                    {
                        foreach (var item in godziny)
                        {
                            if (item >= godzinaOD && item <= godzinaDo)
                            {
                                lista2.Add(item.ToString());
                            }
                        }

                        foreach (var item2 in daty)
                        {
                            foreach (string i in lista2.ToList())
                            {
                                if (item2.Godzina.Length == 5)
                                {
                                    if (item2.Godzina.Substring(0, 2) == i.ToString())

                                    {
                                        lista2.Remove(i);
                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {
                                    if (item2.Godzina.Substring(0, 1) == i.ToString())

                                    {
                                        lista2.Remove(i);
                                    }
                                    else
                                    {

                                    }
                                }

                            }
                        }

                        foreach (var id in lista2)
                        {
                            lista.Add(new SelectListItem() { Value = id + ":00", Text = id + ":00" });
                        }
                    }
                    else
                    {
                        foreach (var item2 in godziny)
                        {
                            if (item2 >= godzinaOD && item2 <= godzinaDo)
                            {
                                lista.Add(new SelectListItem() { Value = item2.ToString() + ":00", Text = item2.ToString() + ":00" });
                            }

                        }
                    }
                }
            }
            return lista;
        }
        #endregion
    }
    #region WizytaHistoria
    public class WizytaHistoria
    {

        public string Data { get; set; }

        public string Gabinet { get; set; }

        public string Godzina { get; set; }

        public string ImieLekarz { get; set; }

        public string NazwiskoLekarz { get; set; }

        public string Stan { get; set; }

    }
    #endregion

    #region ZebyModel
    public class ZebyModel
    {
        public int GL { get; set; }
        public List<SelectListItem> ListGL { get; set; }

        public int GP { get; set; }
        public List<SelectListItem> ListGP { get; set; }

        public int DL { get; set; }
        public List<SelectListItem> ListDL { get; set; }

        public int DP { get; set; }
        public List<SelectListItem> ListDP { get; set; }

        public ZebyModel()
        {
            this.ListGL = InitGL();
            this.ListGP = InitGP();
            this.ListDL = InitDL();
            this.ListDP = InitDP();
        }

        public ZebyModel(string kategoria, int id)
        {
            this.ListGL = InitGL(id, kategoria);
            this.ListGP = InitGP(id, kategoria);
            this.ListDL = InitDL(id, kategoria);
            this.ListDP = InitDP(id, kategoria);
        }

        private List<SelectListItem> InitDP()
        {
            Metody client = new Metody();
            List<SelectListItem> lista = new List<SelectListItem>();
            var model = client.GetZebyList().Where(a => a.Kategoria == "Stałe" && a.GD == "Dolne" && a.LP == "Prawa");

            foreach (var item in model)
            {
                lista.Add(new SelectListItem() { Value = item.Zab.ToString(), Text = item.Zab.ToString() });
            }

            return lista;
        }

        private List<SelectListItem> InitDL()
        {
            Metody client = new Metody();
            List<SelectListItem> lista = new List<SelectListItem>();
            var model = client.GetZebyList().Where(a => a.Kategoria == "Stałe" && a.GD == "Dolne" && a.LP == "Lewa");

            foreach (var item in model)
            {
                lista.Add(new SelectListItem() { Value = item.Zab.ToString(), Text = item.Zab.ToString() });
            }

            return lista;
        }

        private List<SelectListItem> InitGP()
        {
            Metody client = new Metody();
            List<SelectListItem> lista = new List<SelectListItem>();
            var model = client.GetZebyList().Where(a => a.Kategoria == "Stałe" && a.GD == "Górne" && a.LP == "Prawa");

            foreach (var item in model)
            {
                lista.Add(new SelectListItem() { Value = item.Zab.ToString(), Text = item.Zab.ToString() });
            }

            return lista;
        }

        private List<SelectListItem> InitGL()
        {
            Metody client = new Metody();
            List<SelectListItem> lista = new List<SelectListItem>();
            var model = client.GetZebyList().Where(a => a.Kategoria == "Stałe" && a.GD == "Górne" && a.LP == "Lewa");

            foreach (var item in model)
            {
                lista.Add(new SelectListItem() { Value = item.Zab.ToString(), Text = item.Zab.ToString() });
            }

            return lista;
        }

        private List<SelectListItem> InitDP(int id, string kategoria)
        {
            Metody client = new Metody();
            if (kategoria == "Stałe")
            {
                var zeby = client.GetBrakZebowByID(id);
                List<int> lista = new List<int>();
                var model = client.GetZebyList().Where(a => a.Kategoria == kategoria && a.GD == "Dolne" && a.LP == "Prawa");
                var implant = client.GetImplantByID(id).Where(a => a.GD == "Żuchwa" && a.LP == "Prawa");

                foreach (var item in model)
                {
                    lista.Add(item.Zab);
                }

                if (implant.Any() == true)
                {
                    List<SelectListItem> listaModel = new List<SelectListItem>();
                    foreach (var item in lista)
                    {
                        foreach (var item2 in implant)
                        {
                            if (item == item2.Zab)
                            {
                                listaModel.Add(new SelectListItem() { Value = item2.Zab.ToString(), Text = item2.Zab.ToString() + "Implant" });
                            }
                            else
                            {
                                listaModel.Add(new SelectListItem() { Value = item.ToString(), Text = item.ToString() });
                            }
                        }
                    }

                    return listaModel;
                }
                else
                {
                    List<SelectListItem> listaModel = new List<SelectListItem>();
                    foreach (var item in lista)
                    {
                        listaModel.Add(new SelectListItem() { Value = item.ToString(), Text = item.ToString() });
                    }
                    return listaModel;
                }
            }
            else
            {
                List<int> lista = new List<int>();
                var model = client.GetZebyList().Where(a => a.Kategoria == "Stałe" && a.GD == "Górne" && a.LP == "Lewa");

                foreach (var item in model)
                {
                    lista.Add(item.Zab);
                }

                List<SelectListItem> listaModel = new List<SelectListItem>();
                foreach (var item in lista)
                {
                    listaModel.Add(new SelectListItem() { Value = item.ToString(), Text = item.ToString() });
                }


                return listaModel;
            }
        }

        private List<SelectListItem> InitDL(int id, string kategoria)
        {
            Metody client = new Metody();
            if (kategoria == "Stałe")
            {
                var zeby = client.GetBrakZebowByID(id);
                List<int> lista = new List<int>();
                var model = client.GetZebyList().Where(a => a.Kategoria == kategoria && a.GD == "Dolne" && a.LP == "Lewa");
                var implant = client.GetImplantByID(id).Where(a => a.GD == "Żuchwa" && a.LP == "Lewa");

                foreach (var item in model)
                {
                    lista.Add(item.Zab);
                }

                if (implant.Any() == true)
                {
                    List<SelectListItem> listaModel = new List<SelectListItem>();
                    foreach (var item in lista)
                    {
                        foreach (var item2 in implant)
                        {
                            if (item == item2.Zab)
                            {
                                listaModel.Add(new SelectListItem() { Value = item2.Zab.ToString(), Text = item2.Zab.ToString() + "Implant" });
                            }
                            else
                            {
                                listaModel.Add(new SelectListItem() { Value = item.ToString(), Text = item.ToString() });
                            }
                        }
                    }

                    return listaModel;
                }
                else
                {
                    List<SelectListItem> listaModel = new List<SelectListItem>();
                    foreach (var item in lista)
                    {
                        listaModel.Add(new SelectListItem() { Value = item.ToString(), Text = item.ToString() });
                    }
                    return listaModel;
                }

            }
            else
            {
                List<int> lista = new List<int>();
                var model = client.GetZebyList().Where(a => a.Kategoria == "Stałe" && a.GD == "Górne" && a.LP == "Lewa");

                foreach (var item in model)
                {
                    lista.Add(item.Zab);
                }

                List<SelectListItem> listaModel = new List<SelectListItem>();
                foreach (var item in lista)
                {
                    listaModel.Add(new SelectListItem() { Value = item.ToString(), Text = item.ToString() });
                }


                return listaModel;
            }
        }

        private List<SelectListItem> InitGP(int id, string kategoria)
        {
            Metody client = new Metody();
            if (kategoria == "Stałe")
            {
                var zeby = client.GetBrakZebowByID(id);
                List<int> lista = new List<int>();
                var model = client.GetZebyList().Where(a => a.Kategoria == kategoria && a.GD == "Górne" && a.LP == "Prawa");
                var implant = client.GetImplantByID(id).Where(a => a.GD == "Szczęka" && a.LP == "Prawa");

                foreach (var item in model)
                {
                    lista.Add(item.Zab);
                }

                if (implant.Any() == true)
                {
                    List<SelectListItem> listaModel = new List<SelectListItem>();
                    foreach (var item in lista)
                    {
                        foreach (var item2 in implant)
                        {
                            if (item == item2.Zab)
                            {
                                listaModel.Add(new SelectListItem() { Value = item2.Zab.ToString(), Text = item2.Zab.ToString() + "Implant" });
                            }
                            else
                            {
                                listaModel.Add(new SelectListItem() { Value = item.ToString(), Text = item.ToString() });
                            }
                        }
                    }
                    return listaModel;
                }
                else
                {
                    List<SelectListItem> listaModel = new List<SelectListItem>();
                    foreach (var item in lista)
                    {
                        listaModel.Add(new SelectListItem() { Value = item.ToString(), Text = item.ToString() });
                    }
                    return listaModel;
                }

            }
            else
            {
                List<int> lista = new List<int>();
                var model = client.GetZebyList().Where(a => a.Kategoria == "Stałe" && a.GD == "Górne" && a.LP == "Lewa");

                foreach (var item in model)
                {
                    lista.Add(item.Zab);
                }

                List<SelectListItem> listaModel = new List<SelectListItem>();
                foreach (var item in lista)
                {
                    listaModel.Add(new SelectListItem() { Value = item.ToString(), Text = item.ToString() });
                }


                return listaModel;
            }
        }

        private List<SelectListItem> InitGL(int id, string kategoria)
        {
            Metody client = new Metody();
            if (kategoria == "Stałe")
            {
                var zeby = client.GetBrakZebowByID(id);
                List<int> lista = new List<int>();
                var model = client.GetZebyList().Where(a => a.Kategoria == kategoria && a.GD == "Górne" && a.LP == "Lewa");
                var implant = client.GetImplantByID(id).Where(a => a.GD == "Szczęka" && a.LP == "Lewa");

                foreach (var item in model)
                {
                    lista.Add(item.Zab);
                }

                if (implant.Any() == true)
                {
                    List<SelectListItem> listaModel = new List<SelectListItem>();
                    foreach (var item in lista)
                    {
                        foreach (var item2 in implant)
                        {
                            if (item == item2.Zab)
                            {
                                listaModel.Add(new SelectListItem() { Value = item2.Zab.ToString(), Text = item2.Zab.ToString() + " Implant" });
                            }
                            else
                            {
                                listaModel.Add(new SelectListItem() { Value = item.ToString(), Text = item.ToString() });
                            }
                        }

                    }

                    return listaModel;
                }
                else
                {
                    List<SelectListItem> listaModel = new List<SelectListItem>();
                    foreach (var item in lista)
                    {
                        listaModel.Add(new SelectListItem() { Value = item.ToString(), Text = item.ToString() });
                    }
                    return listaModel;
                }

            }
            else
            {
                List<int> lista = new List<int>();
                var model = client.GetZebyList().Where(a => a.Kategoria == "Stałe" && a.GD == "Górne" && a.LP == "Lewa");

                foreach (var item in model)
                {
                    lista.Add(item.Zab);
                }

                List<SelectListItem> listaModel = new List<SelectListItem>();
                foreach (var item in lista)
                {
                    listaModel.Add(new SelectListItem() { Value = item.ToString(), Text = item.ToString() });
                }


                return listaModel;
            }

        }
    }
    #endregion

    #region KategoriaModel
    public class KategoriaModel
    {
        public string Kategoria { get; set; }
        public List<SelectListItem> ListaKategorie { get; set; }

        public string Brakujace { get; set; }
        public List<SelectListItem> ListaBrakujace { get; set; }

        public KategoriaModel()
        {
            this.ListaKategorie = InitKategorie();
            this.ListaBrakujace = InitBrakujące();
        }

        private List<SelectListItem> InitBrakujące()
        {
            List<SelectListItem> lista = new List<SelectListItem>()
           {
               new SelectListItem(){Value="Brakujace", Text="Brakujace zęby"},

           };

            return lista;
        }

        private List<SelectListItem> InitKategorie()
        {
            List<SelectListItem> lista = new List<SelectListItem>()
           {
               new SelectListItem(){Value="Stałe", Text="Zęby stałe"},
               new SelectListItem(){Value="Mleczne", Text="Zęby mleczne"},
               new SelectListItem(){Value="Implanty", Text="Dodaj Implant"}
           };

            return lista;

        }
    }
    #endregion

    #region Rozpoznanie
    public class RozpoznanieModel
    {
        public int RozpoznanieID { get; set; }

        public string Rozpoznanie { get; set; }
        public List<SelectListItem> ListRozpoznanie { get; set; }

        public string Dodaj { get; set; }

        public RozpoznanieModel()
        {
            this.ListRozpoznanie = InitRozpoznanie();
        }

        private List<SelectListItem> InitRozpoznanie()
        {
            Metody client = new Metody();
            List<SelectListItem> lista = new List<SelectListItem>();
            var model = client.GetRozpoznanieList();

            foreach (var item in model)
            {
                lista.Add(new SelectListItem() { Value = item.Rozpoz, Text = item.Rozpoz });
            }

            return lista;
        }
    }
    #endregion

    #region HistoriaPacjentaModel
    public class HistoriaPacjentaModel
    {
        public int WizytaID { get; set; }

        public string Data { get; set; }

        public string ImieL { get; set; }

        public string NazwiskoL { get; set; }

        public string RodzajZebow { get; set; }

        public string GD { get; set; }

        public string LP { get; set; }

        public int Zab { get; set; }

        public string Rozpoznanie { get; set; }

        public string Procedura { get; set; }
    }
    #endregion

    #region PacjenciModel
    public class PacjenciModel
    {
        public int PacjentID { get; set; }

        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public string DataUrodzenia { get; set; }

        public int Telefon { get; set; }
    }
    #endregion

    #region WizytaHistoriaPacjent
    public class WizytaHistoriaPacjenta
    {
        public int PacjentID { get; set; }

        public string Data { get; set; }

        public string Gabinet { get; set; }

        public string Godzina { get; set; }

        public string ImieLekarz { get; set; }

        public string NazwiskoLekarz { get; set; }

        public string FormaPlatnosci { get; set; }

        public decimal Kwota { get; set; }

    }
    #endregion

    #region AnulowanieWizytyModel
    public class AnulowanieWizytyModel
    {
        public int WizytaID { get; set; }

        public string Gabinet { get; set; }

        public string ImieLekarza { get; set; }

        public string NazwiskoLekarza { get; set; }

        public string Data { get; set; }

        public string Godzina { get; set; }

        public string Stan { get; set; }

    }
    #endregion
}
