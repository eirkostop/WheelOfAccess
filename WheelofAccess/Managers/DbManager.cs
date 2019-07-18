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
        //public ICollection<PossibleAnswer> GetAnswerOptions()
        //{
        //    using(ApplicationDbContext db=new ApplicationDbContext())
        //    {
                
        //    }
        //}
        #endregion
    }
}