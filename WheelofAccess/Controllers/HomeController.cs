 using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using WheelofAccess.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using PayPal.Api;
using WheelofAccess.Services.Payment;

namespace WheelofAccess.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            //if (Request.IsAuthenticated)
            //{
            //    string userId = User.Identity.GetUserId();
            //    var myreviews = db.Reviews.Where(x => x.UserId == userId);
            //    ViewBag.Places = db.Places.Count();
            //    ViewBag.Reviews = db.Reviews.Count();
            //    ViewBag.Questions = db.Questions.Count();
            //    ViewBag.MyAnswers = myreviews.Select(x => db.Answers.Where(a => a.Review_Id == x.Id).Count()).Sum();
            //    ViewBag.MyReviews = myreviews.Count();
            //    ViewBag.Users = db.Users.Count();
            //}
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Unlogged()
        {

            return View();
        }
        //[Authorize]
        //public ActionResult Dashboard()
        //{
        //    string userId = User.Identity.GetUserId();
        //    var myreviews = db.Reviews.Where(x => x.UserId == userId);
        //    ViewBag.Places = db.Places.Count();
        //    ViewBag.MyReviews = myreviews.Count();
        //    ViewBag.Reviews = db.Reviews.Count();
        //    ViewBag.Questions = db.Questions.Count();
        //    ViewBag.MyAnswers = myreviews.Select(x => db.Answers.Where(a => a.Review_Id == x.Id).Count()).Sum();
        //    ViewBag.Users = db.Users.Count();
        //    return View();
        //}


    }
}