using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WheelofAccess.Models
{
    public class ValidateDate : RangeAttribute
    {

        public ValidateDate(int start, int end)
          : base(typeof(DateTime),
                  DateTime.Now.AddYears(start).ToString(),
                  DateTime.Now.AddYears(end).ToString())
        { ErrorMessage = $"Age must be between {-end} and {-start} years old." + "Please choose a value for {0} between {1:d} and {2:d} "; }
    }
    
}