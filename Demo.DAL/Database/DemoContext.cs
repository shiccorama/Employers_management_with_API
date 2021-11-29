using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Demo.DAL.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Demo.DAL.Database
{
    public class DemoContext : IdentityDbContext
    {


        public DemoContext(DbContextOptions<DemoContext> opts) : base(opts){ }

        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }



    }
}
