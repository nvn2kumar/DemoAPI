using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Contract.Response
{
    public class ApiResponse
    {
        public int Status { get; set; } //ststus score 2220. 4200
        public bool Ok { get; set; } // True or False
        public dynamic Data { get; set; } //data could be anything
        public string Message { get; set; }
        public string Token { get; set; } // only onetime when we Log in
    }
    
}
