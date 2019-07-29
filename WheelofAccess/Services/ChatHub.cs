using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WheelofAccess.Chat_Service
{
    public class ChatHub : Hub
    {
        public void SentToUser(string to, string message)
        {
            Clients.User(to).gotMessage(Context.User.Identity.Name, message);
        }
    }
}