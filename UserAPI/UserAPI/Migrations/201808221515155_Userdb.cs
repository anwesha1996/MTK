namespace UserAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Userdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        Uid = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Gender = c.String(),
                        Age = c.Int(nullable: false),
                        Mobile_no = c.String(),
                    })
                .PrimaryKey(t => t.Uid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserDetails");
        }
    }
}
