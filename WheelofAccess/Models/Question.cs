using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WheelofAccess.Models
{

    public class Question
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string QuestionBody { get; set; }
        public virtual Answer SelectedAnswer {get;set;}
       
    }
} 