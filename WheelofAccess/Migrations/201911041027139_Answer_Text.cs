namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Answer_Text : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PossibleAnswers", "Text", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PossibleAnswers", "Text");
        }
    }
}
