namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Name : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "PlaceId", "dbo.Places");
            DropIndex("dbo.Reviews", new[] { "PlaceId" });
            AlterColumn("dbo.Reviews", "PlaceId", c => c.Int());
            CreateIndex("dbo.Reviews", "PlaceId");
            AddForeignKey("dbo.Reviews", "PlaceId", "dbo.Places", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "PlaceId", "dbo.Places");
            DropIndex("dbo.Reviews", new[] { "PlaceId" });
            AlterColumn("dbo.Reviews", "PlaceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reviews", "PlaceId");
            AddForeignKey("dbo.Reviews", "PlaceId", "dbo.Places", "Id", cascadeDelete: true);
        }
    }
}
