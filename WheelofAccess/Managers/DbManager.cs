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
                questions = db.Questions.ToList();
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
        public Question FindQuestion(string name)
        {
            Question question;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                question = db.Questions.Find(name);
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
                places = db.Places.ToList();
            }
            return places;
        }
        #endregion
    }
}