namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qIdtoanswer : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Answers", name: "Question_Id", newName: "Question_Name");
            RenameIndex(table: "dbo.Answers", name: "IX_Question_Id", newName: "IX_Question_Name");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Answers", name: "IX_Question_Name", newName: "IX_Question_Id");
            RenameColumn(table: "dbo.Answers", name: "Question_Name", newName: "Question_Id");
        }
    }
}
