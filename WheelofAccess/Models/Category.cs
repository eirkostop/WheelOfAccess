﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WheelofAccess.Models
{
    public class Category
    {
        public Category()
        {
            TypesofPlace = new HashSet<Place>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        ICollection<Place> TypesofPlace { get; set; }
    }
}