using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorManagement.Utils
{
    public class Response
    {
        public Response()
        {
            todays_date = DateTime.Now;
        }

        public bool error { get; set; }
        public object data { get; set; }
        public string message { get; set; }
        public DateTime todays_date { get; set; }
    }
}
