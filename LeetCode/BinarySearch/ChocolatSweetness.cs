namespace LeetCode.BinarySearch
{
    public class ChocolatSweetness
    {
        public void DoAction()
        {
            var input = new[] { 6, 3, 2, 8, 7, 5 }; //3 --9

            Console.WriteLine(SplitArray(input, 3));
        }

        public int SplitArray(int[] nums, int k)
        {
            var sum = 0;
            var maxValue = 0;
            foreach (var num in nums)
            {
                sum += num;
                maxValue = maxValue > num ? maxValue : num;
            }

            var left = maxValue;
            var right = sum;
            while (left <= right)
            {
                var middle = left + (right - left) / 2;
                if (CoudGenerateArray(nums, k, middle))
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }
            return right;
        }

        private bool CoudGenerateArray(int[] nums, int numberOfArray, int MaxValue)
        {
            var totalArray = 1;
            var sumArray = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                sumArray += nums[i];
                if (sumArray >= MaxValue)
                {
                    totalArray++;
                    sumArray = 0;
                }
            }

            return !(numberOfArray < totalArray);
        }
    }
}