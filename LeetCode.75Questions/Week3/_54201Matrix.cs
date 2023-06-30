namespace LeetCode._75Questions.Week3
{
    public class _54201Matrix
    {
        private struct SCell
        {
            public int X;
            public int Y;
        }

        public static void Test()
        {
            //var input = new int[][] { new[] { 0, 0, 0 }, new[] { 0, 1, 0 }, new[] { 0, 0, 0 } };//[[0,0,0],[0,1,0],[0,0,0]]
            var input = new int[][] { new[] { 0, 0, 0 }, new[] { 0, 1, 0 }, new[] { 1, 1, 1 } };//[[0,0,0],[0,1,0],[1,2,1]]
            var output = UpdateMatrix(input);

            foreach (var cell in output)
            {
                Console.WriteLine($"[{string.Join(", ", cell)}]");
            }
        }

        public static int[][] UpdateMatrix(int[][] mat)
        {
            var result = new int[mat.Length][];
            var queue = new Queue<SCell>();
            for (var i = 0; i < mat.Length; i++)
            {
                result[i] = new int[mat[i].Length];
                Array.Fill(result[i], -1);

                for (var j = 0; j < mat[i].Length; j++)
                {
                    if (mat[i][j] == 0)
                    {
                        queue.Enqueue(new SCell { X = i, Y = j });
                        result[i][j] = 0;
                    }
                }
            }

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                WalkAndCalculate(item, queue, mat, result);
            }

            return result;
        }

        private static void WalkAndCalculate(SCell cell, Queue<SCell> queue, int[][] mat, int[][] res)
        {
            int xLength = mat.Length;
            var yLength = mat[0].Length;
            var isCurrentZero = mat[cell.X][cell.Y] == 0;
            var checkCells = new SCell[6];
            for (var i = -1; i <= 1; i++)
            {
                checkCells[i + 1] = new SCell { X = cell.X + i, Y = cell.Y };
            }

            for (var i = -1; i <= 1; i++)
            {
                checkCells[i + 4] = new SCell { X = cell.X, Y = cell.Y + i };
            }

            for (var i = 0; i < 6; i++)
            {
                var newPos = checkCells[i];

                if (newPos.X < 0 || newPos.Y < 0 || newPos.X >= xLength || newPos.Y >= yLength) continue;
                if (newPos.X == cell.X && newPos.Y == cell.Y || res[newPos.X][newPos.Y] == 0)
                    continue;

                if (isCurrentZero)
                {
                    res[newPos.X][newPos.Y] = res[newPos.X][newPos.Y] == -1 ? 1 : res[newPos.X][newPos.Y];
                    queue.Enqueue(newPos);
                }
                else
                {
                    if (res[newPos.X][newPos.Y] == -1)
                        queue.Enqueue(newPos);

                    res[newPos.X][newPos.Y] = res[newPos.X][newPos.Y] == -1 ? res[cell.X][cell.Y] + 1 : Math.Min(res[cell.X][cell.Y] + 1, res[newPos.X][newPos.Y]);
                }
            }
        }
    }
}