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
            //Question title_1 = new Question() { Text = "Does the pavement has a ramp?" };
            //Question title_2 = new Question() { Text = "Does the entrance has steps?" };
            //Question title_3 = new Question() { Text = "Does the entrance has a ramp?" };
            //Question title_4 = new Question() { Text = "Is it easy to move around?" };
            //Question title_5 = new Question() { Text = "The toilet is: " };
            //Question title_6 = new Question() { Text = "Does it have a parking space?" };
            //Question title_7 = new Question() { Text = "Is it providing the menu in Braille?" };
            //context.Questions.AddOrUpdate(x => x.Text, title_1);
            //context.Questions.AddOrUpdate(x => x.Text, title_2);
            //context.Questions.AddOrUpdate(x => x.Text, title_3);
            //context.Questions.AddOrUpdate(x => x.Text, title_4);
            //context.Questions.AddOrUpdate(x => x.Text, title_5);
            //context.Questions.AddOrUpdate(x => x.Text, title_6);
            //context.Questions.AddOrUpdate(x => x.Text, title_7);

            //PossibleAnswer option_1 = new PossibleAnswer() { Answer = "Yes", AnswerValue = 5, QuestionId = 1 };
            //PossibleAnswer option_2 = new PossibleAnswer() { Answer = "No", AnswerValue = 0, QuestionId = 1 };
            //PossibleAnswer option_3 = new PossibleAnswer() { Answer = "Yes", AnswerValue = 0, QuestionId = 2 };
            //PossibleAnswer option_4 = new PossibleAnswer() { Answer = "No", AnswerValue = 5, QuestionId = 2 };
            //PossibleAnswer option_5 = new PossibleAnswer() { Answer = "Yes", AnswerValue = 5, QuestionId = 3 };
            //PossibleAnswer option_6 = new PossibleAnswer() { Answer = "No", AnswerValue = 0, QuestionId = 3 };
            //PossibleAnswer option_7 = new PossibleAnswer() { Answer = "Easy", AnswerValue = 5, QuestionId = 4 };
            //PossibleAnswer option_8 = new PossibleAnswer() { Answer = "Hard", AnswerValue = 0, QuestionId = 4 };
            //PossibleAnswer option_9 = new PossibleAnswer() { Answer = "Somewhat easy", AnswerValue = 3, QuestionId = 4 };
            //PossibleAnswer option_10 = new PossibleAnswer() { Answer = "Accessible", AnswerValue = 5, QuestionId = 5 };
            //PossibleAnswer option_11 = new PossibleAnswer() { Answer = "Not accessible,on the same level and spacious", AnswerValue = 4, QuestionId = 5 };
            //PossibleAnswer option_12 = new PossibleAnswer() { Answer = "Not accessible,on the same level with a spacious hall ", AnswerValue = 3, QuestionId = 5 };
            //PossibleAnswer option_13 = new PossibleAnswer() { Answer = "Different level or really small", AnswerValue = 0, QuestionId = 5 };
            //PossibleAnswer option_14 = new PossibleAnswer() { Answer = "Yes,free of charge", AnswerValue = 5, QuestionId = 6 };
            //PossibleAnswer option_15 = new PossibleAnswer() { Answer = "Yes,payment required", AnswerValue = 3, QuestionId = 6 };
            //PossibleAnswer option_16 = new PossibleAnswer() { Answer = "No", AnswerValue = 0, QuestionId = 6 };
            //PossibleAnswer option_17 = new PossibleAnswer() { Answer = "Yes", AnswerValue = 5, QuestionId = 7 };
            //PossibleAnswer option_18 = new PossibleAnswer() { Answer = "No", AnswerValue = 0, QuestionId = 7 };
            //context.PossibleAnswers.AddOrUpdate(x => x.Id, option_1);
            //context.PossibleAnswers.AddOrUpdate(x => x.Id, option_2);
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
