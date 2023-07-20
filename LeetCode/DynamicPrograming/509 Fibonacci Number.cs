using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DynamicPrograming
{
    public class _509_Fibonacci_Number
    {
        public static void Test()
        {
            //var res = Fib(5);
            var res = Fib(0);//0
            //var res = CountBits(2);
            //var res = CountBits(16);//0,1,1,2,1,2,2,3,1,2,2,3,2,3,3,4,1
            Console.WriteLine(string.Join(",", res));
        }

        static int Fib(int n)
        {
            var nums = new int[n + 1];
            for (var i = 1; i <= n; i++)
            {
                nums[i] = i == 1 ? 1 : nums[i - 1] + nums[i - 2];
            }


            return n < 2 ? nums[n] : nums[n - 1] + nums[n - 2];
        }
    }
}
