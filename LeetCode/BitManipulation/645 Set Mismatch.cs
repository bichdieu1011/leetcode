namespace LeetCode.BitManipulation
{
    public class _645_Set_Mismatch
    {
        public static void Test()
        {
            //Console.WriteLine(String.Join(",", FindErrorNums(new[] { 1, 2, 2, 3, 4 })));
            Console.WriteLine(String.Join(",", FindErrorNums(new[] {  1, 2, 2, 5, 3, 4 })));
        }

        private static int[] FindErrorNums(int[] nums)
        {
            //var expectedSum = 0;
            //var acctualSum = 0;
            var currentXor = 0;
            var expectedXor = 0;
            //var max = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                currentXor ^= nums[i];
                expectedXor ^= (i + 1);
            }

            return new[] { currentXor - expectedXor, 0 };
        }
    }
}