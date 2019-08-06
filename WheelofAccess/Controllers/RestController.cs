using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WheelofAccess.Managers;
using WheelofAccess.Models;

namespace WheelofAccess.Controllers
{
    public class RestController : Controller
    {
        private ApplicationDbContext vm = new ApplicationDbContext();
       

        [HttpGet]
        [ActionName("Ratings")]
        public JsonResult GetRatings()
        {
           
            var ratings = vm.Places.Select(x => 
             new {
                 Name=x.Name,
                Id=x.Id,
                GoogleId=x.GoogleId,
                Rating = x.Rating.ToString()
            });
            return Json(ratings, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult UpdateRating(int id)
        {
            //Update review rating
            Review review= vm.Reviews.Find(id);
            review.Rating = vm.Answers.Include(x => x.PossibleAnswer).Where(x => x.Review_Id == id).Select(x => (float?)x.PossibleAnswer.AnswerValue).Average();
            vm.Entry(review).State = EntityState.Modified;
            vm.SaveChanges();

            //Update place rating
            Place place = vm.Places.Where(x => x.Id == review.PlaceId).FirstOrDefault();
            var ratings = from pa in vm.PossibleAnswers
                           join a in vm.Answers on pa.Id equals a.Option_ID
                           join r in vm.Reviews on a.Review_Id equals r.Id
                           join p in vm.Places on r.PlaceId equals p.Id
                           where p.Id == place.Id
                           select ((float)pa.AnswerValue);
            place.Rating = ratings.DefaultIfEmpty(0f).Average();
            vm.Entry(place).State = EntityState.Modified;
            vm.SaveChanges();

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

        [HttpPut]
        [ActionName("Review")]
        public async Task<JsonResult> addReview(string googleId)
        {
            var userId = User.Identity.GetUserId();
            var place=vm.Places.Where(p=>p.GoogleId==googleId).FirstOrDefault();
            if (!vm.Reviews.Any(x => x.PlaceId == place.Id && x.UserId == userId))
            {
                Review newReview = new Review();
                newReview.PlaceId = place.Id;
                newReview.UserId = userId;
                vm.Reviews.Add(newReview);
                await vm.SaveChangesAsync();
                return Json(newReview.Id);
            }
            else
            {
                var review = vm.Reviews.Where(x=>x.PlaceId==place.Id).FirstOrDefault();
                return Json(review.Id);
            }            
        }

        [HttpPut]
        [ActionName("Place")]
        public JsonResult addPlace(Place place)
        {
            
            Place p = vm.Places.Where(x => x.GoogleId == place.GoogleId).FirstOrDefault();
            if (p == null)
            {
                vm.Places.Add(place);
                vm.SaveChanges();
                return Json(place);
            }
            else
            {
                return Json("error");
            }
            
        }
        [HttpGet]
        [ActionName("Places")]
        public JsonResult GetPlaces()
        {
            var places=vm.Places.Select(x => new
            {
                GoogleId = x.GoogleId,
                Id=x.Id
            });
            return Json(places, JsonRequestBehavior.AllowGet);
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