namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adres : DbMigration
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
                        Kod = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdresID)
                .ForeignKey("dbo.Pacjents", t => t.AdresID)
                .Index(t => t.AdresID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Adres", "AdresID", "dbo.Pacjents");
            DropIndex("dbo.Adres", new[] { "AdresID" });
            DropTable("dbo.Adres");
        }
    }
}
