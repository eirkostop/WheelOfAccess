using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WheelofAccess.Managers;
using WheelofAccess.Models;
using System.Data.Entity.Infrastructure;

namespace WheelofAccess.Controllers
{
    public class QuestionsController : Controller
    {
        DbManager db = new DbManager();
        // GET: Questions
        [Authorize]
        public ActionResult Index()
        {            
            var questions=db.GetQuestions();
            return View(questions); 
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.PossibleAnswers = new SelectList(db.GetAnswerOptions(), "Id","Answer");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Question question)
        {
            if (!ModelState.IsValid)
            {
                return View(question);
            }
            db.AddQuestion(question);

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {

            var question=db.FindQuestion(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Question question)
        {
            if (!ModelState.IsValid)
            {
                return View(question);
            }
            db.EditQuestion(question);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var question=db.FindQuestion(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Question question)
        {
            if (!ModelState.IsValid)
            {
                return View(question);
            }
            db.DeleteQuestion(question);
            return RedirectToAction("Index");
        }

      
    }
}