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
        [ForeignKey("Review")]
        public int? ReviewId { get; set; }
        public virtual Review Review { get; set; }
        [ForeignKey("PossibleAnswer")]
        public int PossibleAnswerId { get; set; }
        public virtual PossibleAnswer PossibleAnswer { get; set; }
    }
}