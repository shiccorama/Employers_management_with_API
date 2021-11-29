using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Demo.BL.Models
{
    public class DepartmentVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Department Name Required")]
        [MinLength(3,ErrorMessage = "Min 3")]
        [MaxLength(50, ErrorMessage = "Max 50")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Department Code Required")]
        public string DepartmentCode { get; set; }

    }
}
