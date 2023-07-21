namespace LeetCode._75Questions.Week6
{
    public class _62_Unique_Paths
    {
        public static void Test()
        {
            Console.WriteLine(UniquePaths(3, 7));
            Console.WriteLine(UniquePaths(3, 2));
        }

        private static int UniquePaths(int m, int n)
        {
            var dp = new int[m + 1][];
            for (var i = 0; i <= m; i++)
            {
                dp[i] = new int[n + 1];                
                dp[i][0] = 1;
            }            

            for (var i = 1; i <= m; i++)
            {
                for (var j = 1; j <= n; j++)
                {
                    dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
                }
            }

            return dp[m][n -1];
        }
    }
}