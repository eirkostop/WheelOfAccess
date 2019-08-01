using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
            var users = ApplicationUsers.LoggedInUsers;
            ViewBag.Users = new SelectList(users, "Name", "Name");
            return View();
        }
    }
   
    public static class ApplicationUsers
    {
        public static List<ChatUsersViewModel> LoggedInUsers { get; } = new List<ChatUsersViewModel>();
    }
}