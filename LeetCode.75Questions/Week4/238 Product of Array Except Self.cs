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
            if(nums is null || nums.Length ==0)
                return new int[0];
            var res = new int[nums.Length];
            Array.Fill(res, 1);

            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = 0; j < i; j++)
                    res[j] *= nums[i];
                for (var j = i + 1; j < nums.Length; j++)
                    res[j] *= nums[i];
            }
            return res;
        }
    }
}