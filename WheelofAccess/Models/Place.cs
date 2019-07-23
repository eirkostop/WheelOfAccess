using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WheelofAccess.Models
{
    public class Place
    {
<<<<<<< Updated upstream
=======
        public Place()
        {
            CategoriesofPlace = new HashSet<Category>();
            StoreReviews = new HashSet<Review>();
        }
>>>>>>> Stashed changes
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Address {get;set;}

        public virtual ICollection<Category> CategoriesofPlace { get; set; }
        public virtual ICollection<Review> StoreReviews { get; set; }
    }
}