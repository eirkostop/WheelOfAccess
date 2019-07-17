namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pic : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Dateofbirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Dateofbirth", c => c.DateTime(nullable: false));
        }
    }
}
