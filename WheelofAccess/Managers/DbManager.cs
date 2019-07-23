using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WheelofAccess.Models;

namespace WheelofAccess.Managers
{
    public class DbManager
    {
        #region Questions
        public ICollection<Question> GetQuestions()
        {
            ICollection<Question> questions;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                questions = db.Questions.Include("AllOptions").ToList();
            }
            return questions;
        }
        public void AddQuestion(Question question)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Questions.Add(question);
                db.SaveChanges();
                            
               
            }
        }
        public Question FindQuestion(int id)
        {
            Question question;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                question = db.Questions.Find(id);
            }
            return question;
        }
        public void EditQuestion(Question question)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Questions.Attach(question);
                db.Entry(question).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }            
        }
        public void DeleteQuestion(Question question)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Questions.Attach(question);
                db.Questions.Remove(question);
                db.SaveChanges();
            }
        }
        #endregion
        #region PossibleAnswer
        public ICollection<PossibleAnswer> GetAnswerOptions()
        {
            ICollection<PossibleAnswer> options;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                
                options=db.PossibleAnswers.ToList();
            }
            return options;
        }

        public void CreateOption(PossibleAnswer option)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.PossibleAnswers.Add(option);
                db.SaveChanges();
            }
        }
        public PossibleAnswer SearchOption(int id)
        {
            PossibleAnswer opt;
            using(ApplicationDbContext db =new ApplicationDbContext())
            {
                opt = db.PossibleAnswers.Find(id);
            }
            return opt;
        }
        public void EditOption(PossibleAnswer opt)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                db.PossibleAnswers.Attach(opt);
                db.Entry(opt).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void DeleteOption(PossibleAnswer opt)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                db.PossibleAnswers.Attach(opt);
                db.PossibleAnswers.Remove(opt);
                db.SaveChanges();
            }
        }
        #endregion
        #region Review
        public ICollection<Review> GetReviews(string Id)
        {
            ICollection<Review> reviews;
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                reviews = db.Reviews.Where(x=>x.UserId==Id).ToList();
            }
            return reviews;
        }
        public Review FindReview(int id)
        {
            Review review;
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                review = db.Reviews.Find(id);
            }
            return review;
        }
        public void CreateReview(Review review)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Reviews.Add(review);
                db.SaveChanges();
            }
        }
        public void EditReview(Review review)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Reviews.Attach(review);
                db.Entry(review).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void DeleteReview(Review review)
        {
            using(ApplicationDbContext db=new ApplicationDbContext())
            {
                db.Reviews.Attach(review);
                db.Reviews.Remove(review);
                db.SaveChanges();
            }
        }
        #endregion
        #region Places
        public ICollection<Place> GetPlaces()
        {
            ICollection<Place> places;
            using(ApplicationDbContext db=new ApplicationDbContext())
            {
                places = db.Places.Include("CategoriesofPlace").Include("StoreReviews").ToList();
            }
            return places;
        }
        public void AddPlace(Place place, List<int> categoryIds)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Places.Add(place);
                db.SaveChanges();
                foreach (var id in categoryIds)
                {
                    Category category = db.Categories.Find(id);
                    if (category != null)
                    {
                        place.CategoriesofPlace.Add(category);

                    }
                }
                db.SaveChanges();
            }
        }
        public Place FindPlace(int id)
        {
            Place place;
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                place = db.Places.Find(id);
            }
            return place;
        }
        public Place GetPlaceDetails(int id)
        {
            Place result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                result = db.Places.Include("StoreReviews")
                                  .Include("CategoriesofPlace")
                                  .Where(x => x.Id == id).FirstOrDefault();

            }
            return result;
        }
        public void EditPlace(Place place, List<int> categoriesIds)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Places.Attach(place);

                db.Entry(place).Collection("CategoriesofPlace").Load();
                place.CategoriesofPlace.Clear();
                db.SaveChanges();
                foreach (var id in categoriesIds)
                {

                    Category category = db.Categories.Find(id);

                    if (place != null)
                    {


                        place.CategoriesofPlace.Add(category);

                    }
                }
                db.SaveChanges();

                db.Entry(place).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void DeletePlace(Place place)
        {
            
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Places.Attach(place);
                db.Entry(place).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        #endregion
        #region Category
        public ICollection<Category> GetCategories()
        {
            ICollection<Category> category;
            using(ApplicationDbContext db =new ApplicationDbContext())
            {
                category = db.Categories.ToList();
            }
            return category;
        }
        public void CreateCategory(Category category)
        {
            
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Categories.Add(category);
                db.SaveChanges();
            }            
        }
        public Category FindCategory(int id)
        {
            Category category;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                category = db.Categories.Find(id);
            }
            return category;
        }
        public void EditCategory(Category category)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Categories.Attach(category);
                db.Entry(category).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void DeleteCategory(Category category)
        {
            using(ApplicationDbContext db =new ApplicationDbContext())
            {
                db.Categories.Attach(category);
                db.Categories.Remove(category);
                db.SaveChanges();
            }
        }
        #endregion
        #region Answer

        #endregion
        

    }
}