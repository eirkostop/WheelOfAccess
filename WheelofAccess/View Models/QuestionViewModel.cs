using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WheelofAccess.Models;

namespace WheelofAccess.View_Models
{
    public class QuestionViewModel
    {
        public ApplicationUser user { get; set; }
        public Question question { get; set; }
        public IEnumerable<SelectListItem> OptionsList { get; set; }
        private List<int> _selectedAnswer;
        public List<int> SelectedAnswer
        {
            get
            {
                if (_selectedAnswer == null)
                {
                    return question.AllOptions.Select(x => x.Id).ToList();

                }
                return _selectedAnswer;

            }
            set
            {
                _selectedAnswer = value;
            }
        }
    }
}