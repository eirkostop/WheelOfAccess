using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WheelofAccess.Models;

namespace WheelofAccess.View_Models
{
    public enum SortOptions
    {
        None,
        Address,
        Name,

    }
    public class SearchViewModel
    {
        public IEnumerable<Place> Places { get; set; }
        public SortOptions SortBy { get; set; }
        public string Search { get; set; }
    }
}