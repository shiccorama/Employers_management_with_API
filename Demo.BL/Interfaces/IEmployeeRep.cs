using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.BL.Interfaces
{
    public interface IEmployeeRep
    {
        IEnumerable<Employee> Get();
        Employee GetById(int id);
        IEnumerable<Employee> SearchByName(string Name);
        IEnumerable<Employee> Paging(int Index , int PageSize);
        Employee Create(Employee obj);
        Employee Update(Employee obj);
        Employee Delete(Employee obj);
    }
}
