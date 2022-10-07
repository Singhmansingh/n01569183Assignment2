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
        /// <summary>
        /// Determines after how many days it takes until the desiese infects more than P number of people.
        /// Assume that P <= 10^7 , N <= P and R <= 10.
        /// </summary>
        /// <param name="p">Positive Integer of people infected</param>
        /// <param name="n">Positive Integer number of people who have the disease on Day 0</param>
        /// <param name="r">Positive Integer of people infected on the very next day</param>
        /// <returns>Integer number of days</returns>
        /// <example>
        /// GET: api/j2/epidemiology/750/1/5 -> 4
        /// GET: api/j2/epidemiology/10/2/1 -> 1
        /// </example>
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
