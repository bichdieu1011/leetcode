namespace LeetCode._75Questions.Week1
{
    public class _704BinarySearch
    {
        public static void Test()
        {
            //var result = Search(new[] { 1, 3, 5, 7, 8, 9, 14, 56 }, 14);
            var result = Search(new[] { 5 }, 5);
            //var result = Search(new[] { -1, 0, 3, 5, 9, 12 }, 9);

            Console.WriteLine(result);
        }

        public static int Search(int[] nums, int target)
        {
            var left = 0;

            var right = nums.Length - 1;
            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                if (target == nums[mid])
                    return mid;
                if (target < nums[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return -1;
        }
    }
}