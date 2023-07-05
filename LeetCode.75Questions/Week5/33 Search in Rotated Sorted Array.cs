namespace LeetCode._75Questions.Week5
{
    public class _33_Search_in_Rotated_Sorted_Array
    {
        public static void Test()
        {
            Console.WriteLine($"[16, 4, 5, 6, 7, 8, 9]; target = 6; res = {Search(new[] { 16, 4, 5, 6, 7, 8, 9 }, 6)}");
            Console.WriteLine($"[4, 5, 6, 7, 0, 1, 2]; target = 0; res = {Search(new[] { 4, 5, 6, 7, 0, 1, 2 }, 0)}");
            Console.WriteLine($"[1, 3]; target = 3; res = {Search(new[] { 1, 3 }, 3)}");
            Console.WriteLine($"[3, 1]; target = 1; res = {Search(new[] { 3, 1 }, 1)}");
            Console.WriteLine($"[4,5,6,7,0,1,2]; target = 2; res = {Search(new[] { 4, 5, 6, 7, 0, 1, 2 }, 2)}");
            Console.WriteLine($"[4,5,6,7,8,1,2,3]; target = 2; res = {Search(new[] { 4, 5, 6, 7, 8, 1, 2, 3 }, 8)}");
        }

        private static int Search(int[] nums, int target)
        {
            var res = -1;
            var first = nums[0];
            if (first == target) return 0;

            var left = 0;
            var right = nums.Length - 1;
            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }

                if (nums[mid] >= first)//left half
                {
                    if (nums[mid] > target)
                        if (target < first)
                            left = mid + 1;
                        else right = mid - 1;
                    else
                        left = mid + 1;
                }
                else if (nums[mid] < first) // right half
                {
                    if (target > first)
                        if (nums[mid] < target)
                            right = mid - 1;
                        else left = mid + 1;
                    else
                        if (nums[mid] > target)
                        right = mid - 1;
                    else left = mid + 1;
                }
            }
            return res;
        }
    }
}