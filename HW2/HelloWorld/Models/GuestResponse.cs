using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;    // Added to allow validation below

namespace HelloWorld.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Please enter your name")] // Validation
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")] // Validation
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter your email")] // Validation
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please enter attendance")] // Validation
        public bool? WillAttend { get; set; }
    }
}