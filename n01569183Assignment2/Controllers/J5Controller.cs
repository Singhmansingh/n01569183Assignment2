using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01569183Assignment2.Controllers
{
    public class J5Controller : ApiController
    {
        /// <summary>
        /// Determine if it is possible to escape from a room. You start at top left (1,1), and need to
        /// move to bottom right (m,n). If you are in a cell of value x, then you can jump to any cell (a,b)
        /// such that a x b = x. 
        /// </summary>
        /// <param name="m">Integer of rows (1 to 1000)</param>
        /// <param name="n">Integer of columns (1 to 1000)</param>
        /// <param name="rows">Catch all string of row contents. Each cell seperated by a ' '.</param>
        /// <returns>Boolean value</returns>
        /// <example>
        /// GET: api/j5/EscapeRoom/3/4/3 10 8 14/1 11 12 12/6 2 3 9 -> TRUE
        /// GET: api/j5/EscapeRoom/3/4/3 10 2 14/1 11 1 1/5 2 3 9 -> FALSE
        /// </example>
        [HttpGet]
        [Route("api/j5/EscapeRoom/{m}/{n}/{*rows}")]
        public string EscapeRoom(int m, int n, string rows)
        {

            // Generate the Grid
            List<string> splitRows = rows.Split('/').ToList();
            int[][] grid = new int[m][];
            for(int y = 0; y < splitRows.Count; y++)
            {
                string[] rowArr = splitRows[y].Split(' ');
                int[] row = new int[n];
                for(int x = 0; x < rowArr.Length; x++)
                {
                    row[x] = Convert.ToInt32(rowArr[x]);
                }
                grid[y] = row;
            }

  

            // Search array for answers
            List<int> targets = new List<int>() { m*n };
            int solution = grid[0][0];
            int counter = 1;
            while(targets.Count > 0)
            {
                // set the target to look for on this loop
                int neededValue = targets[0];
                Debug.WriteLine($"This is step {counter}. Checking for {neededValue}");

                for (int y = 0; y < grid.Length; y++)
                {
                    for(int x = 0; x < grid[y].Length; x++)
                    {

                        int value = grid[y][x];

                        // checks if we are looking for the solution (item at 1,1) and the value is found
                        if (value == neededValue && neededValue == solution)
                        {
                            Debug.WriteLine($"Final Jump to {value} at ({x + 1},{y + 1})");

                            return "yes";
                            
                        }
                        // if we find the value, add it to the targets. it will be checked once the steps before it are cleared
                        else if (value == neededValue)
                        {
                            targets.Add((x+1) * (y+1));
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
            return "no";


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
