namespace LeetCode._75Questions.Week4
{
    public class _994_Rotting_Oranges
    {
        public static void test()
        {
            var inputS = "[[2,1,1],[1,1,0],[0,1,1]]";
            //var inputS = "[[1],[2]]";
            int[][] intput = Newtonsoft.Json.JsonConvert.DeserializeObject<int[][]>(inputS);

            Console.WriteLine(OrangesRotting(intput));
        }

        private static int OrangesRotting(int[][] grid)
        {
            var stack = new Queue<int[]>();
            var m = grid.Length;
            var n = grid[0].Length;
            var countFresh = 0;
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1) countFresh++;
                    if (grid[i][j] == 2)
                        stack.Enqueue(new[] { i, j });
                }
            }

            var max = 0;
            while (stack.Count > 0)
            {
                var item = stack.Dequeue();
                for (var x = item[0] - 1 > 0 ? item[0] - 1 : 0; x <= item[0] + 1 && x < m; x++)
                {
                    var y = item[1];
                    if (x == item[0] && y == item[1] || grid[x][y] == 0 || grid[x][y] == 2) continue;
                    if (grid[x][y] == 1)
                    {
                        stack.Enqueue(new int[] { x, y });
                        grid[x][y] = grid[item[0]][item[1]] + 1;
                        countFresh--;
                        max = max > grid[x][y] ? max : grid[x][y];
                    }
                    else grid[x][y] = grid[x][y] < grid[item[0]][item[1]] + 1 ? grid[x][y] : grid[item[0]][item[1]] + 1;
                }

                for (var y = item[1] - 1 > 0 ? item[1] - 1 : 0 ; y <= item[1] + 1 && y < n; y++)
                {
                    var x = item[0];
                    if (x == item[0] && y == item[1] || grid[x][y] == 0 || grid[x][y] == 2) continue;
                    if (grid[x][y] == 1)
                    {
                        stack.Enqueue(new int[] { x, y });
                        grid[x][y] = grid[item[0]][item[1]] + 1;
                        countFresh--;
                        max = max > grid[x][y] ? max : grid[x][y];
                    }
                    else grid[x][y] = grid[x][y] < grid[item[0]][item[1]] + 1 ? grid[x][y] : grid[item[0]][item[1]] + 1;
                }
            }

            return countFresh > 0 ? -1 : (max > 2 ? max - 2 : 0);
        }
    }
}