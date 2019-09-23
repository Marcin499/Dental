namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leczenies", "Procedura", c => c.String());
            AddColumn("dbo.Leczenies", "Cena", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Leczenies", "Cena");
            DropColumn("dbo.Leczenies", "Procedura");
        }
    }
}
