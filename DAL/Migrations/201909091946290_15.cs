namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leczenies", "RodzajZebow", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Leczenies", "RodzajZebow");
        }
    }
}
