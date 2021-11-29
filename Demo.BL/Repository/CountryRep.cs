using Demo.BL.Interfaces;
using Demo.DAL.Database;
using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Demo.BL.Repository
{
    public class CountryRep : ICountryRep
    {
        private readonly DemoContext db;

        public CountryRep(DemoContext _db)
        {
            db = _db;
        }


        public IEnumerable<Country> Get()
        {
            var data = db.Country.Select(a => a);
            return data;
        }

        public Country GetById(int id)
        {
            var data = db.Country.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }
    }
}
