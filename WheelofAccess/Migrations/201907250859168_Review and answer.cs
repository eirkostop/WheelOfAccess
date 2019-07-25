namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reviewandanswer : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Answers", name: "Question_Name", newName: "Question_Id");
            RenameIndex(table: "dbo.Answers", name: "IX_Question_Name", newName: "IX_Question_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Answers", name: "IX_Question_Id", newName: "IX_Question_Name");
            RenameColumn(table: "dbo.Answers", name: "Question_Id", newName: "Question_Name");
        }
    }
}
