using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01569183Assignment2.Controllers
{
    public class J2Controller : ApiController
    {
        [HttpGet]
        [Route("api/j2/epidemiology/{p}/{n}/{r}")]
        public int Epidemiology(int p, int n, int r)
        {
            int days = 0;
            int infected = 0;
            int initial = n;
            while (infected < p)
            {
                infected += n * r;
                if (initial < r) n *= r;
                days++;
            }
            return days;
        }
    }
}
