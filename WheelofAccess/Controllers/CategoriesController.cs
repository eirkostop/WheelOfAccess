using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WheelofAccess.Managers;
using WheelofAccess.Models;

namespace WheelofAccess.Controllers
{
    public class CategoriesController : Controller
    {
        DbManager db = new DbManager();
        // GET: Categories
        public ActionResult Index()
        {
            var categories = db.GetCategories();
            return View(categories);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            db.CreateCategory(category);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var category = db.FindCategory(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            db.EditCategory(category);
            return RedirectToAction("Index");

        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var category = db.FindCategory(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Category category)
        {
            db.DeleteCategory(category);
            return RedirectToAction("Index");
        }
    }
}