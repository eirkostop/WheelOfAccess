using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WheelofAccess.Models
{
    public class Review
    {
        public int Id { get; set; }
        public decimal Rating { get; set; }
        ICollection<Question> Questionnaire { get; set; }
    }
}