namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _17 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Pacjents", newName: "Pacjent");
            RenameTable(name: "dbo.AdresPersonels", newName: "AdresPersonel");
            RenameTable(name: "dbo.Personels", newName: "Personel");
            RenameTable(name: "dbo.AdresPlacowkas", newName: "AdresPlacowka");
            RenameTable(name: "dbo.Placowkas", newName: "Placowka");
            RenameTable(name: "dbo.BrakZebows", newName: "BrakZebow");
            RenameTable(name: "dbo.Cenniks", newName: "Cennik");
            RenameTable(name: "dbo.Leczenies", newName: "Leczenie");
            RenameTable(name: "dbo.Rachuneks", newName: "Rachunek");
            RenameTable(name: "dbo.Rozpoznanies", newName: "Rozpoznanie");
            RenameTable(name: "dbo.Wizytas", newName: "Wizyta");
            RenameTable(name: "dbo.Zebies", newName: "Zeby");
            CreateTable(
                "dbo.CredentialsSMS",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccountSid = c.String(),
                        AuthToken = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Implant",
                c => new
                    {
                        IDImplantu = c.Int(nullable: false, identity: true),
                        IDPacjenta = c.Int(nullable: false),
                        GD = c.String(),
                        LP = c.String(),
                        Zab = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDImplantu);
            
            AddColumn("dbo.Cennik", "PlacowkaID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cennik", "PlacowkaID");
            DropTable("dbo.Implant");
            DropTable("dbo.CredentialsSMS");
            RenameTable(name: "dbo.Zeby", newName: "Zebies");
            RenameTable(name: "dbo.Wizyta", newName: "Wizytas");
            RenameTable(name: "dbo.Rozpoznanie", newName: "Rozpoznanies");
            RenameTable(name: "dbo.Rachunek", newName: "Rachuneks");
            RenameTable(name: "dbo.Leczenie", newName: "Leczenies");
            RenameTable(name: "dbo.Cennik", newName: "Cenniks");
            RenameTable(name: "dbo.BrakZebow", newName: "BrakZebows");
            RenameTable(name: "dbo.Placowka", newName: "Placowkas");
            RenameTable(name: "dbo.AdresPlacowka", newName: "AdresPlacowkas");
            RenameTable(name: "dbo.Personel", newName: "Personels");
            RenameTable(name: "dbo.AdresPersonel", newName: "AdresPersonels");
            RenameTable(name: "dbo.Pacjent", newName: "Pacjents");
        }
    }
}
