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
        private ApplicationDbContext db = new ApplicationDbContext();
       

        [HttpGet]
        [ActionName("Ratings")]
        public JsonResult GetRatings()
        {
           
            var ratings = db.Places.Select(x => 
             new {
                 Name=x.Name,
                Id=x.Id,
                GoogleId=x.GoogleId,
                Rating = x.Rating.ToString()
            });
            return Json(ratings, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        [ActionName("Answers")]
        public JsonResult GetAnswers()
        {
            var answers = db.Answers.Select(x => new { PossibleAnswerId = x.PossibleAnswerId, ReviewId=x.ReviewId }) ;

            return Json(answers, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult UpdateRating(int id)
        {
            //Update review rating
            Review review= db.Reviews.Find(id);
            //review.Rating = db.Answers.Include(x => x.PossibleAnswer).Where(x => x.ReviewId == id)
            //                          .Select(x => (float)x.PossibleAnswer.AnswerValue).Average();
            var values = from pa in db.PossibleAnswers
                         join a in db.Answers on pa.Id equals a.PossibleAnswerId
                         join r in db.Reviews on a.ReviewId equals id
                         select ((float)pa.AnswerValue);
            review.Rating = (float)Math.Round(values.DefaultIfEmpty(0f).Average(),1);
            db.Entry(review).State = EntityState.Modified;
            db.SaveChanges();

            //Update place rating
            Place place = db.Places.Where(x => x.Id == review.PlaceId).FirstOrDefault();
            var ratings = from pa in db.PossibleAnswers
                           join a in db.Answers on pa.Id equals a.PossibleAnswerId
                           join r in db.Reviews on a.ReviewId equals r.Id
                           join p in db.Places on r.PlaceId equals p.Id
                           where p.Id == place.Id
                           select ((float)pa.AnswerValue);
            place.Rating = (float)Math.Round(ratings.DefaultIfEmpty(0f).Average(), 1);
            db.Entry(place).State = EntityState.Modified;
            db.SaveChanges();
            return Json(true);
        }
        [HttpPut]
        [ActionName("Answer")]
        public async Task<JsonResult> Create(Answer answer)
        {
            if (!ModelState.IsValid)
            {
                return Json(answer);
            }
            db.Answers.Add(answer);
            await db.SaveChangesAsync();
            return Json(answer);
        }


        [HttpDelete]
        [ActionName("Answer")]
        public JsonResult DeleteUserAnswerBool(int ReviewId, int QuestionId)
        {
            var ua = db.Answers.Where(x => x.PossibleAnswer.QuestionId == QuestionId && x.ReviewId == ReviewId).FirstOrDefault();
            var result = false;
            if (ua != null)
            {
                db.Answers.Remove(ua);
                db.SaveChanges();
                result = true;
            }
            return Json(result);
        }

        [HttpPut]
        [ActionName("Review")]
        public JsonResult addReview(string googleId)
        {
            var userId = User.Identity.GetUserId();
            var place=db.Places.Where(p=>p.GoogleId==googleId).FirstOrDefault();
            if (!db.Reviews.Any(x => x.PlaceId == place.Id && x.UserId == userId))
            {
                Review newReview = new Review();
                newReview.PlaceId = place.Id;
                newReview.UserId = userId;
                db.Reviews.Add(newReview);
                db.SaveChanges();
                return Json(newReview.Id);
            }
            else
            {
                var review = db.Reviews.Where(x=>x.PlaceId==place.Id && x.UserId == userId).FirstOrDefault();
                return Json(review.Id);
            }            
        }

        [HttpPut]
        [ActionName("Place")]
        public JsonResult addPlace(Place place)
         {           
            Place p = db.Places.Where(x => x.GoogleId == place.GoogleId).FirstOrDefault();
            if (p == null)
            {
                db.Places.Add(place);
                db.SaveChanges();
            }
            return Json(place);
            
        }
        [HttpGet]
        [ActionName("Places")]
        public JsonResult GetPlaces()
        {
            var places=db.Places.Select(x => new
            {
                GoogleId = x.GoogleId,
                Id=x.Id
            });
            return Json(places, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        [ActionName("Categories")]
        public JsonResult addCategories(string placeId, string placeCategories)
        {
            string[] categories = placeCategories.Split(",".ToCharArray());
            Place p = db.Places.Where(x => x.GoogleId == placeId).FirstOrDefault();
            foreach (var category in categories)
            {
                Category c=db.Categories.Where(x => x.Name == category).FirstOrDefault();
                if (c==null)
                {
                    c = new Category() { Name = category };
                    db.Categories.Add(c);
                }

                db.SaveChanges();
                p.Categories.Add(c);
            }
            return Json(placeCategories);

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}