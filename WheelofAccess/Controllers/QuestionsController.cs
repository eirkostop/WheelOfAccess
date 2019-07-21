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
    //[Authorize(Roles = "Admin")]
    public class QuestionsController : Controller
    {
        DbManager db = new DbManager();
        // GET: Questions
       // [Authorize(Roles =("Users , Admin"))]
        public ActionResult Index()
        {
            var questions=db.GetQuestions();
            return View(questions); 
        }

        public ActionResult Create()
        {
            ViewBag.AllOptions = new SelectList(db.GetAnswerOptions(), "Id","OptionName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Question question)
        {
            if (!ModelState.IsValid)
            {
                //ViewBag.AllOptions = new SelectList(db.GetAnswerOptions(), "Id","OptionName", "AnswerValue");

                return View(question);
            }
            db.AddQuestion(question);

            return RedirectToAction("Index");
        }
        public ActionResult Edit(string name)
        {

            var question=db.FindQuestion(name);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Question question)
        {
            if (!ModelState.IsValid)
            {
                return View(question);
            }
            db.EditQuestion(question);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string name)
        {
            var question=db.FindQuestion(name);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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