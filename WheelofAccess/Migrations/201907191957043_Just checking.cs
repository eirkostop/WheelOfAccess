namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Justchecking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PossibleAnswers", "QuestionId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PossibleAnswers", "QuestionId");
        }
    }
}
