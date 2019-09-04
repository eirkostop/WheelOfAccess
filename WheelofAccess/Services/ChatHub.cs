using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using WheelofAccess.Models;

namespace WheelofAccess.Chat_Service
{
    public class ChatHub : Hub
    {
        public void sendToUser(string to, string message)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            ApplicationUser user = db.Users.Find(Context.User.Identity.GetUserId());
            Clients.User(to).gotMessage(Context.User.Identity.Name, message,user.ProfilePic);
        }
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}