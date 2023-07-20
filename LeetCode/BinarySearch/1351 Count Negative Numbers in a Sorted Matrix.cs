using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LeetCode.BinarySearch
{
    public class _1351_Count_Negative_Numbers_in_a_Sorted_Matrix
    {
        public static void Test()
        {

            //Console.WriteLine(CountNegatives(JsonConvert.DeserializeObject<int[][]>("[[4,3,2,-1],[3,2,1,-1],[1,1,-1,-2],[-1,-1,-2,-3]]")));
            Console.WriteLine(CountNegatives(JsonConvert.DeserializeObject<int[][]>("[[3,2],[1,0]]")));
        }
        static int CountNegatives(int[][] grid)
        {
            var lineStart = 0;
            var columnStart = 0;
            var sum = 0;
            var l = columnStart;
            var r = grid[lineStart].Length - 1;
            while (lineStart < grid.Length)
            {
                columnStart = grid[lineStart].Length;
                while (l <= r)
                {
                    var m = l + (r - l) / 2;
                    if (grid[lineStart][m] < 0)
                    {
                        columnStart = m;
                        r = m - 1;
                    }
                    else
                    {
                        l = m + 1;
                    }
                }
                l = 0;
                r = grid[lineStart].Length == columnStart ? grid[lineStart].Length - 1 : columnStart;
                sum += grid[lineStart++].Length - columnStart;
            }
            return sum;
        }
    }
}
