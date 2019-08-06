using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [Authorize(Roles ="Admin")]
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
        public async Task<JsonResult> Create(Answer answer)
        {

            if (!ModelState.IsValid)
            {

                return Json(answer);
            }
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                db.Answers.Add(answer);
                await db.SaveChangesAsync();


            }            
            return Json(answer);
        }

        
    }
}