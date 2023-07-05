using System.Runtime.Intrinsics.Arm;

namespace LeetCode.DynamicPrograming.Knapsack
{
    public class _416_Partition_Equal_Subset_Sum
    {
        public static void Test()
        {
            //Console.WriteLine($"1, 5, 11, 5: Correct?: {CanPartition(new[] { 1, 5, 11, 5 }) == true}");
            //Console.WriteLine($"1, 2, 5: Correct?: {CanPartition(new[] { 1, 2, 5 }) == false}");
            Console.WriteLine($"1, 2, 3, 5: Correct?:  {CanPartition(new[] { 1, 2, 3, 5 }) == false}");
        }

        private static bool CanPartition(int[] nums)
        {
            var sum = 0;
            foreach (var i in nums)
            {
                sum += i;
            }
            if ((sum & 1) == 1)
                return false;
            sum = sum >> 1;

            var dp = new bool[sum + 1];
            dp[0] = true;
            
            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = sum; j >= 0; j--)
                {
                    if (j >= nums[i])
                    {
                        dp[j] = dp[j]  || dp[j - nums[i]] ;
                    }
                }
            }

            return dp[sum];
        }
    }
}