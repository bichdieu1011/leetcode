namespace LeetCode._75Questions
{
    public class MaxSum
    {
        public static void Test()
        {
            //var input = new[] { 1, 2, 3, 4, 5, 6, 1 };//12
            //var input = new[] { 1, 2, 3, -4, 5, 6, 1 };//10
            var input = new[] { 1, 2, 3, 4, 1, 6, 9 };//14
            var result = CalMaxSum(input);
            Console.WriteLine(result);
        }

        public static int CalMaxSum(int[] nums)
        {
            var sumEven = 0;
            var sumOdd = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= 0)
                {
                    sumEven = sumEven > sumOdd ? sumEven : sumOdd;
                    sumOdd = sumOdd > sumEven ? sumOdd : sumEven;
                    continue;
                }

                if (i % 2 == 0)
                    sumEven += nums[i];
                else
                    sumOdd += nums[i];
            }

            return sumEven > sumOdd ? sumEven : sumOdd;
        }
    }
}