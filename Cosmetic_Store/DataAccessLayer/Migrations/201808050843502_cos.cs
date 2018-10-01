namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbCosmeticDetails",
                c => new
                    {
                        Cos_ID = c.Int(nullable: false, identity: true),
                        Cos_Title = c.String(nullable: false),
                        Company = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Cos_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbCosmeticDetails");
        }
    }
}
