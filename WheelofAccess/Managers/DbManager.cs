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
            using(ApplicationDbContext db=new ApplicationDbContext())
            {
                db.PossibleAnswers.Add(option);
                db.SaveChanges();
            }
        }
        public PossibleAnswer SearchOption(string id)
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
        #region Answer
        public void CreateAnswer()
        {

        }
        #endregion
    }
}