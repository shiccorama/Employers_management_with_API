using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Demo.BL.Models
{
    public class RegistrationVM
    {

        [Required(ErrorMessage = "Enter Mail")]
        [EmailAddress(ErrorMessage = "Invalid Mail Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [StringLength(8,ErrorMessage = "Min Len 8")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [StringLength(8, ErrorMessage = "Min Len 8")]
        [Compare("Password", ErrorMessage = "Not Match")]
        public string ConfirmPassword { get; set; }


    }
}
