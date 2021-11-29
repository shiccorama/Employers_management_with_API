using Demo.BL.Models;
using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.BL.Interfaces
{
    public interface IDepartmentRep
    {
        IEnumerable<Department> Get();
        Department GetById(int id);
        IEnumerable<Department> SearchByName(string Name);
        void Create(Department obj);
        void Update(Department obj);
        void Delete(Department obj);
    }
}
