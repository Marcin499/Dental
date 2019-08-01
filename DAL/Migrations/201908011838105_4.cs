namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Placowkas", "Miejscowosc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Placowkas", "Miejscowosc", c => c.String());
        }
    }
}
