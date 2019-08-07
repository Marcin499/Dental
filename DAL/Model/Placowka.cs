namespace DAL.Model
{
    public class Placowka
    {
        public int PlacowkaID { get; set; }

        public string Nazwa { get; set; }

        public int Telefon { get; set; }

        public string Email { get; set; }

        public string GodzOd { get; set; }

        public string GodzDo { get; set; }

        public virtual AdresPlacowka PlacowkaAdresPlacowka { get; set; }
    }
}
