 using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WheelofAccess.Managers;
using WheelofAccess.Models;

namespace WheelofAccess.Controllers
{
    public class RestController : Controller
    {
        ApplicationDbContext vm = new ApplicationDbContext();
        // GET: Rest
        [HttpPost]

        public JsonResult UpdateRating(int id)
        {
            Review review;
            
            {
                review = vm.Reviews.Find(id);
                review.Rating = vm.Answers.Include(x => x.PossibleAnswer).Where(x => x.Review_Id == id).Select(x => (float?)x.PossibleAnswer.AnswerValue).Average();
                vm.Entry(review).State = EntityState.Modified;
                vm.SaveChanges();
            }
            return Json(true);

        }
        [HttpDelete]
        [ActionName("ChangeAnswer")]
        public JsonResult DeleteUserAnswerBool(int ReviewId, int QuestionId)
        {
            var ua = vm.Answers.Where(x => x.PossibleAnswer.Question_Title == QuestionId && x.Review_Id == ReviewId).FirstOrDefault();
            var result = false;
            if (ua != null)
            {
                vm.Answers.Remove(ua);
                vm.SaveChanges();
                result = true;
            }
            return Json(result);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                vm.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}