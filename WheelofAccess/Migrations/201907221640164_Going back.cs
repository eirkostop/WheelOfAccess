namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Goingback : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "Question_Id1", "dbo.Questions");
            DropForeignKey("dbo.PossibleAnswers", "Question_Id1", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "Question_Id1" });
            DropIndex("dbo.PossibleAnswers", new[] { "Question_Id1" });
            RenameColumn(table: "dbo.Answers", name: "Question_Id1", newName: "Question_Title1");
            RenameColumn(table: "dbo.PossibleAnswers", name: "Question_Id1", newName: "Question_Title1");
            DropPrimaryKey("dbo.Questions");
            AddColumn("dbo.Answers", "Question_Title", c => c.String());
            AddColumn("dbo.PossibleAnswers", "Question_Title", c => c.String());
            AlterColumn("dbo.Answers", "Question_Title1", c => c.String(maxLength: 128));
            AlterColumn("dbo.Questions", "Title", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.PossibleAnswers", "Question_Title1", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Questions", "Title");
            CreateIndex("dbo.Answers", "Question_Title1");
            CreateIndex("dbo.PossibleAnswers", "Question_Title1");
            AddForeignKey("dbo.Answers", "Question_Title1", "dbo.Questions", "Title");
            AddForeignKey("dbo.PossibleAnswers", "Question_Title1", "dbo.Questions", "Title");
            DropColumn("dbo.Answers", "Question_Id");
            DropColumn("dbo.Questions", "Id");
            DropColumn("dbo.PossibleAnswers", "Question_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PossibleAnswers", "Question_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Answers", "Question_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.PossibleAnswers", "Question_Title1", "dbo.Questions");
            DropForeignKey("dbo.Answers", "Question_Title1", "dbo.Questions");
            DropIndex("dbo.PossibleAnswers", new[] { "Question_Title1" });
            DropIndex("dbo.Answers", new[] { "Question_Title1" });
            DropPrimaryKey("dbo.Questions");
            AlterColumn("dbo.PossibleAnswers", "Question_Title1", c => c.Int());
            AlterColumn("dbo.Questions", "Title", c => c.String());
            AlterColumn("dbo.Answers", "Question_Title1", c => c.Int());
            DropColumn("dbo.PossibleAnswers", "Question_Title");
            DropColumn("dbo.Answers", "Question_Title");
            AddPrimaryKey("dbo.Questions", "Id");
            RenameColumn(table: "dbo.PossibleAnswers", name: "Question_Title1", newName: "Question_Id1");
            RenameColumn(table: "dbo.Answers", name: "Question_Title1", newName: "Question_Id1");
            CreateIndex("dbo.PossibleAnswers", "Question_Id1");
            CreateIndex("dbo.Answers", "Question_Id1");
            AddForeignKey("dbo.PossibleAnswers", "Question_Id1", "dbo.Questions", "Id");
            AddForeignKey("dbo.Answers", "Question_Id1", "dbo.Questions", "Id");
        }
    }
}
