﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._75Questions.Week4
{
    public class _200_Number_of_Islands
    {
        public static void test()
        {
            //var inputS = "[\r\n  [\"1\",\"1\",\"1\",\"1\",\"0\"],\r\n  [\"1\",\"1\",\"0\",\"1\",\"0\"],\r\n  [\"1\",\"1\",\"0\",\"0\",\"0\"],\r\n  [\"0\",\"0\",\"0\",\"0\",\"0\"]\r\n]";
            var inputS = "[[\"1\",\"1\",\"1\",\"1\",\"1\",\"0\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"0\",\"1\",\"0\",\"1\",\"1\"],[\"0\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"0\",\"1\",\"1\",\"1\",\"1\",\"1\",\"0\"],[\"1\",\"0\",\"1\",\"1\",\"1\",\"0\",\"0\",\"1\",\"1\",\"0\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\"],[\"1\",\"1\",\"1\",\"1\",\"0\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\"],[\"1\",\"0\",\"0\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\"],[\"1\",\"0\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"0\",\"1\",\"1\",\"1\",\"0\",\"1\",\"1\",\"1\",\"0\",\"1\",\"1\",\"1\"],[\"0\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"0\",\"1\",\"1\",\"0\",\"1\",\"1\",\"1\",\"1\"],[\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"0\",\"1\",\"1\",\"1\",\"1\",\"0\",\"1\",\"1\"],[\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"0\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\"],[\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\"],[\"0\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"0\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\"],[\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\"],[\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\"],[\"1\",\"1\",\"1\",\"1\",\"1\",\"0\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"0\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\"],[\"1\",\"0\",\"1\",\"1\",\"1\",\"1\",\"1\",\"0\",\"1\",\"1\",\"1\",\"0\",\"1\",\"1\",\"1\",\"1\",\"0\",\"1\",\"1\",\"1\"],[\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"0\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"0\"],[\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"0\",\"1\",\"1\",\"1\",\"1\",\"0\",\"0\"],[\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\"],[\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\"],[\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\",\"1\"]]";
            //var inputS = "[[1],[2]]";
            char[][] intput = Newtonsoft.Json.JsonConvert.DeserializeObject<char[][]>(inputS);

            Console.WriteLine(NumIslands(intput));
        }

        static int NumIslands(char[][] grid)
        {
            var res = 0;
            var m = grid.Length;
            var n = grid[0].Length;


            for (var i = 0; i < m; i++)
                for (var j = 0; j < n; j++)
                {
                    if (grid[i][j] == '0') continue;
                    if (grid[i][j] == '1')
                    {
                        var queue = new Queue<int[]>();
                        queue.Enqueue(new[] { i, j });
                        grid[i][j] = '0';
                       
                        while (queue.Count > 0)
                        {
                            var cell = queue.Dequeue();
                            for (var x = cell[0] - 1 > 0 ? cell[0] - 1 : 0; x <= cell[0] + 1 && x < m; x++)
                            {
                                var y = cell[1];
                                if (grid[x][y] == '1')
                                {
                                    grid[x][y] = '0';
                                    queue.Enqueue(new int[] { x, y });
                                }
                            }

                            for (var y = cell[1] - 1 > 0 ? cell[1] - 1 : 0; y <= cell[1] + 1 && y < n; y++)
                            {
                                var x = cell[0];
                                if (grid[x][y] == '1')
                                {
                                    grid[x][y] = '0';
                                    queue.Enqueue(new int[] { x, y });

                                }
                            }
                        }
                        res++;
                    }
                }

            return res;
        }

        static int[] getFirstCell(char[][] grid, int xlength, int ylength)
        {

            for (var i = 0; i < xlength; i++)

                for (var j = 0; j < ylength; j++)
                    if (grid[i][j] == '1')
                        return new[] { i, j };
            return null;
        }
    }
}
