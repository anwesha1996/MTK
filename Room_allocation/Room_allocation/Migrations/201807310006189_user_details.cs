namespace Room_allocation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_details : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        Rid = c.Int(nullable: false),
                        Block_name = c.String(nullable: false),
                        Floor_no = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RoomId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Uid = c.Int(nullable: false, identity: true),
                        Mid = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Track_name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Uid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Rooms");
        }
    }
}
