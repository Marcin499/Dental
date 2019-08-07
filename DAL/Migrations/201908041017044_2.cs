namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Placowkas", "GodzOd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Placowkas", "GodzDo", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Placowkas", "GodzDo");
            DropColumn("dbo.Placowkas", "GodzOd");
        }
    }
}
