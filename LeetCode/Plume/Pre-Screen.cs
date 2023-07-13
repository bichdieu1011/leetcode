namespace LeetCode.Plume
{
    public class Pre_Screen
    {
        /// <summary>
        /// https://leetcode.com/problems/longest-consecutive-sequence/
        /// </summary>
        public static void Test()
        {
            //Console.WriteLine($"[100,4,200,1,3,2], res: {LongestConsecutive(new[] { 100, 4, 200, 1, 3, 2 })}");
            Console.WriteLine($"[0,3,7,2,5,8,4,6,0,1], res: {LongestConsecutive_Sort(new[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 })}");
        }
        /// <summary>
        /// Time complexity: O(NLog(N))
        /// Space complexity: O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        static int LongestConsecutive_Sort(int[] nums)
        {
            if (nums is null || nums.Length == 0) return 0;
            nums = nums.OrderBy(s => s).ToArray();

            var count = 1;
            var maxLength = 0;
            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1] + 1) count++;
                else if (nums[i] == nums[i - 1]) continue;
                else
                {
                    maxLength = count > maxLength ? count : maxLength;
                    count = 1;
                }
            }

            return count > maxLength ? count : maxLength;
        }

        /// <summary>
        /// Space complexity: O(N)
        /// Time complexity: O(N)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int LongestConsecutive_Hashtable(int[] nums)
        {
            if (nums is null || nums.Length == 0) return 0;

            var dict = new Dictionary<int, bool>();

            foreach (var i in nums)
            {
                if (!dict.ContainsKey(i))
                    dict.Add(i, false);
            }

            var maxLength = 0;

            foreach (var keyValuePair in dict)
            {
                if (keyValuePair.Value) continue;

                var count = 1;
                var key = keyValuePair.Key - 1;
                while (dict.ContainsKey(key))
                {
                    dict[key] = true;
                    key--;
                    count++;
                }

                key = keyValuePair.Key + 1;
                while (dict.ContainsKey(key))
                {
                    dict[key] = true;

                    key++;
                    count++;
                }

                maxLength = Math.Max(maxLength, count);
            }

            return maxLength;
        }
    }
}