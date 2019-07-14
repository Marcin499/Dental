namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adres3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Adres", "Kod", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Adres", "Kod", c => c.Int(nullable: false));
        }
    }
}
