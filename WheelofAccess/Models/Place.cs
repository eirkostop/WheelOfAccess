using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WheelofAccess.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Address {get;set;}

        ICollection<Category> CategoriesofPlace { get; set; }
    }
}