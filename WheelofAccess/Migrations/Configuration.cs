namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WheelofAccess.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WheelofAccess.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WheelofAccess.Models.ApplicationDbContext context)
        {
            //Category cat_cafe = new Category() { Name = "Cafe" };
            //Category cat_restaurant = new Category() { Name = "Restaurant" };
            //Category cat_bar = new Category() { Name = "Bar" };
            //context.Categories.AddOrUpdate(x => x.Name, cat_cafe);
            //context.Categories.AddOrUpdate(x => x.Name, cat_restaurant);
            //context.Categories.AddOrUpdate(x => x.Name, cat_bar);
        }
    }
}
