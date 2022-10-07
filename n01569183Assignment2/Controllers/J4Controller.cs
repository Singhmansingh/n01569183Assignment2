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
