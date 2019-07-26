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
                        Miasto = c.String(nullable: false),
                        Wojewodztwo = c.String(nullable: false),
                        Ulica = c.String(nullable: false),
                        Numer = c.String(nullable: false),
                        Kod = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdresID)
                .ForeignKey("dbo.Pacjents", t => t.AdresID)
                .Index(t => t.AdresID);
            
            CreateTable(
                "dbo.Pacjents",
                c => new
                    {
                        PacjentID = c.Int(nullable: false, identity: true),
                        Imie = c.String(nullable: false),
                        Nazwisko = c.String(nullable: false),
                        PESEL = c.String(nullable: false, maxLength: 11),
                        Telefon = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Typ = c.String(),
                        Haslo = c.String(nullable: false),
                        PowtorzHaslo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PacjentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Adres", "AdresID", "dbo.Pacjents");
            DropIndex("dbo.Adres", new[] { "AdresID" });
            DropTable("dbo.Pacjents");
            DropTable("dbo.Adres");
        }
    }
}
