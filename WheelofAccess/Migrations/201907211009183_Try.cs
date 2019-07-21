namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Try : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "Place_Id", "dbo.Places");
            DropIndex("dbo.Reviews", new[] { "Place_Id" });
            RenameColumn(table: "dbo.Reviews", name: "Place_Id", newName: "PlaceId");
            CreateTable(
                "dbo.ApplicationUserPlaces",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Place_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Place_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Places", t => t.Place_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Place_Id);
            
            AlterColumn("dbo.Reviews", "Rating", c => c.Single(nullable: false));
            AlterColumn("dbo.Reviews", "PlaceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reviews", "PlaceId");
            AddForeignKey("dbo.Reviews", "PlaceId", "dbo.Places", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "PlaceId", "dbo.Places");
            DropForeignKey("dbo.ApplicationUserPlaces", "Place_Id", "dbo.Places");
            DropForeignKey("dbo.ApplicationUserPlaces", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserPlaces", new[] { "Place_Id" });
            DropIndex("dbo.ApplicationUserPlaces", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Reviews", new[] { "PlaceId" });
            AlterColumn("dbo.Reviews", "PlaceId", c => c.Int());
            AlterColumn("dbo.Reviews", "Rating", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropTable("dbo.ApplicationUserPlaces");
            RenameColumn(table: "dbo.Reviews", name: "PlaceId", newName: "Place_Id");
            CreateIndex("dbo.Reviews", "Place_Id");
            AddForeignKey("dbo.Reviews", "Place_Id", "dbo.Places", "Id");
        }
    }
}
