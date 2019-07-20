using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WheelofAccess.Models;
using WheelofAccess.Managers;

namespace WheelofAccess.Controllers
{
    public class ReviewsController : Controller
    {
        private DbManager db = new DbManager();

        // GET: Reviews
        public ActionResult Index()
        {
            return View();
        }      

        // GET: Reviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Review review)
        {
            if (!ModelState.IsValid)
            {
                return View(review);
            }
            db.CreateReview(review);           
           
            return RedirectToAction("Index");          
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int id)
        {
            var review = db.FindReview(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Review review)
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
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Review review)
        {
            if (!ModelState.IsValid)
            {
                return View(review);
            }
            db.DeleteReview(review);
            return RedirectToAction("Index");
        }  
    }
}
