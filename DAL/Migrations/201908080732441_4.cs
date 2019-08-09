namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wizytas",
                c => new
                    {
                        WizytaID = c.Int(nullable: false, identity: true),
                        GabinetID = c.Int(nullable: false),
                        LekarzID = c.Int(nullable: false),
                        Data = c.String(),
                        Godzina = c.String(),
                        Typ = c.String(),
                        Stan = c.String(),
                        Rodzaj = c.String(),
                    })
                .PrimaryKey(t => t.WizytaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Wizytas");
        }
    }
}
