namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateQuestion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            DropColumn("dbo.Answers", "Question_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "Question_Id", c => c.Int());
            CreateIndex("dbo.Answers", "Question_Id");
            AddForeignKey("dbo.Answers", "Question_Id", "dbo.Questions", "Id");
        }
    }
}
