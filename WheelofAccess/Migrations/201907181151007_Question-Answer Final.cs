namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionAnswerFinal : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Questions");
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Givenanswer = c.Int(nullable: false),
                        Question_Id_Title = c.String(maxLength: 128),
                        Review_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id_Title)
                .ForeignKey("dbo.Reviews", t => t.Review_Id)
                .Index(t => t.Question_Id_Title)
                .Index(t => t.Review_Id);
            
            CreateTable(
                "dbo.PossibleAnswers",
                c => new
                    {
                        OptionName = c.String(nullable: false, maxLength: 128),
                        AnswerValue = c.Int(nullable: false),
                        Question_Title = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OptionName)
                .ForeignKey("dbo.Questions", t => t.Question_Title)
                .Index(t => t.Question_Title);
            
            AlterColumn("dbo.Questions", "Title", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Questions", "Title");
            DropColumn("dbo.Questions", "Id");
            DropColumn("dbo.Questions", "AnswerType");
            DropColumn("dbo.Questions", "Answer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "Answer", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "AnswerType", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Answers", "Review_Id", "dbo.Reviews");
            DropForeignKey("dbo.PossibleAnswers", "Question_Title", "dbo.Questions");
            DropForeignKey("dbo.Answers", "Question_Id_Title", "dbo.Questions");
            DropIndex("dbo.PossibleAnswers", new[] { "Question_Title" });
            DropIndex("dbo.Answers", new[] { "Review_Id" });
            DropIndex("dbo.Answers", new[] { "Question_Id_Title" });
            DropPrimaryKey("dbo.Questions");
            AlterColumn("dbo.Questions", "Title", c => c.String());
            DropTable("dbo.PossibleAnswers");
            DropTable("dbo.Answers");
            AddPrimaryKey("dbo.Questions", "Id");
        }
    }
}
