namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Personels", "Placowka", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Personels", "Placowka", c => c.String());
        }
    }
}
