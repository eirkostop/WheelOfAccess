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
            var panswers = db.GetAnswerOptions();
            return View(panswers);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PossibleAnswer possible)
        {
            if (!ModelState.IsValid)
            {
                return View(possible);
            }
            db.CreateOption(possible);
            return RedirectToAction("Create");
        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var opt=db.SearchOption(id);
            return View(opt);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PossibleAnswer opt)
        {
            if (!ModelState.IsValid)
            {
                return View(opt);
            }
            db.EditOption(opt);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var opt = db.SearchOption(id);
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