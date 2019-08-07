namespace DAL.Model
{
    public class Adres
    {
        public int AdresID { get; set; }        

        public string Miasto { get; set; }

        public string Wojewodztwo { get; set; }

        public string Ulica { get; set; }

        public string Numer { get; set; }

        public string Kod { get; set; }

        public virtual Pacjent AdresPacjent { get; set; }
        
    }
}
