namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropAnswers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "SelectedAnswer_Id", "dbo.Answers");
            DropIndex("dbo.Questions", new[] { "SelectedAnswer_Id" });
            AddColumn("dbo.Questions", "Answer", c => c.Boolean(nullable: false));
            DropColumn("dbo.Questions", "SelectedAnswer_Id");
            DropTable("dbo.Answers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        YesorNo = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Questions", "SelectedAnswer_Id", c => c.Int());
            DropColumn("dbo.Questions", "Answer");
            CreateIndex("dbo.Questions", "SelectedAnswer_Id");
            AddForeignKey("dbo.Questions", "SelectedAnswer_Id", "dbo.Answers", "Id");
        }
    }
}
