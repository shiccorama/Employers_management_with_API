using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Demo.DAL.Entity
{

    [Table("Employee")]
    public class Employee
    {

        //public Employee()
        //{
        //    HireDate = DateTime.Now;
        //}

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public double Salary { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public string Photo { get; set; }
        public string Cv { get; set; }

        public int DepartmentId { get; set; }
        public int DistrictId { get; set; }


        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public District District { get; set; }


    }
}
