using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WheelofAccess.Models
{
    public class Review
    {
        public int Id { get; set; }
        public float? Rating { get; set; }
        public string Comment { get; set; }
        public virtual ICollection<Answer> Questionnaire { get; set; }
        public ApplicationUser User {get;set;}
        public string UserId { get; set; }        
        public int? PlaceId { get; set; }
        public Place Place { get; set; }

    }
}