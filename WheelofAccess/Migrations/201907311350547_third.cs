namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Name", c => c.String());
            DropColumn("dbo.Categories", "PlaceName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "PlaceName", c => c.String());
            DropColumn("dbo.Categories", "Name");
        }
    }
}
