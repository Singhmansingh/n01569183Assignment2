using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01569183Assignment2.Controllers
{
    public class CCCController : ApiController
    {
        /// <summary>
        /// J1. see if Barley to dog is happy with his treats
        /// </summary>
        /// <param name="small">integer of small treats</param>
        /// <param name="meduium">integer of medium treats</param>
        /// <param name="large">integer of large treats</param>
        /// <returns>boolean if happy or not</returns>
        /// <example>
        /// GET: api/CCC/Dogtreats/5/3/1 -> TRUE
        /// GET: api/CCC/Dogtreats/1/2/1 -> FALSE
        /// </example>
        [HttpGet]
        [Route("api/CCC/DogTreats/{small}/{medium}/{large}")]
        public bool DogTreats(int small, int medium, int large)
        {
            int happiness = small * 1 + medium * 2 + large * 3;
            return happiness >= 10;
        }

        /// <summary>
        /// J2. Determines after how many days it takes until the desiese infects more than P number of people.
        /// Assume that P <= 10^7 , N <= P and R <= 10.
        /// </summary>
        /// <param name="p">Positive Integer of people infected</param>
        /// <param name="n">Positive Integer number of people who have the disease on Day 0</param>
        /// <param name="r">Positive Integer of people infected on the very next day</param>
        /// <returns>Integer number of days</returns>
        /// <example>
        /// GET: api/CCC/Epidemiology/750/1/5 -> 4
        /// GET: api/CCC/Epidemiology/10/2/1 -> 5
        /// </example>
        [HttpGet]
        [Route("api/CCC/Epidemiology/{p}/{n}/{r}")]
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

        /// <summary>
        /// J3. Determines the coordinates of the smallest possible rectangular frame, such that each drop of paint
        /// lies inside the frame. 
        /// </summary>
        /// <param name="drops">Integer total drops</param>
        /// <param name="coordinates">Catch all param for coordinates. format as xx,yy. Seperated by / </param>
        /// <returns>String representation of frame corner coordinates</returns>
        /// <example>
        /// GET: api/CCC/ModernArt/5/44,62/34,69/24,78/42,44/64,10 -> 23,9|65,79
        /// </example>
        [HttpGet]
        [Route("api/CCC/ModernArt/{drops}/{*coordinates}")]
        public string ModernArt(int drops, string coordinates)
        {
            string[] inputs = coordinates.Split('/');
            string[] stringCoordinate = inputs[0].Split(',');
            int[] bottom = new int[] { int.Parse(stringCoordinate[0]) - 1, int.Parse(stringCoordinate[1]) - 1 };
            int[] top = new int[] { 0, 0 };
            Debug.Write(stringCoordinate);
            int x = 0;
            int y = 0;

            for (int i = 0; i < drops; i++)
            {
                stringCoordinate = inputs[i].Split(',');
                x = int.Parse(stringCoordinate[0]);
                y = int.Parse(stringCoordinate[1]);

                if (x > top[0]) top[0] = x + 1;
                else if (x < bottom[0]) bottom[0] = x - 1;

                if (y > top[1]) top[1] = y + 1;
                else if (y < bottom[1]) bottom[1] = y - 1;
            }
            return $"{bottom[0]},{bottom[1]}|{top[0]},{top[1]}";
        }

        /// <summary>
        /// J4. Determines if a text contains a cyclic shift of a specified string
        /// </summary>
        /// <param name="t">String text</param>
        /// <param name="s">String cyclic shift to check</param>
        /// <returns>Boolean value</returns>
        /// <example>
        /// GET: api/CCC/CyclicShift/ABCCDEABAA/ABCDE -> TRUE
        /// GET: api/CCC/CyclicShift/ABCDDEBCAB/ABA -> FALSE
        /// </example>
        [HttpGet]
        [Route("api/CCC/CyclicShift/{t}/{s}")]
        public bool CyclicShift(string t, string s)
        {
            int loops = t.Length - s.Length;
            for (int i = 0; i <= loops; i++)
            {
                for (int j = 0; j < s.Length; j++)
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

        /// <summary>
        /// J5. Determine if it is possible to escape from a room. You start at top left (1,1), and need to
        /// move to bottom right (m,n). If you are in a cell of value x, then you can jump to any cell (a,b)
        /// such that a x b = x. 
        /// </summary>
        /// <param name="m">Integer of rows (1 to 1000)</param>
        /// <param name="n">Integer of columns (1 to 1000)</param>
        /// <param name="rows">Catch all string of row contents. Each cell seperated by a ' '.</param>
        /// <returns>Boolean value</returns>
        /// <example>
        /// GET: api/CCC/EscapeRoom/3/4/3 10 8 14/1 11 12 12/6 2 3 9 -> TRUE
        /// GET: api/CCC/EscapeRoom/3/4/3 10 2 14/1 11 1 1/5 2 3 9 -> FALSE
        /// </example>
        [HttpGet]
        [Route("api/CCC/EscapeRoom/{m}/{n}/{*rows}")]
        public bool EscapeRoom(int m, int n, string rows)
        {

            // Generate the Grid
            List<string> splitRows = rows.Split('/').ToList();
            int[][] grid = new int[m][];
            for (int y = 0; y < splitRows.Count; y++)
            {
                string[] rowArr = splitRows[y].Split(' ');
                int[] row = new int[n];
                for (int x = 0; x < rowArr.Length; x++)
                {
                    row[x] = Convert.ToInt32(rowArr[x]);
                }
                grid[y] = row;
            }



            // Search array for answers
            List<int> targets = new List<int>() { m * n };
            int solution = grid[0][0];
            int counter = 1;
            while (targets.Count > 0)
            {
                // set the target to look for on this loop
                int neededValue = targets[0];
                Debug.WriteLine($"This is step {counter}. Checking for {neededValue}");

                for (int y = 0; y < grid.Length; y++)
                {
                    for (int x = 0; x < grid[y].Length; x++)
                    {

                        int value = grid[y][x];

                        // checks if we are looking for the solution (item at 1,1) and the value is found
                        if (value == neededValue && neededValue == solution)
                        {
                            Debug.WriteLine($"Final Jump to {value} at ({x + 1},{y + 1})");

                            return true;

                        }
                        // if we find the value, add it to the targets. it will be checked once the steps before it are cleared
                        else if (value == neededValue)
                        {
                            targets.Add((x + 1) * (y + 1));
                            Debug.WriteLine($"{value} found at ({x + 1},{y + 1})");

                        }
                    }
                }
                targets.RemoveAt(0);

                // Debugging purposes
                counter++;
                Debug.WriteLine("Switching to next target.");
            }

            Debug.WriteLine($"No path between (1,1) and ({n},{m}) could be found.");
            return false;


        }

        // Depreciated: Used for debugging purposes. returns a visual of the grid
        private string[] PrintGrid(int[][] grid)
        {
            string[] display = new string[grid.Length];
            for (int y = 0; y < grid.Length; y++)
            {
                string row = "|\t";
                for (int x = 0; x < grid[y].Length; x++)
                {
                    row += grid[y][x];
                    row += "\t";
                }
                row += " |";
                Debug.WriteLine(row);
                display[y] = row;
            }
            return display;
        }
    }
}
