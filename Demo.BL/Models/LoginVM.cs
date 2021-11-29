using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Demo.BL.Models
{
    public class LoginVM
    {

        [Required(ErrorMessage = "Enter Mail")]
        [EmailAddress(ErrorMessage = "Invalid Mail Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [StringLength(8, ErrorMessage = "Min Len 8")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
