using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WheelofAccess.Models;

namespace WheelofAccess.Controllers
{
    [Authorize]
    public class QuestionsController : Controller
    {
        // GET: Questions
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
           
            return View();
        }
    }
}