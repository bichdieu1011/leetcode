namespace LeetCode._75Questions.Week3
{
    public class _973KClosestPointsToOrigin
    {
        public static void Test()
        {
            //var input = new int[][] { new[] { 1, 3 }, new[] { -2, 2 } };//[[0,0,0],[0,1,0],[1,2,1]]
            var input = new int[][] { new[] { 3, 3 }, new[] { 5, 1 }, new[] { -2, 4 } };//[[0,0,0],[0,1,0],[1,2,1]]
            var output = KClosest(input, 2);

            foreach (var cell in output)
            {
                Console.WriteLine($"[{string.Join(", ", cell)}]");
            }
        }

        private static int[][] KClosest(int[][] points, int k)
        {
            var hasChanged = true;
            var length = points.Length;

            while (hasChanged)
            {
                hasChanged = false;
                var pivot = points[k - 1];
                var pivotIndex = k - 1;
                for (var i = 0; i < pivotIndex; i++)
                {
                    var lengthI = Math.Sqrt(points[i][0] * points[i][0] + points[i][1] * points[i][1]);
                    var lengthK = Math.Sqrt(pivot[0] * pivot[0] + pivot[1] * pivot[1]);

                    if (lengthI > lengthK)
                    {
                        var temp = points[i];
                        for (var j = i; j < pivotIndex; j++)
                            points[j] = points[j + 1];

                        points[pivotIndex] = temp;
                        i--;
                        pivotIndex--;
                        hasChanged = true;
                    }
                }

                for (var i = k; i < length; i++)
                {
                    var lengthI = Math.Sqrt(points[i][0] * points[i][0] + points[i][1] * points[i][1]);
                    var lengthK = Math.Sqrt(points[k - 1][0] * points[k - 1][0] + points[k - 1][1] * points[k - 1][1]);

                    if (lengthI <= lengthK)
                    {
                        var temp = points[i];
                        for (var j = i; j > pivotIndex; j--)
                            points[j] = points[j - 1];
                        points[pivotIndex] = temp;
                        pivotIndex++;

                        hasChanged = true;
                    }
                }
            }

            var res = new int[k][];
            for (var i = 0; i < k; i++)
            {
                res[i] = points[i];
            }
            return res;
        }
    }
}