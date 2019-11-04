namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Title_Text : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Text", c => c.String());
            DropColumn("dbo.Questions", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "Title", c => c.String());
            DropColumn("dbo.Questions", "Text");
        }
    }
}
