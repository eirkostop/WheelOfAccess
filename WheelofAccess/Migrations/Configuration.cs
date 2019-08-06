namespace WheelofAccess.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
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
            //Question title_1 = new Question() { Title = "Does the pavement has a ramp?" };
            //Question title_2 = new Question() { Title = "Does the entrance has steps?" };
            //Question title_3 = new Question() { Title = "Does the entrance has a ramp?" };
            //Question title_4 = new Question() { Title = "Is it easy to move around?" };
            //Question title_5 = new Question() { Title = "The toilet is: " };
            //Question title_6 = new Question() { Title = "Does it have a parking space?" };
            //Question title_7 = new Question() { Title = "Is it providing the menu in Braille?" };
            //context.Questions.AddOrUpdate(x => x.Title, title_1);
            //context.Questions.AddOrUpdate(x => x.Title, title_2);
            //context.Questions.AddOrUpdate(x => x.Title, title_3);
            //context.Questions.AddOrUpdate(x => x.Title, title_4);
            //context.Questions.AddOrUpdate(x => x.Title, title_5);
            //context.Questions.AddOrUpdate(x => x.Title, title_6);
            //context.Questions.AddOrUpdate(x => x.Title, title_7);

            //PossibleAnswer option_1 = new PossibleAnswer() { OptionName = "Yes",AnswerValue = 5,Question_Title = 3 };
            //PossibleAnswer option_2 = new PossibleAnswer() { OptionName = "No", AnswerValue = 0 ,Question_Title = 3 };
            //context.PossibleAnswers.AddOrUpdate(x => x.Id, option_1);
            //context.PossibleAnswers.AddOrUpdate(x => x.Id, option_2);
            //PossibleAnswer option_3 = new PossibleAnswer() { OptionName = "Yes", AnswerValue = 0, Question_Title = 4 };
            //PossibleAnswer option_4 = new PossibleAnswer() { OptionName = "No", AnswerValue = 5, Question_Title = 4 };
            //PossibleAnswer option_5 = new PossibleAnswer() { OptionName = "Yes", AnswerValue = 5, Question_Title = 5 };
            //PossibleAnswer option_6 = new PossibleAnswer() { OptionName = "No", AnswerValue = 0, Question_Title = 5};
            //PossibleAnswer option_7 = new PossibleAnswer() { OptionName = "Easy", AnswerValue = 5, Question_Title = 6};
            //PossibleAnswer option_8 = new PossibleAnswer() { OptionName = "Hard", AnswerValue = 0, Question_Title = 6 };
            //PossibleAnswer option_9 = new PossibleAnswer() { OptionName = "Somewhat easy", AnswerValue = 3, Question_Title = 6 };
            //PossibleAnswer option_10 = new PossibleAnswer() { OptionName = "Accessible", AnswerValue = 5, Question_Title = 7 };
            //PossibleAnswer option_11= new PossibleAnswer() { OptionName = "Not accessible,on the same level and spacious", AnswerValue = 4, Question_Title = 7 };
            //PossibleAnswer option_12= new PossibleAnswer() { OptionName = "Not accessible,on the same level with a spacious hall ", AnswerValue = 3, Question_Title = 7 };
            //PossibleAnswer option_13 = new PossibleAnswer() { OptionName = "Different level or really small", AnswerValue = 0, Question_Title = 7 };
            //PossibleAnswer option_14 = new PossibleAnswer() { OptionName = "Yes,free of charge", AnswerValue =5 , Question_Title = 8 };
            //PossibleAnswer option_15 = new PossibleAnswer() { OptionName = "Yes,payment required", AnswerValue = 3, Question_Title = 8 };
            //PossibleAnswer option_16 = new PossibleAnswer() { OptionName = "No", AnswerValue = 0, Question_Title = 8};
            //PossibleAnswer option_17 = new PossibleAnswer() { OptionName = "Yes", AnswerValue = 5, Question_Title = 9 };
            //PossibleAnswer option_18 = new PossibleAnswer() { OptionName = "No", AnswerValue = 0, Question_Title = 9 };
            //context.PossibleAnswers.AddOrUpdate(x => x.Id, option_3);
            //context.PossibleAnswers.AddOrUpdate(x => x.Id, option_4);
            //context.PossibleAnswers.AddOrUpdate(x => x.Id, option_5);
            //context.PossibleAnswers.AddOrUpdate(x => x.Id, option_6);
            //context.PossibleAnswers.AddOrUpdate(x => x.Id, option_7);
            //context.PossibleAnswers.AddOrUpdate(x => x.Id, option_8);
            //context.PossibleAnswers.AddOrUpdate(x => x.Id, option_9);
            //context.PossibleAnswers.AddOrUpdate(x => x.Id, option_10);
            //context.PossibleAnswers.AddOrUpdate(x => x.Id, option_11);
            //context.PossibleAnswers.AddOrUpdate(x => x.Id, option_12);
            //context.PossibleAnswers.AddOrUpdate(x => x.Id, option_13);
            //context.PossibleAnswers.AddOrUpdate(x => x.Id, option_14);
            //context.PossibleAnswers.AddOrUpdate(x => x.Id, option_15);
            //context.PossibleAnswers.AddOrUpdate(x => x.Id, option_16);
            //context.PossibleAnswers.AddOrUpdate(x => x.Id, option_17);
            //context.PossibleAnswers.AddOrUpdate(x => x.Id, option_18);

            //Category cat_1 = new Category() { Name = "Bar" };
            //Category cat_2 = new Category() { Name = "Restaurant" };
            //Category cat_3 = new Category() { Name = "Cafe" };
            //Category cat_4 = new Category() { Name = "Museum" };
            //context.Categories.AddOrUpdate(x => x.Id, cat_1);
            //context.Categories.AddOrUpdate(x => x.Id, cat_2);
            //context.Categories.AddOrUpdate(x => x.Id, cat_3);
            //context.Categories.AddOrUpdate(x => x.Id, cat_4);




            //    var userstore = new UserStore<ApplicationUser>(context);
            //    ApplicationUserManager userManager = new ApplicationUserManager(userstore);
            //    var rolestore = new RoleStore<IdentityRole>(context);
            //    RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(rolestore);


            //    string email = "admin@gmail.gr";
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
            //        user = new ApplicationUser()
            //        {
            //            UserName = email,
            //            Email = email
            //        };
            //        userManager.Create(user, password);
            //    }
            //    if (!userManager.IsInRole(user.Id, roleName))
            //    {
            //        userManager.AddToRole(user.Id, roleName);
            //    }
        }
    }
}
