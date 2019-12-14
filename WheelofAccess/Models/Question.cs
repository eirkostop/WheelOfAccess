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
            Categories = new HashSet<Category>();
        }                               
        public int Id { get; set; }
        [DisplayName("Question")]
        public string Text { get; set; }
        public virtual ICollection<PossibleAnswer> PossibleAnswers { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
} 