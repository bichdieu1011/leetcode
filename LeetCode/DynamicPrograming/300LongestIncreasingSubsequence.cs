namespace LeetCode.DynamicPrograming
{
    public class _300LongestIncreasingSubsequence
    {
        public static void Test()
        {
            //var res = LengthOfLIS(new[] { 1, 5, 2, 3, 4 });//4
            var res = LengthOfLIS(new[] { 1, 3, 6, 7, 9, 4, 10, 5, });//6
            //var res = LengthOfLIS(new[] { 10, 9, 2, 5, 3, 7, 101, 18 });//4
            //var res = LengthOfLIS(new[] { 0, 1, 0, 3, 2, 3 });//4
            Console.WriteLine(res);
        }

        private static int LengthOfLIS(int[] nums)
        {
            var higherLength = new int[nums.Length];
            var max = 1;            
            for (var i = nums.Length - 1; i >= 0; i--)
            {
                higherLength[i] = Math.Max(higherLength[i], 1);
                for (var j = i - 1; j >= 0; j--)
                {
                    if (nums[i] > nums[j])
                    {
                        higherLength[j] = Math.Max(higherLength[i] + 1, higherLength[j]);
                        max = max > higherLength[j] ? max : higherLength[j];
                    }
                }
            }

            return max;
        }

    }
}