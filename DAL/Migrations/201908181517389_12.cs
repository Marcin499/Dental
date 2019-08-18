namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BrakZebows", "PacjentID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BrakZebows", "PacjentID");
        }
    }
}
