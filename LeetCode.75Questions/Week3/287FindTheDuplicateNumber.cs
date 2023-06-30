using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._75Questions.Week3
{
    public class _287FindTheDuplicateNumber
    {
        public static void Test()
        {
            //var res = FindDuplicate(new[] { 2, 5, 9, 6, 9, 3, 8, 9, 7, 1 });//9
            //var res = FindDuplicate(new[] { 1, 3, 4, 2, 2 });//2
            var res = FindDuplicate(new[] { 1, 4, 2, 3, 2 });//2
            //var res = FindDuplicate(new[] { 3, 1, 3, 4, 2 });//3
            Console.WriteLine(res);
        }

        static int FindDuplicate(int[] nums)
        {
            var num1 = nums[0];
            var num2 = nums[nums[0]];
            
            while(num1 != num2)
            {
                num1 = nums[num1];
                num2 = nums[nums[num2]];
            }

            var checkDuplicated = 0;
            while(checkDuplicated != num1) {
                num1 = nums[num1];
                checkDuplicated = nums[checkDuplicated];
            }
            return checkDuplicated;
        }
    }
}
