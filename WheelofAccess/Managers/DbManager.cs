using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WheelofAccess.Models;
using System.Data.Entity;
using WheelofAccess.View_Models;

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
                questions = db.Questions.Include("PossibleAnswers").ToList();
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
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Questions.Attach(question);
                db.Entry(question).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void DeleteQuestion(Question question)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
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

                options = db.PossibleAnswers.Include("Question").ToList();
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
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                opt = db.PossibleAnswers.Find(id);
            }
            return opt;
        }
        public void EditOption(PossibleAnswer opt)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.PossibleAnswers.Attach(opt);
                db.Entry(opt).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void DeleteOption(PossibleAnswer opt)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.PossibleAnswers.Attach(opt);
                db.PossibleAnswers.Remove(opt);
                db.SaveChanges();
            }
        }
        #endregion
        #region Review
        // Μόνο του χρήστη τα Reviews
        public ICollection<Review> GetUsersReviews(string Id)
        {
            ICollection<Review> reviews;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                reviews = db.Reviews.Include(x => x.Place).Include(x=>x.Questionnaire).Where(x => x.UserId == Id).ToList();
            }
            return reviews;
        }
        //Ola ta Reviews
        public ICollection<Review> GetReviews()
        {
            ICollection<Review> reviews;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                reviews = db.Reviews.ToList();
            }
            return reviews;
        }
        // όλα τα reviews ανα κατάστημα
        public ICollection<Review> GetplaceReviews(int placeId)
        {
            ICollection<Review> reviews;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                reviews = db.Reviews.Where(x => x.PlaceId == placeId).ToList();
            }
            return reviews;
        }

        public Review FindReview(int id)
        {
            Review review;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                review = db.Reviews.Find(id);
            }
            return review;
        }
        public void CreateReview(Review review)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Reviews.Add(review);
                db.SaveChanges();
            }
        }
        public void EditReview(Review review)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var r=db.Reviews.Find(review.Id);
                r.Comment = review.Comment;
                db.SaveChanges();
            }
        }
        public void DeleteReview(Review review)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                foreach (var item in db.Answers.Where(x=>x.ReviewId == review.Id))
                {
                    
                        db.Answers.Remove(item);
                    
                }
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
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                places = db.Places.Include("PlaceCategories").Include("PlaceReviews").ToList();
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
                        place.PlaceCategories.Add(category);

                    }
                }
                db.SaveChanges();
            }
        }
        public Place FindPlace(int id)
        {
            Place place;
            using (ApplicationDbContext db = new ApplicationDbContext())
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
                result = db.Places.Include("PlaceCategories")
                                  .Include("PlaceReviews")
                                  .Include("Users")                                  
                                  .Where(x => x.Id == id).FirstOrDefault();

            }
            return result;
        }
        public void EditPlace(Place place, List<int> categoriesIds)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Places.Attach(place);

                db.Entry(place).Collection("PlaceCategories").Load();
                place.PlaceCategories.Clear();
                db.SaveChanges();
                foreach (var id in categoriesIds)
                {

                    Category category = db.Categories.Find(id);

                    if (place != null)
                    {


                        place.PlaceCategories.Add(category);

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

                var reviews = db.Reviews.Where(x => x.PlaceId == place.Id);
                db.Reviews.RemoveRange(reviews);
                var answers = from a in db.Answers
                              join r in db.Reviews on a.ReviewId equals r.Id
                              join p in db.Places on r.PlaceId equals p.Id
                              where p.Id == place.Id
                              select a;
                db.Answers.RemoveRange(answers);

                db.Places.Attach(place);

                db.Places.Remove(place);
                db.SaveChanges();
            }
        }
        #endregion
        #region Category
        public ICollection<Category> GetCategories()
        {
            ICollection<Category> category;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                category = db.Categories.ToList();
            }
            return category;
        }
        public void CreateCategory(Category category)
        {

            using (ApplicationDbContext db = new ApplicationDbContext())
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
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Categories.Attach(category);
                db.Entry(category).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void DeleteCategory(Category category)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Categories.Attach(category);
                db.Categories.Remove(category);
                db.SaveChanges();
            }
        }
        #endregion
        #region Answer
        public ICollection<Answer> GetAnswers()
        {
            ICollection<Answer> questions;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                questions = db.Answers.Include("PossibleAnswer").Include(x => x.Review).ToList();

            }
            return questions;
        }
      
        public Answer FindAnswer(int id)
        {
            Answer question;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                question = db.Answers.Find(id);
            }
            return question;
        }
        public void EditAnswer(Answer option)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Answers.Attach(option);
                db.Entry(option).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void DeleteAnswer(Answer answer)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Answers.Attach(answer);
                db.Answers.Remove(answer);
                db.SaveChanges();
            }
        }

        #endregion
        #region Search 
        public ICollection<Place> SearchPlace(string search, string name, int sortBy)
        {
            List<Place> result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var query = db.Places.AsQueryable();
                if (!String.IsNullOrEmpty(search))
                {
                    query = query.Where(x => x.Address.Contains(search));
                }
                if (!String.IsNullOrEmpty(name))
                {
                    query = query.Where(x => x.Name == name);
                }
                switch ((SortOptions)sortBy)
                {
                    case SortOptions.Address:
                        query = query.OrderBy(x => x.Address);
                        break;
                    case SortOptions.Name:
                        query = query.OrderBy(x => x.Name);
                        break;
                    default:
                        break;
                }
                result = query.ToList();
            }
            return result;
        }
        #endregion
       


    }
}