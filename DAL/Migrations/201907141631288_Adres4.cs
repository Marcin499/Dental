namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adres4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pacjents", "Typ", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pacjents", "Typ", c => c.String(nullable: false));
        }
    }
}
