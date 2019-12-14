namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class question_categories : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CategoryPlaces", newName: "PlaceCategories");
            DropPrimaryKey("dbo.PlaceCategories");
            CreateTable(
                "dbo.CategoryQuestions",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        Question_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.Question_Id })
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.Question_Id);
            
            AddPrimaryKey("dbo.PlaceCategories", new[] { "Place_Id", "Category_Id" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryQuestions", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.CategoryQuestions", "Category_Id", "dbo.Categories");
            DropIndex("dbo.CategoryQuestions", new[] { "Question_Id" });
            DropIndex("dbo.CategoryQuestions", new[] { "Category_Id" });
            DropPrimaryKey("dbo.PlaceCategories");
            DropTable("dbo.CategoryQuestions");
            AddPrimaryKey("dbo.PlaceCategories", new[] { "Category_Id", "Place_Id" });
            RenameTable(name: "dbo.PlaceCategories", newName: "CategoryPlaces");
        }
    }
}
