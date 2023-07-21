using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._75Questions.Week6
{
    public class _54_Spiral_Matrix
    {
        public static void Test()
        {
            //Console.WriteLine(JsonConvert.SerializeObject(SpiralOrder(JsonConvert.DeserializeObject<int[][]>("[[1,2,3],[4,5,6],[7,8,9]]"))));
            //Console.WriteLine(JsonConvert.SerializeObject(SpiralOrder(JsonConvert.DeserializeObject<int[][]>("[[1,2,3,4],[5,6,7,8],[9,10,11,12]]"))));
            //Console.WriteLine(JsonConvert.SerializeObject(SpiralOrder(JsonConvert.DeserializeObject<int[][]>("[[]]"))));
            //Console.WriteLine(JsonConvert.SerializeObject(SpiralOrder(JsonConvert.DeserializeObject<int[][]>("[[3],[2]]"))));
            Console.WriteLine(JsonConvert.SerializeObject(SpiralOrder(JsonConvert.DeserializeObject<int[][]>("[[1],[2],[3],[4],[5],[6],[7],[8],[9],[10]]"))));

        }

        static IList<int> SpiralOrder(int[][] matrix)
        {
            var res = new List<int>();

            if (matrix.Length == 0) { return res; }

            var _q = new Queue<int>();
            _q.Enqueue(1);
            _q.Enqueue(2);
            _q.Enqueue(3);
            _q.Enqueue(4);

            var round = 0;
            var max = Math.Min(matrix.Length / 2, matrix[0].Length / 2);

            while (round <= max)
            {
                var step = _q.Dequeue();
                _q.Enqueue(step);

                switch (step)
                {
                    case 1:
                        for (var i = 0 + round; i < matrix[round].Length - round; i++)
                        {
                            if (matrix[round][i] != 101)
                                res.Add(matrix[round][i]);
                            matrix[round][i] = 101;
                        }
                        break;
                    case 2:
                        for (var i = 0 + round + 1; i < matrix.Length - round; i++)
                        {
                            if (matrix[i][matrix[round].Length - round - 1] != 101)
                                res.Add(matrix[i][matrix[round].Length - round - 1]);
                            matrix[i][matrix[round].Length - round - 1] = 101;

                        }
                        break;
                    case 3:
                        for (var i = matrix[round].Length - round - 1; i >= round; i--)
                        {
                            if (matrix[matrix.Length - round - 1][i] != 101)
                                res.Add(matrix[matrix.Length - round - 1][i]);
                            matrix[matrix.Length - round - 1][i] = 101;

                        }
                        break;
                    case 4:
                        for (var i = matrix.Length - round - 1; i >= round + 1; i--)
                        {
                            if (matrix[i][round] != 101)
                                res.Add(matrix[i][round]);
                            matrix[i][round] = 101;

                        }
                        round++;
                        break;
                }

            }

            return res;

        }
    }
}
