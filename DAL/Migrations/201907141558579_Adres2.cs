namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adres2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Adres", new[] { "AdresID" });
            DropPrimaryKey("dbo.Adres");
            AlterColumn("dbo.Adres", "AdresID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Adres", "AdresID");
            CreateIndex("dbo.Adres", "AdresID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Adres", new[] { "AdresID" });
            DropPrimaryKey("dbo.Adres");
            AlterColumn("dbo.Adres", "AdresID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Adres", "AdresID");
            CreateIndex("dbo.Adres", "AdresID");
        }
    }
}
