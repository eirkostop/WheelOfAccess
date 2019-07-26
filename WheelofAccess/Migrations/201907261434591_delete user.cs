namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteuser : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.UserViews");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserViews",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Username = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
