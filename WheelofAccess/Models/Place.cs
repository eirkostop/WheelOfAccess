using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WheelofAccess.Models
{
    public class Place
    {
        public Place()
        {
            CategoriesofPlace = new HashSet<Category>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Address {get;set;}
        [DisplayName("Category")]
        public virtual ICollection<Category> CategoriesofPlace { get; set; }
        public virtual ICollection<Review> StoreReviews { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}