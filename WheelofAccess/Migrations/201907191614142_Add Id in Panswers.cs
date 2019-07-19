namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdinPanswers : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PossibleAnswers");
            AddColumn("dbo.PossibleAnswers", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PossibleAnswers", "OptionName", c => c.String());
            AddPrimaryKey("dbo.PossibleAnswers", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PossibleAnswers");
            AlterColumn("dbo.PossibleAnswers", "OptionName", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.PossibleAnswers", "Id");
            AddPrimaryKey("dbo.PossibleAnswers", "OptionName");
        }
    }
}
