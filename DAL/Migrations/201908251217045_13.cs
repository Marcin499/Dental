namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rozpoznanies",
                c => new
                    {
                        RozpoznanieID = c.Int(nullable: false, identity: true),
                        Rozpoz = c.String(),
                    })
                .PrimaryKey(t => t.RozpoznanieID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Rozpoznanies");
        }
    }
}
