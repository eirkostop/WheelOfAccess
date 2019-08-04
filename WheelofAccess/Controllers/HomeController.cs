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
        
          

    }
}