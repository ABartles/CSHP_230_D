using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; // Added for entry validation

namespace BirthdayCardGenerator.Models
{
    public class CardFill
    {
        
        [Required(ErrorMessage = "Please enter From")] // Entry validation
        public string From { get; set; }

        [Required(ErrorMessage = "Please enter To")] // Entry validation
        public string To { get; set; }

        [Required(ErrorMessage = "Please enter Message")] // Entry validation
        public string Message { get; set; }
    }
}