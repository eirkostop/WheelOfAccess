using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WheelofAccess.Models
{

    [DisplayName("Answer")]
    public class PossibleAnswer
    {
        public int Id { get; set; }
        [DisplayName("Answer")]
        public string Text { get; set; }
        [DisplayName("Value (0-5)")] 
        public int AnswerValue { get; set; }
        [ForeignKey("Question")]
        public int QuestionId{ get; set; }
        public virtual Question Question { get; set; }
    }
}