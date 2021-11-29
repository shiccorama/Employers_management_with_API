using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.BL.Models
{
    public class ForgetPasswordVM
    {
        [Required(ErrorMessage = "Enter Mail")]
        [EmailAddress(ErrorMessage = "Invalid Mail Address")]
        public string Email { get; set; }

    }
}
