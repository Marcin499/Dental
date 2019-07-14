namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adres5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adres", "PacjentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adres", "PacjentId");
        }
    }
}
