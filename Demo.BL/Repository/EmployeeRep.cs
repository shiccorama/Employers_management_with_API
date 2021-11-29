using Demo.BL.Interfaces;
using Demo.DAL.Database;
using Demo.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.BL.Repository
{
    public class EmployeeRep : IEmployeeRep
    {

        private readonly DemoContext db;

        public EmployeeRep(DemoContext _db)
        {
            db = _db;
        }


        public IEnumerable<Employee> Get()
        {
            var data =  db.Employee.Include("Department").Select(a => a);
            return data;
        }

        public Employee GetById(int id)
        {
            var data = db.Employee.Include("Department").Where(a => a.Id == id).FirstOrDefault();
            return data;
        }

        public Employee Create(Employee obj)
        {
            db.Employee.Add(obj);
            db.SaveChanges();

            return obj;
        }


        public Employee Update(Employee obj)
        {

            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();

            return obj;

        }

        public Employee Delete(Employee obj)
        {
            db.Employee.Remove(obj);
            db.SaveChanges();

            return obj;
        }

        public IEnumerable<Employee> SearchByName(string Name)
        {
            var data = db.Employee.Include("Department")
                                    .Where(x => x.Name.Contains(Name))
                                    .Select(x => x);
            return data;
        }

        public IEnumerable<Employee> Paging(int Index, int PageSize)
        {
            var data = db.Employee.Skip(Index).Take(PageSize);
            return data;
        }


    }

}
