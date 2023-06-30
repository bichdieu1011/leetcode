namespace LeetCode._75Questions.Week3
{
    public class _137SingleNumberII
    {
        public static void Test()
        {
            //var res = SingleNumber(new[] { 2, 2, 2,3 });
            var res = FindSingleNumber(new[] { 30000, 500, 100, 30000, 100, 30000, 100 });
            //var res = FindSingleNumber(new[] { 2, 2, 2, 3 });
            Console.WriteLine(res);
        }

        private static int SingleNumber(int[] nums)
        {
            int once = nums[0], twice = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                once = ~twice & (once ^ nums[i]);
                twice = ~once & (twice ^ nums[i]);
            }
            return once;
        }

        private static int FindSingleNumber(int[] nums)
        {
            var bits = new short[32];
            for (int i = 0; i < nums.Length; i++)
            {
                var s = Convert.ToString(nums[i], 2);
                for (var j = s.Length - 1; j >= 0; j--)
                {
                    if (s[j] == '1')
                        bits[32 - s.Length + j]++;
                    if (bits[32 - s.Length + j] >= 3)
                        bits[32 - s.Length + j] = (short)(bits[32 - s.Length + j] % 3);
                }
            }
            return Convert.ToInt32(string.Join("", bits), 2);
        }
    }
}