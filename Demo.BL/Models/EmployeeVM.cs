using Demo.DAL.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Demo.BL.Models
{
    public class EmployeeVM
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Name Required")]
        [MaxLength(50,ErrorMessage = "Max Len 50")]
        [MinLength(3,ErrorMessage = "Min Len 3")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Salary Required")]
        [Range(2000,20000,ErrorMessage = "Range In 2000 : 20000")]
        public double Salary { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Insert Valid Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hire Date Required")]
        public DateTime HireDate { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Department Required")]
        public int DepartmentId { get; set; }
        public int DistrictId { get; set; }
        public string Photo { get; set; }
        public string Cv { get; set; }

        public IFormFile PhotoUrl { get; set; }
        public IFormFile CvUrl { get; set; }


        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public District District { get; set; }


    }
}
