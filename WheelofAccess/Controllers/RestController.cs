﻿using Microsoft.AspNet.Identity;
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
        private ApplicationDbContext vm = new ApplicationDbContext();
        // GET: Rest
        [HttpGet]

        public JsonResult UpdatePlaceRating(int id)
            
        {
            var place = vm.Places.Where(x => x.Id == id).FirstOrDefault();
            var reviews = vm.Reviews.Where(x => x.PlaceId == id).Select(x=>x.Id).ToList() ;
            var answers = vm.Answers.Where(x => reviews.Contains((int)x.Review_Id)).Select(x => x.Id).ToList();
            var average = vm.PossibleAnswers.Where(x => answers.Contains((int)x.Id)).Select(x=>x.AnswerValue).Average().ToString();
            return Json(average);

        }

        [HttpGet]
        [ActionName("Ratings")]
        public JsonResult GetRatings()
        {
            //string rating(int id)
            //{
            //    var reviews = vm.Reviews.Where(r => r.PlaceId == id).Select(r => r.Id).ToList();
            //    var answers = vm.Answers.Where(a => reviews.Contains((int)a.Review_Id)).Select(a => a.Id).ToList();
            //    var average = vm.PossibleAnswers.Where(pa => answers.Contains((int)pa.Id)).Select(pa => pa.AnswerValue).Average().ToString();
            //    return average;
            //}
            var ratings = vm.Places.Select(x => 
             new {
                Id=x.Id,
                GoogleId=x.GoogleId,
                Rating = x.Rating.ToString()});
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
            var reviews = vm.Reviews.Where(x => x.PlaceId == place.Id).Select(x => x.Id).ToList();
            var answers = vm.Answers.Where(x => reviews.Contains((int)x.Review_Id)).Select(x => x.Id).ToList();
            place.Rating = vm.PossibleAnswers.Select(x => (float)x.AnswerValue).Average();
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
        public JsonResult addReview(string googleId)
        {
            var userId = User.Identity.GetUserId();
            var place=vm.Places.Where(p=>p.GoogleId==googleId).FirstOrDefault();
            if (!vm.Reviews.Any(x => x.PlaceId == place.Id && x.UserId == userId))
            {
                Review newReview = new Review();
                newReview.PlaceId = place.Id;
                newReview.UserId = userId;
                vm.Reviews.Add(newReview);
                vm.SaveChanges();
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