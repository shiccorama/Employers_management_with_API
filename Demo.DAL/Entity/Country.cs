using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.DAL.Entity
{

    [Table("Country")]
    public class Country
    {

        [Key]
        public int Id { get; set; }
        public string CountryName { get; set; }

        public ICollection<City> City { get; set; }


    }
}
