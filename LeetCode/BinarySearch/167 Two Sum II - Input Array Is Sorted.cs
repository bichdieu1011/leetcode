namespace LeetCode.BinarySearch
{
    public class _167_Two_Sum_II___Input_Array_Is_Sorted
    {
        public static void Test()
        {
            Console.WriteLine(string.Join(",", TwoSum(new int[] { 2, 7, 11, 15 }, 9)));
            Console.WriteLine(string.Join(",", TwoSum(new int[] { 2, 3, 4 }, 6)));
        }

        private static int[] TwoSum(int[] numbers, int target)
        {
            var check = 0;
            while (check < numbers.Length)
            {
                var l = check + 1;
                var r = numbers.Length - 1;
                while (l <= r)
                {
                    var m = l + (r - l) / 2;
                    if (target - numbers[m] - numbers[check] == 0) return new int[] { check + 1, m + 1 };
                    if (target - numbers[m] - numbers[check] > 0) l = m + 1;
                    else r = m - 1;
                }
                check++;
            }
            return new int[] { };
        }
    }
}