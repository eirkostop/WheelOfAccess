namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingIdtoCategory : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Categories");
            AddColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AddPrimaryKey("dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Categories", "Id");
            AddPrimaryKey("dbo.Categories", "Name");
        }
    }
}
