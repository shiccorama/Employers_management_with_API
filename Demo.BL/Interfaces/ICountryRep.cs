using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.BL.Interfaces
{
    public interface ICountryRep
    {
        IEnumerable<Country> Get();
        Country GetById(int id);

    }
}
