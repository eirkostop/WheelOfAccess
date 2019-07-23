using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WheelofAccess.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int Givenanswer { get; set; }
<<<<<<< Updated upstream
        public virtual Question Question_Id { get; set; } 
=======
        [DisplayName("Question")]
        public string Question_Title { get; set; }
        public virtual Question Question { get; set; }
        
>>>>>>> Stashed changes
    }
}