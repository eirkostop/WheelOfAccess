using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WheelofAccess.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int Givenanswer { get; set; }
        
        public string QuestionTitle { get; set; }
        public virtual Question Question_Id { get; set; } 
    }
}