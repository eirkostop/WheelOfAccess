namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixingmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PossibleAnswers", "Question_Title", "dbo.Questions");
            DropIndex("dbo.PossibleAnswers", new[] { "Question_Title" });
            AddColumn("dbo.PossibleAnswers", "Question_Title1", c => c.String(maxLength: 128));
            AlterColumn("dbo.PossibleAnswers", "Question_Title", c => c.String());
            CreateIndex("dbo.PossibleAnswers", "Question_Title1");
            AddForeignKey("dbo.PossibleAnswers", "Question_Title1", "dbo.Questions", "Title");
            DropColumn("dbo.PossibleAnswers", "QuestionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PossibleAnswers", "QuestionId", c => c.Int(nullable: false));
            DropForeignKey("dbo.PossibleAnswers", "Question_Title1", "dbo.Questions");
            DropIndex("dbo.PossibleAnswers", new[] { "Question_Title1" });
            AlterColumn("dbo.PossibleAnswers", "Question_Title", c => c.String(maxLength: 128));
            DropColumn("dbo.PossibleAnswers", "Question_Title1");
            CreateIndex("dbo.PossibleAnswers", "Question_Title");
            AddForeignKey("dbo.PossibleAnswers", "Question_Title", "dbo.Questions", "Title");
        }
    }
}
