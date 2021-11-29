using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.DAL.Entity
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string DepartmentName { get; set; }

        [StringLength(50)]
        [Required]
        public string DepartmentCode { get; set; }

    }
}
