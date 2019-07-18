﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WheelofAccess.Models
{
    

    public class Question
    {

        [Key]
        public string Title { get; set; }
        public virtual ICollection<PossibleAnswer> AllOptions { get; set; }
        public virtual ICollection<Answer> AllGivenAnswers { get; set; }
        
       
        

       
    }
} 