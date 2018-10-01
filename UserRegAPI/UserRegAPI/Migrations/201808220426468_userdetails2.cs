namespace UserRegAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userdetails2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Name", c => c.String());
            AddColumn("dbo.User", "Password", c => c.String());
            AddColumn("dbo.User", "Gender", c => c.String());
            AddColumn("dbo.User", "Age", c => c.String());
            AddColumn("dbo.User", "Mobile_no", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Mobile_no");
            DropColumn("dbo.User", "Age");
            DropColumn("dbo.User", "Gender");
            DropColumn("dbo.User", "Password");
            DropColumn("dbo.User", "Name");
        }
    }
}
