namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rachuneks",
                c => new
                    {
                        RachunekID = c.Int(nullable: false, identity: true),
                        Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rabat = c.Int(),
                        FormaPlatnosci = c.String(),
                        Faktura = c.Boolean(nullable: false),
                        KwotaDoZaplaty = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.RachunekID);
            
            AddColumn("dbo.Wizytas", "RachunekID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Wizytas", "RachunekID");
            DropTable("dbo.Rachuneks");
        }
    }
}
