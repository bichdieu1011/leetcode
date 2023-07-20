namespace LeetCode.DynamicPrograming
{
    public class _698_Partition_to_K_Equal_Sum_Subsets
    {
        public static void Test()
        {
            ////Console.WriteLine(CanPartitionKSubsets(new[] { 1, 2, 3, 4 }, 3));//false
            //Console.WriteLine(CanPartitionKSubsets(new[] { 4, 3, 2, 3, 5, 2, 1 }, 4));//true
            //Console.WriteLine(CanPartitionKSubsets(new[] { 2, 2, 2, 2, 3, 4, 5 }, 4));//false
            Console.WriteLine(CanPartitionKSubsets(new[] { 3522, 181, 521, 515, 304, 123, 2512, 312, 922, 407, 146, 1932, 4037, 2646, 3871, 269 }, 5));//true
        }

        private static bool CanPartitionKSubsets(int[] nums, int k)
        {
            var total = 0;
            var max = 0;
            var _dict = new Dictionary<int, int>();
            foreach (var item in nums)
            {
                total += item;
                max = max > item ? max : item;
            }

            var sumOfSubArray = total / k;
            if (nums.Length < k || max > sumOfSubArray || total % k > 0) return false;
            foreach (var item in nums)
            {
                _dict.Add(item, sumOfSubArray - item);
            }


            nums = nums.OrderBy(x => x).ToArray();
            var take = new bool[nums.Length];

            var sum = 0;
            for (var j = nums.Length - 1; j >= 0; j--)
            {
                if (!take[j])
                {
                    take[j] = true;
                    sum = sumOfSubArray - nums[j];
                    for (var i = j - 1; i >= 0; i--)
                    {
                        if (!take[i] && sum >= nums[i])
                        {
                            take[i] = true;
                            sum -= nums[i];
                        }
                        if (sum == 0) break;
                    }
                    if (sum > 0) return false;
                }
            }
            return true;
        }
    }
}