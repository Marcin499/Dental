namespace DAL.Model
{
    public class Rachunek
    {
        public int RachunekID { get; set; }

        public decimal Cena { get; set; }

        public int? Rabat { get; set; }

        public string FormaPlatnosci { get; set; }

        public bool Faktura { get; set; }

        public decimal KwotaDoZaplaty { get; set; }
    }
}
