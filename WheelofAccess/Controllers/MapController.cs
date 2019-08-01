using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WheelofAccess.Models;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;

namespace WheelofAccess.Controllers
{
    public class MapController : Controller
    {
        
        // GET: Map
        public ActionResult Index()
        {
            
            
            return View();
        }
    }
}