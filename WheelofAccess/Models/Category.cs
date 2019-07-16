using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WheelofAccess.Models
{
    public class Category
    {
        public bool Cafe { get; set; }
        public bool Restaurant { get; set; }
        public bool Bar { get; set; }
        ICollection<Place> TypesofPlace { get; set; }
    }
}