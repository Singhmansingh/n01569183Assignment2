using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Week4Practice.Controllers
{
    public class J4Controller : ApiController
    {
        /// <summary>
        /// Determines if a text contains a cyclic shift of a specified string
        /// </summary>
        /// <param name="t">String text</param>
        /// <param name="s">String cyclic shift to check</param>
        /// <returns>Boolean value</returns>
        /// <example>
        /// GET: api/j4/cyclic/ABCCDEABAA/ABCDE -> TRUE
        /// GET: api/j4/cyclic/ABCDDEBCAB/ABA -> FALSE
        /// </example>
        [HttpGet]
        [Route("api/j4/cyclic/{t}/{s}")]
        public bool Cyclic(string t, string s)
        {
            int loops = t.Length - s.Length;
            for(int i = 0; i <= loops; i++)
            {
                for(int j = 0; j < s.Length; j++)
                {
                    if (t.Substring(i, s.Length) == s)
                    {
                        return true;
                    }
                    else
                    {
                        s += s[0];
                        s = s.Substring(1);
                    }
                }
            }

            return false;
        }
    }
}
