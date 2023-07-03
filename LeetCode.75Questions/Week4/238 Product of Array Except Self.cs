namespace LeetCode._75Questions.Week4
{
    public class _238_Product_of_Array_Except_Self
    {
        public static void Test()
        {
            var s = new[] { 1, 2, 3, 4 };

            var res = ProductExceptSelf(s);
            Console.WriteLine(string.Join(",", res));
        }
        private static int[] ProductExceptSelf(int[] nums)
        {
            if (nums is null || nums.Length == 0)
                return new int[0];
            var res = new int[nums.Length];
            res[0] = 1;

            for (var i = 1; i < nums.Length; i++)
            {
                res[i] = res[i - 1] * nums[i - 1];
            }
            var r = 1;
            for (var i = res.Length - 1; i >= 0; i--)
            {
                res[i] *= r;
                r *= nums[i];
            }
            return res;
        }
    }
}