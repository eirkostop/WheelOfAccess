namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Makingsureeverythinginplace : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Reviews", name: "ApplicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.Reviews", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Reviews", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Reviews", name: "UserId", newName: "ApplicationUser_Id");
        }
    }
}
