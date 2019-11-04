using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WheelofAccess.Models
{
    

    public class Question
    {
        public Question()
        {
            PossibleAnswers=new HashSet<PossibleAnswer>();
        }                               
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual ICollection<PossibleAnswer> PossibleAnswers { get; set; }
       
    }
} 