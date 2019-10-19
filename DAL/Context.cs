using DAL.Model;
using System.Data.Entity;

namespace DAL
{
    public class Context : DbContext
    {
        public Context() : base(@"Data Source=MARCIN\MARCIN;Initial Catalog=Dental;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<Context>(null);
            base.OnModelCreating(modelBuilder);
            //Połaczenie 1-1 Pacjent -> Adres
            modelBuilder.Entity<Pacjent>()
                .HasRequired(s => s.PacjentAdres)
                .WithRequiredPrincipal(s => s.AdresPacjent);
            //Połaczenie 1-1 Personel -> AdresPersonel
            modelBuilder.Entity<Personel>()
                .HasRequired(s => s.PersonelAdres)
                .WithRequiredPrincipal(s => s.AdresPesonel);
            //Polaczenie 1-1 Placowka -> Adres
            modelBuilder.Entity<Placowka>()
                .HasRequired(s => s.PlacowkaAdresPlacowka)
                .WithRequiredPrincipal(s => s.AdresPlacowkaAdres);

        }

        public DbSet<Pacjent> Pacjent { get; set; }
        public DbSet<Adres> Adres { get; set; }
        public DbSet<AdresPersonel> AdresPersonel { get; set; }
        public DbSet<AdresPlacowka> AdresPlacowka { get; set; }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<Placowka> Placowka { get; set; }
        public DbSet<Cennik> Cennik { get; set; }
        public DbSet<Wizyta> Wizyta { get; set; }
        public DbSet<Rachunek> Rachunek { get; set; }
        public DbSet<Zeby> Zeby { get; set; }
        public DbSet<BrakZebow> BrakZebow { get; set; }
        public DbSet<Rozpoznanie> Rozpoznanie { get; set; }
        public DbSet<Leczenie> Leczenie { get; set; }
        public DbSet<CredentialsSMS> CredentialsSMS { get; set; }
        public DbSet<Implant> Implant { get; set; }
    }
}
