namespace LeetCode._75Questions.Week3
{
    public class _136Single_Number
    {
        public static void Test()
        {
            var res = SingleNumber(new[] { 1, 2, 3, 2, 1 });
            Console.WriteLine(res);
        }

        private static int SingleNumber(int[] nums)
        {
            int res = 0;
            var length = nums.Length;
            for (var i = 0; i < length; i++)
            {
                res = res ^ nums[i];
            }
            return res;
        }
    }
}