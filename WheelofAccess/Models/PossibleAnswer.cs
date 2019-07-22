using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("Question")]
        public int Question_Title{ get; set; }
        public virtual Question Question { get; set; }
    }
}