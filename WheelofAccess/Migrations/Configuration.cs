namespace WheelofAccess.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
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
            #region Initial set of Categories

            Dictionary<int, string> categories = new Dictionary<int, string>();
            categories.Add(1, "accounting");
            categories.Add(2, "airport");
            categories.Add(3, "amusement_park");
            categories.Add(4, "aquarium");
            categories.Add(5, "art_gallery");
            categories.Add(6, "atm");
            categories.Add(7, "bakery");
            categories.Add(8, "bank");
            categories.Add(9, "bar");
            categories.Add(10, "beauty_salon");
            categories.Add(11, "bicycle_store");
            categories.Add(12, "book_store");
            categories.Add(13, "bowling_alley");
            categories.Add(14, "bus_station");
            categories.Add(15, "cafe");
            categories.Add(16, "campground");
            categories.Add(17, "car_dealer");
            categories.Add(18, "car_rental");
            categories.Add(19, "car_repair");
            categories.Add(20, "car_wash");
            categories.Add(21, "casino");
            categories.Add(22, "cemetery");
            categories.Add(23, "church");
            categories.Add(24, "city_hall");
            categories.Add(25, "clothing_store");
            categories.Add(26, "convenience_store");
            categories.Add(27, "courthouse");
            categories.Add(28, "dentist");
            categories.Add(29, "department_store");
            categories.Add(30, "doctor");
            categories.Add(31, "drugstore");
            categories.Add(32, "electrician");
            categories.Add(33, "electronics_store");
            categories.Add(34, "embassy");
            categories.Add(35, "fire_station");
            categories.Add(36, "florist");
            categories.Add(37, "funeral_home");
            categories.Add(38, "furniture_store");
            categories.Add(39, "gas_station");
            categories.Add(40, "grocery_or_supermarket");
            categories.Add(41, "gym");
            categories.Add(42, "hair_care");
            categories.Add(43, "hardware_store");
            categories.Add(44, "hindu_temple");
            categories.Add(45, "home_goods_store");
            categories.Add(46, "hospital");
            categories.Add(47, "insurance_agency");
            categories.Add(48, "jewelry_store");
            categories.Add(49, "laundry");
            categories.Add(50, "lawyer");
            categories.Add(51, "library");
            categories.Add(52, "light_rail_station");
            categories.Add(53, "liquor_store");
            categories.Add(54, "local_government_office");
            categories.Add(55, "locksmith");
            categories.Add(56, "lodging");
            categories.Add(57, "meal_delivery");
            categories.Add(58, "meal_takeaway");
            categories.Add(59, "movie_rental");
            categories.Add(60, "movie_theater");
            categories.Add(61, "moving_company");
            categories.Add(62, "museum");
            categories.Add(63, "night_club");
            categories.Add(64, "painter");
            categories.Add(65, "park");
            categories.Add(66, "parking");
            categories.Add(67, "pet_store");
            categories.Add(68, "pharmacy");
            categories.Add(69, "physiotherapist");
            categories.Add(70, "plumber");
            categories.Add(71, "police");
            categories.Add(72, "post_office");
            categories.Add(73, "primary_school");
            categories.Add(74, "real_estate_agency");
            categories.Add(75, "restaurant");
            categories.Add(76, "roofing_contractor");
            categories.Add(77, "rv_park");
            categories.Add(78, "school");
            categories.Add(79, "secondary_school");
            categories.Add(80, "shoe_store");
            categories.Add(81, "shopping_mall");
            categories.Add(82, "spa");
            categories.Add(83, "stadium");
            categories.Add(84, "storage");
            categories.Add(85, "store");
            categories.Add(86, "subway_station");
            categories.Add(87, "supermarket");
            categories.Add(88, "synagogue");
            categories.Add(89, "taxi_stand");
            categories.Add(90, "tourist_attraction");
            categories.Add(91, "train_station");
            categories.Add(92, "transit_station");
            categories.Add(93, "travel_agency");
            categories.Add(94, "university");
            categories.Add(95, "veterinary_care");
            categories.Add(96, "zoo");

            foreach (KeyValuePair<int, string> pair in categories)
            {
                Category cat = new Category { Name = pair.Value };
                context.Categories.AddOrUpdate(x => x.Name, cat);

            }
            Category category_97 = new Category { Name = "zoo", Questions = context.Questions.ToList() };
            #endregion

            #region Initial set of Questions
            Question question_1 = new Question() { Text = "Does the pavement has a ramp?", PossibleAnswers = {
                    new PossibleAnswer() { Text = "Yes", AnswerValue = 5 },
                    new PossibleAnswer() { Text = "No", AnswerValue = 0 },
                },
                Categories = context.Categories.ToList()
            };
            Question question_2 = new Question()
            {
                Text = "Does the entrance has steps?",
                PossibleAnswers = {
                    new PossibleAnswer() { Text = "Yes", AnswerValue = 0 },
                    new PossibleAnswer() { Text = "No", AnswerValue = 5 }
                },
                Categories = context.Categories.ToList()
            };
            Question question_3 = new Question() { Text = "Does the entrance has a ramp?",
                PossibleAnswers = {
                    new PossibleAnswer() { Text = "Yes", AnswerValue = 5 },
                    new PossibleAnswer() { Text = "No", AnswerValue = 0 },
                },
                Categories = context.Categories.ToList()
            }; 
            Question question_4 = new Question() { Text = "Is it easy to move around?",
                PossibleAnswers = {
                    new PossibleAnswer() { Text = "Easy", AnswerValue = 5 },
                    new PossibleAnswer() { Text = "Somewhat Easy", AnswerValue = 3 },
                    new PossibleAnswer() { Text = "Hard", AnswerValue = 0 },
                },
                Categories = context.Categories.ToList()
            };
            Question question_5 = new Question() { Text = "The toilet is: ",
                PossibleAnswers = {
                    new PossibleAnswer() { Text = "Accessible", AnswerValue = 5 },
                    new PossibleAnswer() { Text = "Not accessible,on the same level and spacious", AnswerValue = 4 },
                    new PossibleAnswer() { Text = "Not accessible,on the same level with a spacious hall", AnswerValue = 3 },
                    new PossibleAnswer() { Text = "Different level or really small", AnswerValue = 0 },
                },
                Categories = context.Categories.ToList()
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
            };

            Question question_8 = new Question()
            {
                Text = "Is there any stuff properly trained in sign language?",
                PossibleAnswers =
                {
                    new PossibleAnswer() { Text = "Yes", AnswerValue = 5 },
                    new PossibleAnswer() { Text = "No", AnswerValue = 0 },
                },
                Categories = context.Categories.Where(x => x.Name == "pharmacy").ToList()

            };
            Question question_9 = new Question()
            {
                Text = "Test",
                PossibleAnswers =
                {
                    new PossibleAnswer() { Text = "Yes", AnswerValue = 5 },
                    new PossibleAnswer() { Text = "No", AnswerValue = 0 },
                },
                Categories = context.Categories.Where(x=>x.Name== "car_wash"||x.Name== "car_rental").ToList()

            };
            Question question_10 = new Question()
            {
                Text = "Test2",
                PossibleAnswers =
                {
                    new PossibleAnswer() { Text = "Yes", AnswerValue = 5 },
                    new PossibleAnswer() { Text = "No", AnswerValue = 0 },
                },
                Categories = context.Categories.Where(x => x.Name == "car_wash" || x.Name == "car_rental").ToList()

            };
            //List<Question> questions = new List<Question>();
            //questions.Add(question_1);
            //questions.Add(question_2);
            //questions.Add(question_3);
            //questions.Add(question_4);
            //questions.Add(question_5);
            //questions.Add(question_6);
            //questions.Add(question_7);
            //questions.Add(question_8);
            //questions.Add(question_9);
                      
            //questions.Add(question_10);

            //context.Questions.AddOrUpdate(x => new { x.Text, x.PossibleAnswers, x.Categories }, questions.ToArray());
            //context.SaveChanges();

            context.Questions.AddOrUpdate(x => x.Text, question_1);
            context.Questions.AddOrUpdate(x => x.Text, question_2);
            context.Questions.AddOrUpdate(x => x.Text, question_3);
            context.Questions.AddOrUpdate(x => x.Text, question_4);
            context.Questions.AddOrUpdate(x => x.Text, question_5);
            context.Questions.AddOrUpdate(x => x.Text, question_6);
            context.Questions.AddOrUpdate(x => x.Text, question_7);
            context.Questions.AddOrUpdate(x => x.Text, question_8);
            context.Questions.AddOrUpdate(x => x.Text, question_9);

            context.Questions.AddOrUpdate(x => x.Text, question_10);

            context.PossibleAnswers.AddOrUpdate(new PossibleAnswer { Text = "Maybe3", AnswerValue = 3, Question = question_10 });
            #endregion



            #region Add a set of initial users

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
            #endregion

        }
    }
}
