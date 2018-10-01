namespace BookMyRoom.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        Uid = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(maxLength: 40),
                        Password = c.String(),
                        UserName = c.String(maxLength: 20),
                        Gender = c.String(),
                        Age = c.Int(nullable: false),
                        Mobile_no = c.String(),
                    })
                .PrimaryKey(t => t.Uid)
                .Index(t => t.Email, unique: true)
                .Index(t => t.UserName, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserDetails", new[] { "UserName" });
            DropIndex("dbo.UserDetails", new[] { "Email" });
            DropTable("dbo.UserDetails");
        }
    }
}
