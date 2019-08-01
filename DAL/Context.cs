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

        public DbSet<Pacjent> Pacjents { get; set; }
        public DbSet<Adres> Adress { get; set; }
        public DbSet<AdresPersonel> AdresPersonels { get; set; }
        public DbSet<AdresPlacowka> AdresPlacowkas { get; set; }
        public DbSet<Personel> Pesonels { get; set; }
        public DbSet<Placowka> Placowkas { get; set; }
    }
}
