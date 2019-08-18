namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BrakZebows",
                c => new
                    {
                        ZabID = c.Int(nullable: false, identity: true),
                        Kategoria = c.String(),
                        GD = c.String(),
                        LP = c.String(),
                        Zab = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ZabID);
            
            CreateTable(
                "dbo.Zebies",
                c => new
                    {
                        ZabID = c.Int(nullable: false, identity: true),
                        Kategoria = c.String(),
                        GD = c.String(),
                        LP = c.String(),
                        Zab = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ZabID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Zebies");
            DropTable("dbo.BrakZebows");
        }
    }
}
