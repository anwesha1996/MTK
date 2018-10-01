namespace CodeFirstSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MindInitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbMinds",
                c => new
                    {
                        MID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.String(),
                        ContactNumber = c.String(),
                        trackDetails_Track_ID = c.Int(),
                    })
                .PrimaryKey(t => t.MID)
                .ForeignKey("dbo.tbTrackDetails", t => t.trackDetails_Track_ID)
                .Index(t => t.trackDetails_Track_ID);
            
            CreateTable(
                "dbo.tbTrackDetails",
                c => new
                    {
                        Track_ID = c.Int(nullable: false, identity: true),
                        Track_Name = c.String(),
                        RoomAllocated = c.String(),
                        LeadName = c.String(),
                    })
                .PrimaryKey(t => t.Track_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbMinds", "trackDetails_Track_ID", "dbo.tbTrackDetails");
            DropIndex("dbo.tbMinds", new[] { "trackDetails_Track_ID" });
            DropTable("dbo.tbTrackDetails");
            DropTable("dbo.tbMinds");
        }
    }
}
