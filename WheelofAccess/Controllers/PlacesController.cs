using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WheelofAccess.Managers;
using WheelofAccess.Models;
using WheelofAccess.View_Models;

namespace WheelofAccess.Controllers
{
    public class PlacesController : Controller
    {
        DbManager db = new DbManager();
        // GET: Places
        public ActionResult Index()
        {
            var places = db.GetPlaces();
            return View(places);
        }
        public ActionResult Create()
        {
            PlaceViewModel vm = new PlaceViewModel()
            {
                Place = new Place(),
                Categories = db.GetCategories().Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })

            };

            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlaceViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            db.AddPlace(vm.Place, vm.SelectedCategories);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var place = db.GetPlaceDetails(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            PlaceViewModel vm = new PlaceViewModel()
            {
                Place = place,
                Categories = db.GetCategories().Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlaceViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            db.EditPlace(vm.Place, vm.SelectedCategories);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var place = db.GetPlaceDetails(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            PlaceViewModel vm = new PlaceViewModel()
            {
                Place = place,
                Categories = db.GetCategories().Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Place place)
        {
            db.DeletePlace(place);
            return RedirectToAction("Index");
        }      

        
    }
}
    
