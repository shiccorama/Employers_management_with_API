using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.BL.Interfaces
{
    public interface ICityRep
    {
        IEnumerable<City> Get();
        City GetById(int id);

    }
}
