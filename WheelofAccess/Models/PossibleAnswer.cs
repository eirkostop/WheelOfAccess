using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WheelofAccess.Models
{
    public class PossibleAnswer
    {
        [Key]
        public string OptionName { get; set; }
        public int AnswerValue { get; set; }
    }
}