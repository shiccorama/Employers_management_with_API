using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.BL.Interfaces
{
    public interface IDistrictRep
    {
        IEnumerable<District> Get();
        District GetById(int id);
    }
}
