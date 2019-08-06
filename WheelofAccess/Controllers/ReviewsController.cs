using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WheelofAccess.Models;
using WheelofAccess.Managers;

namespace WheelofAccess.Controllers
{
    [Authorize] 
    public class ReviewsController : Controller
    {
        private DbManager db = new DbManager();

        // GET: Reviews
        public ActionResult Index()
        {
            var id =User.Identity.GetUserId();
            var reviews =db.GetUsersReviews(id);
            return View(reviews);
        }      

        // GET: Reviews/Create
        public ActionResult Create()
        {
            ViewBag.PlaceId = new SelectList(db.GetPlaces(), "Id", "Name");

            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Comment,PlaceId")] Review review)
        {
            if (!ModelState.IsValid)
            {
                return View(review);
            }
            review.UserId=User.Identity.GetUserId();
           
            db.CreateReview(review);
            ViewBag.PlaceId = new SelectList(db.GetPlaces(), "Id", "Name");
            return RedirectToAction("Index");          
        }
      
        [HttpGet]
        // GET: Reviews/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Questions = db.GetQuestions();
            


            var review = db.FindReview(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            if (review.UserId != User.Identity.GetUserId())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            ViewBag.PlaceId = new SelectList(db.GetPlaces(), "Id", "Name");
            ViewBag.PlaceName = db.GetPlaces().Where(p => p.Id == review.PlaceId).FirstOrDefault().Name;
            return View(review);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Review review)
        {
            if (!ModelState.IsValid)
            {
                return View(review);
            }
            db.EditReview(review);
            return RedirectToAction("Index");

        }
        

        

        // GET: Reviews/Delete/5
        public ActionResult Delete(int id)
        {
            var review = db.FindReview(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            if (review.UserId != User.Identity.GetUserId())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([Bind(Include = "Id,Rating,Comment,PlaceId")]Review review)
        {
            if (!ModelState.IsValid)
            {
                return View(review);
            }
            review.UserId=User.Identity.GetUserId();
            db.DeleteReview(review);
            return RedirectToAction("Index");
        }  
    }
}
