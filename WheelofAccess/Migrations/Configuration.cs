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
            //Provide an initial set of Questions
            Question question_1 = new Question() { Text = "Does the pavement has a ramp?", PossibleAnswers = {
                    new PossibleAnswer() { Text = "Yes", AnswerValue = 5 },
                    new PossibleAnswer() { Text = "No", AnswerValue = 0 },
                }
            };
            Question question_2 = new Question()
            {
                Text = "Does the entrance has steps?",
                PossibleAnswers = {
                    new PossibleAnswer() { Text = "Yes", AnswerValue = 0 },
                    new PossibleAnswer() { Text = "No", AnswerValue = 5 }
                }
            };
            Question question_3 = new Question() { Text = "Does the entrance has a ramp?",
                PossibleAnswers = {
                    new PossibleAnswer() { Text = "Yes", AnswerValue = 5 },
                    new PossibleAnswer() { Text = "No", AnswerValue = 0 },
                }
            }; 
            Question question_4 = new Question() { Text = "Is it easy to move around?",
                PossibleAnswers = {
                    new PossibleAnswer() { Text = "Easy", AnswerValue = 5 },
                    new PossibleAnswer() { Text = "Somewhat Easy", AnswerValue = 3 },
                    new PossibleAnswer() { Text = "Hard", AnswerValue = 0 },
                }
            };
            Question question_5 = new Question() { Text = "The toilet is: ",
                PossibleAnswers = {
                    new PossibleAnswer() { Text = "Accessible", AnswerValue = 5 },
                    new PossibleAnswer() { Text = "Not accessible,on the same level and spacious", AnswerValue = 4 },
                    new PossibleAnswer() { Text = "Not accessible,on the same level with a spacious hall", AnswerValue = 3 },
                    new PossibleAnswer() { Text = "Different level or really small", AnswerValue = 0 },
                }
            };
            Question question_6 = new Question()
            {
                Text = "Does it have a parking space?",
                PossibleAnswers =
                {
                    new PossibleAnswer() { Text = "Yes,free of charge", AnswerValue = 5 },
                    new PossibleAnswer() { Text = "Yes,payment required", AnswerValue = 3 },
                    new PossibleAnswer() { Text = "No", AnswerValue = 0 },
                }
            };
            Question question_7 = new Question() { Text = "Is it providing the menu in Braille?", PossibleAnswers =
                {
                    new PossibleAnswer() { Text = "Yes", AnswerValue = 5 },
                    new PossibleAnswer() { Text = "No", AnswerValue = 0 },
                }
            }; ;
            
            context.Questions.AddOrUpdate(x => x.Text, question_1);
            context.Questions.AddOrUpdate(x => x.Text, question_2);
            context.Questions.AddOrUpdate(x => x.Text, question_3);
            context.Questions.AddOrUpdate(x => x.Text, question_4);
            context.Questions.AddOrUpdate(x => x.Text, question_5);
            context.Questions.AddOrUpdate(x => x.Text, question_6);
            context.Questions.AddOrUpdate(x => x.Text, question_7);

            //Add a set of initial users

            var userstore = new UserStore<ApplicationUser>(context);
            ApplicationUserManager userManager = new ApplicationUserManager(userstore);
            var rolestore = new RoleStore<IdentityRole>(context);
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(rolestore);

            string email = "admin@gmail.gr";
            string username = "admin";
            string password = "Admin1!";
            var roleName = "Admin";
            var roleName2 = "Regular User";
            IdentityRole role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                roleManager.Create(role);
            }

            IdentityRole role2 = roleManager.FindByName(roleName2);
            if (role2 == null)
            {
                role2 = new IdentityRole(roleName2);
                roleManager.Create(role2);
            }
            ApplicationUser user = userManager.FindByName(username);
            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = username,
                    Email = email
                };
                userManager.Create(user, password);
                if (!userManager.IsInRole(user.Id, roleName))
                {
                    userManager.AddToRole(user.Id, roleName);
                }
            }
                        
        }
    }
}
