using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WheelofAccess.Models;

namespace WheelofAccess.Chat_Service
{

    public class ChatController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Chat
        public ActionResult Index()
        {
            var users = db.Users.Where(x => x.UserName != User.Identity.Name).ToList();
            ViewBag.Users = new SelectList(users, "UserName", "UserName");
            return View();
        }
    }
}