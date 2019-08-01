namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdresPersonels",
                c => new
                    {
                        AdresID = c.Int(nullable: false),
                        Miasto = c.String(),
                        Wojewodztwo = c.String(),
                        Ulica = c.String(),
                        Numer = c.String(),
                        Kod = c.String(),
                    })
                .PrimaryKey(t => t.AdresID)
                .ForeignKey("dbo.Personels", t => t.AdresID)
                .Index(t => t.AdresID);
            
            CreateTable(
                "dbo.Personels",
                c => new
                    {
                        PersonelID = c.Int(nullable: false, identity: true),
                        PlacowkaID = c.Int(nullable: false),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        Telefon = c.Int(nullable: false),
                        Email = c.String(),
                        Typ = c.String(),
                        Specjalizacja = c.String(),
                        Haslo = c.String(),
                        PowtorzHaslo = c.String(),
                    })
                .PrimaryKey(t => t.PersonelID);
            
            CreateTable(
                "dbo.AdresPlacowkas",
                c => new
                    {
                        AdresID = c.Int(nullable: false),
                        Miasto = c.String(),
                        Wojewodztwo = c.String(),
                        Ulica = c.String(),
                        Numer = c.String(),
                    })
                .PrimaryKey(t => t.AdresID)
                .ForeignKey("dbo.Placowkas", t => t.AdresID)
                .Index(t => t.AdresID);
            
            CreateTable(
                "dbo.Placowkas",
                c => new
                    {
                        PlacowkaID = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Miejscowosc = c.String(),
                        Telefon = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlacowkaID);
            
            AlterColumn("dbo.Adres", "Miasto", c => c.String());
            AlterColumn("dbo.Adres", "Wojewodztwo", c => c.String());
            AlterColumn("dbo.Adres", "Ulica", c => c.String());
            AlterColumn("dbo.Adres", "Numer", c => c.String());
            AlterColumn("dbo.Adres", "Kod", c => c.String());
            AlterColumn("dbo.Pacjents", "Imie", c => c.String());
            AlterColumn("dbo.Pacjents", "Nazwisko", c => c.String());
            AlterColumn("dbo.Pacjents", "PESEL", c => c.String());
            AlterColumn("dbo.Pacjents", "Email", c => c.String());
            AlterColumn("dbo.Pacjents", "Haslo", c => c.String());
            AlterColumn("dbo.Pacjents", "PowtorzHaslo", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdresPlacowkas", "AdresID", "dbo.Placowkas");
            DropForeignKey("dbo.AdresPersonels", "AdresID", "dbo.Personels");
            DropIndex("dbo.AdresPlacowkas", new[] { "AdresID" });
            DropIndex("dbo.AdresPersonels", new[] { "AdresID" });
            AlterColumn("dbo.Pacjents", "PowtorzHaslo", c => c.String(nullable: false));
            AlterColumn("dbo.Pacjents", "Haslo", c => c.String(nullable: false));
            AlterColumn("dbo.Pacjents", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Pacjents", "PESEL", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Pacjents", "Nazwisko", c => c.String(nullable: false));
            AlterColumn("dbo.Pacjents", "Imie", c => c.String(nullable: false));
            AlterColumn("dbo.Adres", "Kod", c => c.String(nullable: false));
            AlterColumn("dbo.Adres", "Numer", c => c.String(nullable: false));
            AlterColumn("dbo.Adres", "Ulica", c => c.String(nullable: false));
            AlterColumn("dbo.Adres", "Wojewodztwo", c => c.String(nullable: false));
            AlterColumn("dbo.Adres", "Miasto", c => c.String(nullable: false));
            DropTable("dbo.Placowkas");
            DropTable("dbo.AdresPlacowkas");
            DropTable("dbo.Personels");
            DropTable("dbo.AdresPersonels");
        }
    }
}
