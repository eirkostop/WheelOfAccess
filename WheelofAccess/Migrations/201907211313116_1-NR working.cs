namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1NRworking : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Answers", name: "Question_Id_Title", newName: "QuestionTitle");
            RenameIndex(table: "dbo.Answers", name: "IX_Question_Id_Title", newName: "IX_QuestionTitle");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Answers", name: "IX_QuestionTitle", newName: "IX_Question_Id_Title");
            RenameColumn(table: "dbo.Answers", name: "QuestionTitle", newName: "Question_Id_Title");
        }
    }
}
