namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfilePic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "Comment", c => c.String());
            AddColumn("dbo.AspNetUsers", "ProfilePic", c => c.Binary());
            DropColumn("dbo.Answers", "Text");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "Text", c => c.String());
            DropColumn("dbo.AspNetUsers", "ProfilePic");
            DropColumn("dbo.Reviews", "Comment");
        }
    }
}
