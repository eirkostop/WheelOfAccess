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
        public string Answer { get; set; }
        [DisplayName("Answer Score")] 
        public int AnswerValue { get; set; }

        [ForeignKey("Question")]
        public int QuestionId{ get; set; }
        public virtual Question Question { get; set; }
    }
}