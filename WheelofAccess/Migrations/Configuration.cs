namespace WheelofAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WheelofAccess.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WheelofAccess.Models.ApplicationDbContext context)
        {
            //    var userstore = new UserStore<ApplicationUser>(context);
            //    ApplicationUserManager userManager = new ApplicationUserManager(userstore);
            //    var rolestore = new RoleStore<IdentityRole>(context);
            //    RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(rolestore);
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //    var userstore = new UserStore<ApplicationUser>(context);
            //    ApplicationUserManager userManager = new ApplicationUserManager(userstore);
            //    var rolestore = new RoleStore<IdentityRole>(context);
            //    RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(rolestore);


             //    string email = "admin@gmail.gr";
           	//    string username = "admin";
            //    string username = "admin";
            //    string password = "Admin1!";
            //    //string roleName = "Admin";
            //    var roleName = "Admin";
            //    var roleName2 = "Regular User";


            //    IdentityRole role = roleManager.FindByName(roleName);
            //    if (role == null)
            //    {
            //        role = new IdentityRole(roleName);
            //        roleManager.Create(role);
            //    }



            //    IdentityRole role2 = roleManager.FindByName(roleName2);
            //    if (role2 == null)
            //    {
            //        role2 = new IdentityRole(roleName2);
            //        roleManager.Create(role2);
            //    }
            //    ApplicationUser user = userManager.FindByName(username);
            //    if (user == null)
            //    {
            //        user = new ApplicationUser() { UserName = email, Email = email };
            //        userManager.Create(user, password);
            //    }
        }
    }
}
