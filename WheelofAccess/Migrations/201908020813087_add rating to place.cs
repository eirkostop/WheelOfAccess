namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addratingtoplace : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "Rating", c => c.Single(nullable: false));
            DropColumn("dbo.Places", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Places", "Location", c => c.String());
            DropColumn("dbo.Places", "Rating");
        }
    }
}
