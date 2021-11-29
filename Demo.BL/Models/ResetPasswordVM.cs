using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.BL.Models
{
    public class ResetPasswordVM
    {

        [Required(ErrorMessage = "Enter Password")]
        [StringLength(8, ErrorMessage = "Min Len 8")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [StringLength(8, ErrorMessage = "Min Len 8")]
        [Compare("Password", ErrorMessage = "Not Match")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
        public string Email { get; set; }


    }
}
