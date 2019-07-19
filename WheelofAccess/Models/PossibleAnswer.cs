using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WheelofAccess.Models
{
    public class PossibleAnswer
    {
        public int Id { get; set; }
        [DisplayName("Option")]
        public string OptionName { get; set; }
        [DisplayName("Answer Score")]
        public int AnswerValue { get; set; }
    }
}