using Demo.DAL.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Demo.DAL.Entity;
using Demo.BL.Interfaces;

namespace Demo.BL.Repository
{
    public class CityRep : ICityRep
    {
        private readonly DemoContext db;

        public CityRep(DemoContext _db)
        {
            db = _db;
        }


        public IEnumerable<City> Get()
        {
            var data = db.City.Select(a => a);
            return data;
        }

        public City GetById(int id)
        {
            var data = db.City.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }
    }
}
