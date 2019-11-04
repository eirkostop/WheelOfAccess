using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WheelofAccess.Managers;
using WheelofAccess.Models;

namespace WheelofAccess.Controllers
{
    public class PossibleAnswersController : Controller
    {
        DbManager db = new DbManager();

        // GET: PossibleAnswers
        public ActionResult Index()
        {
             var answers = db.GetAnswerOptions();
            return View(answers);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.QuestionText = new SelectList(db.GetQuestions(), "Id", "Text");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,Answer,AnswerValue,QuestionId")] PossibleAnswer possible)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.QuestionText = new SelectList(db.GetQuestions(), "Id", "Text");

                return Json(possible);
            }
            db.CreateOption(possible);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var opt = db.SearchOption(id);

            if (opt == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionText = new SelectList(db.GetQuestions(), "Id", "Text");

            return View(opt);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Answer,AnswerValue,QuestionId")]PossibleAnswer opt)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.QuestionText = new SelectList(db.GetQuestions(), "Id", "Text"); 

                return View(opt);
            }
            db.EditOption(opt);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var opt = db.SearchOption(id);

            if (opt == null)
            {
                return HttpNotFound();
            }

            return View(opt);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(PossibleAnswer opt)
        {
            if (!ModelState.IsValid)
            {
                return View(opt);
            }
            db.DeleteOption(opt);
            return RedirectToAction("Index");
        }
    }
}