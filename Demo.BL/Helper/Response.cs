using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.BL.Helper
{
    public class Response
    {
        public string Code { get; set; }
        public string Status { get; set; }
        public string Msg { get; set; }

        public Response(string code , string status , string msg)
        {
            Code = code;
            Status = status;
            Msg = msg;
        }


    }
}
