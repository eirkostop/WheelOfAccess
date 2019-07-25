namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ratingisnullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reviews", "Rating", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "Rating", c => c.Single(nullable: false));
        }
    }
}
