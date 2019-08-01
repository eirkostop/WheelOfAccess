﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WheelofAccess
{
    public class ChatHub : Hub
    {
        public void sendToUser(string to, string message)
        {
            Clients.User(to).gotMessage(Context.User.Identity.Name, message);
        }
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}