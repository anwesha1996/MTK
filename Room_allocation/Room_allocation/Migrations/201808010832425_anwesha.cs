namespace Room_allocation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anwesha : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Allocates", new[] { "Uid" });
            DropIndex("dbo.Allocates", new[] { "RoomId" });
            CreateIndex("dbo.Allocates", "Uid");
            CreateIndex("dbo.Allocates", "RoomId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Allocates", new[] { "RoomId" });
            DropIndex("dbo.Allocates", new[] { "Uid" });
            CreateIndex("dbo.Allocates", "RoomId", unique: true);
            CreateIndex("dbo.Allocates", "Uid", unique: true);
        }
    }
}
