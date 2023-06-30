namespace LeetCode._75Questions.Week3
{
    public class _153Sum
    {
        public static void Test()
        {
            //var result = ThreeSum(new[] { -1, 0, 1, 2, -1, -4 }); //
            //var expected = "[[-1,-1,2],[-1,0,1]]";

            //var result = ThreeSum(new[] { 0, 0, 0, 0 });
            //var expected = "[0,0,0]";

            //var result = ThreeSum(new[] { 1, -1, -1, 0 });//[[-1,0,1]]
            //var result = ThreeSum(new[] { -2, 0, 0, 2, 2 });//[[-1,0,1]]
            //var result = ThreeSum(new[] { 0, 1, 1 });
            //var result = ThreeSum(new[] { -1, 0, 1, 0 });
            //var result = ThreeSum(new[] { 3, 0, -2, -1, 1, 2 });//[-2,-1,3],[-2,0,2],[-1,0,1]

            var result = ThreeSum(new[] { -1, 0, 1, 2, -1, -4, -2, -3, 3, 0, 4 });
            var expected = "[[-4,0,4],[-4,1,3],[-3,-1,4],[-3,0,3],[-3,1,2],[-2,-1,3],[-2,0,2],[-1,-1,2],[-1,0,1]]";
            Console.WriteLine($"expected: {expected}");

            foreach (var item in result)
            {
                Console.WriteLine($"[{string.Join(", ", item)}]");
            }
        }

        static IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();
            sort(nums, 0, nums.Length - 1);
            for (var i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;

                var start = i + 1;
                var end = nums.Length - 1;
                while (start < end)
                {
                    if (nums[i] + nums[start] + nums[end] == 0)
                    {
                        result.Add(new List<int> { nums[i], nums[start], nums[end] });

                        //while (nums[i] + nums[start] + nums[end] == 0  && i < end - 1) { i++; }

                        var isIncrease = false;

                        if (nums[start + 1] == nums[start])
                        {
                            while (start < end && nums[i] + nums[start] + nums[end] == 0) { start++; isIncrease = true; }
                        }

                        if (nums[end - 1] == nums[end] && !isIncrease)
                        {
                            while (start < end && nums[i] + nums[start] + nums[end] == 0) { end--; isIncrease = true; }
                            continue;
                        }



                        start = isIncrease ? start : start + 1;

                    }
                    else
                    {
                        if (nums[i] > 0 - nums[start] - nums[end])
                            end--;
                        else start++;

                    }
                }

            }

            return result;
        }

        static void sort(int[] nums, int start, int end)
        {
            if (end == start) return;
            if (end == start + 1)
            {
                if (nums[start] > nums[end])
                {
                    var temp = nums[start];
                    nums[start] = nums[end];
                    nums[end] = temp;
                }
                return;
            }

            var mid = (end + start) / 2;
            sort(nums, start, mid);
            sort(nums, mid, end);

            while (start <= mid && mid <= end)
            {
                if (nums[start] > nums[mid])
                {
                    var temp = nums[mid];
                    for(var i =mid; i > start; i--)
                    {
                        nums[i] = nums[i -1];
                    }

                    nums[start] = temp;
                    start++;
                    mid++;
                }
                else
                {
                    start++;

                }
            }
            return;
        }
    }
}