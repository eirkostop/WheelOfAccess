using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WheelofAccess.Models
{
    public class Answer
    {
        public int Id { get; set; }
        //public int AnswerValue { get; set; }
        [ForeignKey("Question")]
        public int? Question_Name { get; set; }
        public virtual Question Question { get; set; }

        [ForeignKey("PossibleAnswer")]
        public int Option_ID { get; set; }
        public virtual PossibleAnswer PossibleAnswer { get; set; }

    }
}