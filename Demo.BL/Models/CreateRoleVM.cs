using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Demo.BL.Models
{
    public class CreateRoleVM
    {
        [Required]
        public string RoleName { get; set; }
    }
}
