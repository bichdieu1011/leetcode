namespace LeetCode._75Questions.Week2
{
    public class _169MajorityElement
    {
        public static void Test()
        {
            var result = MajorityElement(new[] { 2, 2, 1, 1, 1, 2, 2 });

            Console.Write(result);
        }

        private static int MajorityElement(int[] nums)
        {

            var mid = nums.Length / 2;
            var hasChanged = true;
            while (hasChanged)
            {
                hasChanged = false;
                for (var i = 0; i < nums.Length; i++)
                {
                    if (i < mid && nums[i] > nums[mid])
                    {
                        hasChanged = true;
                        var temp = nums[i];
                        nums[i] = nums[mid];
                        nums[mid] = temp;
                    }

                    if (i > mid && nums[i] < nums[mid])
                    {
                        hasChanged = true;
                        var temp = nums[i];
                        nums[i] = nums[mid];
                        nums[mid] = temp;
                    }
                }
            }

            return nums[mid];
        }
    }
}