namespace LeetCode._75Questions.Week2
{
    public class _70ClimbingStairs
    {
        public static void Test()
        {
            var result = ClimbStairs(4);

            Console.WriteLine(result);
        }

        private static int ClimbStairs(int n)
        {
            short start = 2;
            int prev1 = 1;
            int prev2 = 1;
            while (start <= n)
            {
                var temp = prev1;
                prev1 = prev1 + prev2;
                prev2 = temp;

                start++;
            }
            return prev1;
        }
    }
}