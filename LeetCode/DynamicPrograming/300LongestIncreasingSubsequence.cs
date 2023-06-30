namespace LeetCode.DynamicPrograming
{
    public class _300LongestIncreasingSubsequence
    {
        public static void Test()
        {
            //var res = LengthOfLIS(new[] { 1, 5, 2, 3, 4 });//4
            var res = LengthOfLIS(new[] { 10, 9, 2, 5, 3, 7, 101, 18 });//4
            //var res = LengthOfLIS(new[] { 0, 1, 0, 3, 2, 3 });//4
            Console.WriteLine(res);
        }

        private static int LengthOfLIS(int[] nums)
        {
            var max = nums[0];
            var min = nums[0];
            var count = 1;
            var maxcount = 1;
            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] > max && nums[i] > min)
                {
                    count++;
                    max = nums[i];
                    maxcount = maxcount > count ? maxcount : count;
                }
                else if (nums[i] < max && nums[i] > min)
                {
                    max = nums[i];

                }
                else if (nums[i] < max)
                {
                    count = nums[i] < min ? 1 : count;
                    min = nums[i] < min ? min : nums[i];
                }
            }
            return maxcount;
        }
    }
}