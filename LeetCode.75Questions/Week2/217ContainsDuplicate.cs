using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._75Questions.Week2
{
    public class _217ContainsDuplicate
    {
        public static void Test()
        {
            var result = ContainsDuplicate(new[] { 1, 2, 3, 4, 5 });

            Console.WriteLine(result);
        }

        static bool ContainsDuplicate(int[] nums)
        {
            var dicts = new Dictionary<int, short>();
            for(var i =0; i < nums.Length; i++)
            {
                if (dicts.ContainsKey(nums[i]))
                    return true;
                dicts.Add(nums[i], 1);
            }
            return false;
        }
    }
}
