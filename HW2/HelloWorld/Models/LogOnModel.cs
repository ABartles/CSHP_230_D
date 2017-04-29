using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;    // Added

namespace HelloWorld.Models
{
    public class LogOnModel
    {
        [Required]  // Validating user enters data
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]  // Validating user enters data
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}