namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllGood : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Answers", name: "Question_Id", newName: "Question_Name");
            RenameColumn(table: "dbo.PossibleAnswers", name: "Question_Id", newName: "Question_Title");
            RenameIndex(table: "dbo.Answers", name: "IX_Question_Id", newName: "IX_Question_Name");
            RenameIndex(table: "dbo.PossibleAnswers", name: "IX_Question_Id", newName: "IX_Question_Title");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PossibleAnswers", name: "IX_Question_Title", newName: "IX_Question_Id");
            RenameIndex(table: "dbo.Answers", name: "IX_Question_Name", newName: "IX_Question_Id");
            RenameColumn(table: "dbo.PossibleAnswers", name: "Question_Title", newName: "Question_Id");
            RenameColumn(table: "dbo.Answers", name: "Question_Name", newName: "Question_Id");
        }
    }
}
