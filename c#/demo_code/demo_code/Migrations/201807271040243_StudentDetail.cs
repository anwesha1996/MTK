namespace demo_code.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.grades",
                c => new
                    {
                        Gradeid = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Gradeid);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Gradeid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.grades", t => t.Gradeid, cascadeDelete: true)
                .Index(t => t.Gradeid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Gradeid", "dbo.grades");
            DropIndex("dbo.Students", new[] { "Gradeid" });
            DropTable("dbo.Students");
            DropTable("dbo.grades");
        }
    }
}
