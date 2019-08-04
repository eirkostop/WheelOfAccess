using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WheelofAccess.Chat_Service
{
    public class ChatHub : Hub
    {
        public void sendToUser(string to, string message, byte[] senderprofilepic )
        {
            Clients.User(to).gotMessage(Context.User.Identity.Name, message);
        }
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}