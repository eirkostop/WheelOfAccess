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
        public ActionResult Create()
        {
            ViewBag.Question_Title = new SelectList(db.GetQuestions(), "Id", "Title");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OptionName,AnswerValue,Question_Title")] PossibleAnswer possible)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Question_Title = new SelectList(db.GetQuestions(), "Id", "Title");

                return Json(possible);
            }
            db.CreateOption(possible);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var opt = db.SearchOption(id);

            if (opt == null)
            {
                return HttpNotFound();
            }
            ViewBag.Question_Title = new SelectList(db.GetQuestions(), "Id", "Title");

            return View(opt);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OptionName,AnswerValue,Question_Title")]PossibleAnswer opt)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Question_Title = new SelectList(db.GetQuestions(), "Id", "Title"); 

                return View(opt);
            }
            db.EditOption(opt);
            return RedirectToAction("Index");
        }
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