namespace LeetCode._75Questions.Week1
{
    public class _1TwoSum
    {
        public static void Test()
        {
            //var result1 = TwoSum(new[] { 2, 7, 11, 15 }, 18);
            //var result1 = TwoSum(new[] { 2, 1, 9, 4, 4, 56, 90, 3 }, 8);
            var result1 = TwoSum(new[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 }, 11);
            //var result1 = TwoSum(new[] { 3, 3 }, 6);
            //var result1 = TwoSum(new[] { 2, 4, 11, 3 }, 6);
            Console.WriteLine(string.Join(",", result1));
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            var result = new int[2];
            var mapCurents = new Dictionary<int, int>();
            Array.Fill(result, -1);

            for (var i = 0; i < nums.Length; i++)
            {
                var need = target - nums[i];


                if (!mapCurents.ContainsKey(need))
                {
                    if (mapCurents.ContainsKey(nums[i]))
                        mapCurents[nums[i]] = i;
                    else
                        mapCurents.Add(nums[i], i);
                }
                else
                {
                    result[0] = mapCurents[need];
                    result[1] = i;
                    break;
                }

            }
            return result;
        }
    }
}