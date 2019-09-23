namespace DAL.Model
{
    public class Leczenie
    {
        public int LeczenieID { get; set; }

        public int WizytaID { get; set; }

        public string RodzajZebow { get; set; }

        public string GD { get; set; }

        public string LP { get; set; }

        public int Zab { get; set; }

        public string Rozpoznanie { get; set; }

        public string Procedura { get; set; }

        public int Cena { get; set; }
    }
}
