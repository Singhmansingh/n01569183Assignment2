using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01569183Assignment2.Controllers
{
    public class J1Controller : ApiController
    {
        /// <summary>
        /// see if Barley to dog is happy with his treats
        /// </summary>
        /// <param name="small">integer of small treats</param>
        /// <param name="meduium">integer of medium treats</param>
        /// <param name="large">integer of large treats</param>
        /// <returns>boolean if happy or not</returns>
        /// <example>
        /// GET: api/j1/Dogtreats/5/3/1 -> TRUE
        /// GET: api/j1/Dogtreats/1/2/1 -> FALSE
        /// </example>
        [HttpGet]
        [Route("api/J1/Dogtreats/{small}/{medium}/{large}")]
        public bool Dogtreats(int small, int medium, int large)
        {
            int happiness = small * 1 + medium * 2 + large * 3;
            return happiness >= 10;
        }

        public string Get()
        {
            return "Hello World!";
        }
    }
}
