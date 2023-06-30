namespace LeetCode.BinarySearch
{
    public class _268MissingNumber
    {
        public void DoAction()
        {
            //var input = new[] { 1, 2, 5, 2, 3 }; //5 -- 4
            //var input = new[] { 1, 10, 2, 9, 3, 8, 4, 7, 5, 6 }; //4,2
            //var input = new[] { 0, 1, 4, 3 }; //6 --2
            var input = new[] { 3, 0, 1 }; //2

            var result = MissingNumber(input);
            Console.WriteLine($"Missing: {result}");
        }

        public int MissingNumber(int[] nums)
        {
            int sum = 0,  currentSum = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                currentSum += nums[i];
                sum += i;
            }

            sum += nums.Length;

            
            return sum - currentSum;
        }
    }
}