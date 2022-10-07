using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;

namespace n01569183Assignment2.Controllers
{
    public class J3Controller : ApiController
    {
        /// <summary>
        /// Determines the coordinates of the smallest possible rectangular frame, such that each drop of paint
        /// lies inside the frame. 
        /// </summary>
        /// <param name="drops">Integer total drops</param>
        /// <param name="coordinates">Catch all param for coordinates. format as xx, yy. Seperated by / </param>
        /// <returns>String representation of frame corner coordinates</returns>
        /// <example>
        /// GET: api/j3/Art/5/44,62/34,69/24,78/42,44/64,10 -> 23,9|65,79
        /// </example>
        [HttpGet]
        [Route("api/j3/Art/{drops}/{*coordinates}")]
        public string Art(int drops, string coordinates)
        {
            string[] inputs = coordinates.Split('/');
            string[] stringCoordinate = inputs[0].Split(',');
            int[] bottom = new int[] { int.Parse(stringCoordinate[0]), int.Parse(stringCoordinate[1]) };
            int[] top = new int[] { 0, 0 };
            int x = 0;
            int y = 0;

            for (int i = 0; i <= drops; i++)
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
