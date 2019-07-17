using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;


namespace WheelofAccess.Models
{
    public enum selection
    {
        Checkbox=1,
        ListBox,
        Text,
        Dropdown
        
    }

    public class Question
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public selection AnswerType { get; set; }
        public int Answer { get; set; }
        
       
        

       
    }
} 