namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Placowkas", "GodzOd", c => c.String());
            AlterColumn("dbo.Placowkas", "GodzDo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Placowkas", "GodzDo", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Placowkas", "GodzOd", c => c.DateTime(nullable: false));
        }
    }
}
