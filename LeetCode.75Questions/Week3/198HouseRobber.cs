using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._75Questions.Week3
{
    public class _198HouseRobber
    {
        public static void Test()
        {
            var res = Rob(new[] { 1, 2, 3, 4 });//6
            Console.WriteLine(res);
        }
        static int Rob(int[] nums)
        {
            var max = 0;
            var remebers = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                if (remebers.ContainsKey(i))
                {
                    max = remebers[i] < max ? max : remebers[i];
                    continue;
                }

                var check = Check(nums, i, remebers);
                max = max > check ?max : check;
            }
            return max;
        }

        static int Check(int[] nums, int index, Dictionary<int, int> dicts)
        {
            if (index >= nums.Length)
                return 0;

            if(dicts.ContainsKey(index))
                return dicts[index];
            
            var oneStep = Check(nums, index + 2, dicts);
            var twoStep = Check(nums, index + 3, dicts);

            if (oneStep > twoStep)
                dicts.Add(index, nums[index] + oneStep);
            else
                dicts.Add(index, nums[index] + twoStep);

            return dicts[index];
        }
    }
}
