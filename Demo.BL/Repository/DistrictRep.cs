using Demo.DAL.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Demo.DAL.Entity;
using Demo.BL.Interfaces;

namespace Demo.BL.Repository
{
    public class DistrictRep : IDistrictRep
    {
        private readonly DemoContext db;

        public DistrictRep(DemoContext _db)
        {
            db = _db;
        }


        public IEnumerable<District> Get()
        {
            var data = db.District.Select(a => a);
            return data;
        }

        public District GetById(int id)
        {
            var data = db.District.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }
    }
}
