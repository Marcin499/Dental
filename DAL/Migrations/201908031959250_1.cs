namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adres",
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
                .ForeignKey("dbo.Pacjents", t => t.AdresID)
                .Index(t => t.AdresID);
            
            CreateTable(
                "dbo.Pacjents",
                c => new
                    {
                        PacjentID = c.Int(nullable: false, identity: true),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        PESEL = c.String(),
                        Telefon = c.Int(nullable: false),
                        Email = c.String(),
                        Typ = c.String(),
                        Haslo = c.String(),
                        PowtorzHaslo = c.String(),
                    })
                .PrimaryKey(t => t.PacjentID);
            
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
                        Placowka = c.String(),
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
                        Telefon = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.PlacowkaID);
            
            CreateTable(
                "dbo.Cenniks",
                c => new
                    {
                        ZabiegID = c.Int(nullable: false, identity: true),
                        Zabieg = c.String(),
                        Kategoria = c.String(),
                        Cena = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ZabiegID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdresPlacowkas", "AdresID", "dbo.Placowkas");
            DropForeignKey("dbo.AdresPersonels", "AdresID", "dbo.Personels");
            DropForeignKey("dbo.Adres", "AdresID", "dbo.Pacjents");
            DropIndex("dbo.AdresPlacowkas", new[] { "AdresID" });
            DropIndex("dbo.AdresPersonels", new[] { "AdresID" });
            DropIndex("dbo.Adres", new[] { "AdresID" });
            DropTable("dbo.Cenniks");
            DropTable("dbo.Placowkas");
            DropTable("dbo.AdresPlacowkas");
            DropTable("dbo.Personels");
            DropTable("dbo.AdresPersonels");
            DropTable("dbo.Pacjents");
            DropTable("dbo.Adres");
        }
    }
}
