using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WheelofAccess.Managers;
using WheelofAccess.Models;

namespace WheelofAccess.Controllers
{
    public class AnswersController : Controller
    {
        DbManager db = new DbManager();
        // GET: Answers
        public ActionResult Index()
        {
            var answer = db.GetAnswers();
            return View(answer);
        }
        public ActionResult Create()
        {
            ViewBag.Question_Name = new SelectList(db.GetQuestions(), "Id", "Title");

            return View();
        }
        [HttpPut]
        [ActionName("Answer")]
        public JsonResult Create(Answer answer)
        {

            //if (!ModelState.IsValid)
            //{
            //    ViewBag.Question_Name = new SelectList(db.GetQuestions(), "Id", "Title");

            //    return Json(answer);
            //}
            db.AddAnswer(answer);
            return Json(answer);
        }
    }
}