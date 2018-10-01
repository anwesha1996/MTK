namespace GadgetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddToWishLists",
                c => new
                    {
                        WishListID = c.Int(nullable: false, identity: true),
                        GadgeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WishListID)
                .ForeignKey("dbo.Gadgets", t => t.GadgeID, cascadeDelete: true)
                .Index(t => t.GadgeID);
            
            CreateTable(
                "dbo.Gadgets",
                c => new
                    {
                        GadgetID = c.Int(nullable: false, identity: true),
                        GadgetName = c.String(nullable: false),
                        CompanyName = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.GadgetID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AddToWishLists", "GadgeID", "dbo.Gadgets");
            DropIndex("dbo.AddToWishLists", new[] { "GadgeID" });
            DropTable("dbo.Gadgets");
            DropTable("dbo.AddToWishLists");
        }
    }
}
