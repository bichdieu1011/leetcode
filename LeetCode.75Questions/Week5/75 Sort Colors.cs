namespace LeetCode._75Questions.Week5
{
    public class _75_Sort_Colors
    {
        public static void Test()
        {
            //var input = new [] {2, 0, 2, 1, 1, 0};
            //var input = new[] { 2, 0, 2, 1, 0, 0, 2 };
            //var input = new[] { 0, 0 };
            //var input = new[] { 1, 0, 1 };
            //var input = new[] { 0, 2 };
            var input = new[] { 2, 0, 1 };

            SortColors(input);
            Console.WriteLine(string.Join(", ", input));

        }

        private static void SortColors(int[] nums)
        {
            short left = 0;//treat as position of white
            short _red = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                if (nums[left] == 0)
                {
                    if (_red != left)
                    {
                        var temp = nums[left];
                        nums[left] = nums[_red];
                        nums[_red] = temp;
                    }
                    left++;
                    _red++;
                }
                else if (nums[left] == 2)//Blue
                {
                    var temp = nums[left];
                    nums[left] = nums[right];
                    nums[right] = temp;
                    right--;
                }
                else left++;
            }
        }
    }
}