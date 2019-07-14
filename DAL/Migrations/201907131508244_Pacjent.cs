namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pacjent : DbMigration
    {
        public override void Up()
        {
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
                        Typ = c.String(nullable: false),
                        Haslo = c.String(nullable: false),
                        PowtorzHaslo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PacjentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pacjents");
        }
    }
}
