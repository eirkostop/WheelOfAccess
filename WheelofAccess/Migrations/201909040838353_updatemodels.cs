namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodels : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Answers", name: "Option_ID", newName: "PossibleAnswerId");
            RenameColumn(table: "dbo.Answers", name: "Review_Id", newName: "ReviewId");
            RenameColumn(table: "dbo.PossibleAnswers", name: "Question_Title", newName: "QuestionId");
            RenameIndex(table: "dbo.Answers", name: "IX_Review_Id", newName: "IX_ReviewId");
            RenameIndex(table: "dbo.Answers", name: "IX_Option_ID", newName: "IX_PossibleAnswerId");
            RenameIndex(table: "dbo.PossibleAnswers", name: "IX_Question_Title", newName: "IX_QuestionId");
            AddColumn("dbo.PossibleAnswers", "Answer", c => c.String());
            DropColumn("dbo.PossibleAnswers", "OptionName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PossibleAnswers", "OptionName", c => c.String());
            DropColumn("dbo.PossibleAnswers", "Answer");
            RenameIndex(table: "dbo.PossibleAnswers", name: "IX_QuestionId", newName: "IX_Question_Title");
            RenameIndex(table: "dbo.Answers", name: "IX_PossibleAnswerId", newName: "IX_Option_ID");
            RenameIndex(table: "dbo.Answers", name: "IX_ReviewId", newName: "IX_Review_Id");
            RenameColumn(table: "dbo.PossibleAnswers", name: "QuestionId", newName: "Question_Title");
            RenameColumn(table: "dbo.Answers", name: "ReviewId", newName: "Review_Id");
            RenameColumn(table: "dbo.Answers", name: "PossibleAnswerId", newName: "Option_ID");
        }
    }
}
