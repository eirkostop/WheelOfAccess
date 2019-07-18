namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "AnswerType", c => c.Int(nullable: false));
            AlterColumn("dbo.Questions", "Answer", c => c.Int(nullable: false));
            DropColumn("dbo.Questions", "QuestionBody");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "QuestionBody", c => c.String());
            AlterColumn("dbo.Questions", "Answer", c => c.Boolean(nullable: false));
            DropColumn("dbo.Questions", "AnswerType");
        }
    }
}
