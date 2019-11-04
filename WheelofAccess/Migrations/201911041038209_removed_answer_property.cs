namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removed_answer_property : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PossibleAnswers", "Answer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PossibleAnswers", "Answer", c => c.String());
        }
    }
}
