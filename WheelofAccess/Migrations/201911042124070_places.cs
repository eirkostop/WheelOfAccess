namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class places : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Place_Id", "dbo.Places");
            DropIndex("dbo.Categories", new[] { "Place_Id" });
            CreateTable(
                "dbo.CategoryPlaces",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        Place_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.Place_Id })
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Places", t => t.Place_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.Place_Id);
            
            DropColumn("dbo.Categories", "Place_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Place_Id", c => c.Int());
            DropForeignKey("dbo.CategoryPlaces", "Place_Id", "dbo.Places");
            DropForeignKey("dbo.CategoryPlaces", "Category_Id", "dbo.Categories");
            DropIndex("dbo.CategoryPlaces", new[] { "Place_Id" });
            DropIndex("dbo.CategoryPlaces", new[] { "Category_Id" });
            DropTable("dbo.CategoryPlaces");
            CreateIndex("dbo.Categories", "Place_Id");
            AddForeignKey("dbo.Categories", "Place_Id", "dbo.Places", "Id");
        }
    }
}
