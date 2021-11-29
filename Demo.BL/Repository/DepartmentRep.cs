using Demo.BL.Interfaces;
using Demo.BL.Models;
using Demo.DAL.Database;
using Demo.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.BL.Repository
{
    public class DepartmentRep : IDepartmentRep
    {


        private readonly DemoContext db;

        public DepartmentRep(DemoContext _db)
        {
            db = _db;
        }


        public IEnumerable<Department> Get()
        {
            var data = db.Department.Select(a => a);
            return data;
        }

        public Department GetById(int id)
        {
            var data = db.Department.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }

        public void Create(Department obj)
        {
            db.Department.Add(obj);
            db.SaveChanges();
        }


        public void Update(Department obj)
        {

            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();

        }

        public void Delete(Department obj)
        {
            db.Department.Remove(obj);
            db.SaveChanges();
        }

        public IEnumerable<Department> SearchByName(string Name)
        {
            var data = db.Department.Where(x => x.DepartmentName.Contains(Name)).Select(x => x);
            return data;
        }
    }
}
