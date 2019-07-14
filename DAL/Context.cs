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

        }

        public DbSet<Pacjent> Pacjents { get; set; }
        public DbSet<Adres> Adress { get; set; }
    }
}
