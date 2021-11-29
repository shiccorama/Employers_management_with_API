using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.BL.Helper
{
    public class ApiResponse<TEntity> where TEntity : class
    {

        public Response Response { get; set; }
        public IEnumerable<TEntity> Records { get; set; }
        public TEntity Record { get; set; }

    }
}
