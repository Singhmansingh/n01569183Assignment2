using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;

namespace n01569183Assignment2.Controllers
{
    public class J3Controller : ApiController
    {
        [HttpGet]
        [Route("api/j3/Art/{*param}")]
        public string Art(string param)
        {
            string[] inputs = param.Split('/');
            int drops = Int32.Parse(inputs[0]);
            string[] stringCoordinate = inputs[1].Split(',');
            int[] bottom = new int[] { int.Parse(stringCoordinate[0]), int.Parse(stringCoordinate[1]) };
            int[] top = new int[] { 0, 0 };
            int x = 0;
            int y = 0;

            for (int i = 1; i <= drops; i++)
            {
                stringCoordinate = inputs[i].Split(',');
                x = int.Parse(stringCoordinate[0]);
                y = int.Parse(stringCoordinate[1]);

                if(x > top[0]) top[0] = x + 1;
                else if(x < bottom[0]) bottom[0] = x - 1;

                if (y > top[1]) top[1] = y + 1;
                else if (y < bottom[1]) bottom[1] = y - 1;
            }
            return $"{bottom[0]},{bottom[1]}|{top[0]},{top[1]}";
        }
    }
}
