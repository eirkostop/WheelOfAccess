using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WheelofAccess.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public bool? YesorNo { get; set; }
        public string? Text { get; set; }
        public ICollection<int>? Multiplechoice { get; set; }
    }
}