namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        eid = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        empcode = c.String(),
                        office = c.String(),
                    })
                .PrimaryKey(t => t.eid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
