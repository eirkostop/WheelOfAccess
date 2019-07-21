using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WheelofAccess.Models;

namespace WheelofAccess.View_Models
{
    public class PlaceViewModel
    {
        //public ApplicationUser user { get; set; }
        public Place Place { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        private List<int> _selectedCategories;
        public List<int> SelectedCategories
        {
            get
            {
                if (_selectedCategories == null)
                {
                    return Place.CategoriesofPlace.Select(x => x.Id).ToList();

                }
                return _selectedCategories;

            }
            set
            {
                _selectedCategories = value;
            }
        }
    }
}