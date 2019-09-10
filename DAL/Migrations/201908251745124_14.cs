namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Leczenies",
                c => new
                    {
                        LeczenieID = c.Int(nullable: false, identity: true),
                        WizytaID = c.Int(nullable: false),
                        GD = c.String(),
                        LP = c.String(),
                        Zab = c.Int(nullable: false),
                        Rozpoznanie = c.String(),
                    })
                .PrimaryKey(t => t.LeczenieID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Leczenies");
        }
    }
}
