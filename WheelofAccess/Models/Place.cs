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
            Categories = new HashSet<Category>();
            PlaceReviews = new HashSet<Review>();
        }
        public int Id { get; set; }
        public string GoogleId { get; set; }
        public float Rating { get; set; }
        public string Name { get; set; }
        public string  Address {get;set;}
        [DisplayName("Category")]
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Review> PlaceReviews { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}