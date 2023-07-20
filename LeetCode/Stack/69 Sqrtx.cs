using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Stack
{
    public class _69_Sqrtx
    {
        public static void Test()
        {
            //Console.WriteLine(MySqrt(8));
            //Console.WriteLine(MySqrt(1));
            //Console.WriteLine(MySqrt(0));
            Console.WriteLine(MySqrt(2147395599));
        }
        public static int MySqrt(int x)
        {
            var l = 0;
            var r = x / 2 > 1 ? x / 2:1;
            var res = 0;
            while (l <= r)
            {
                var m = l + (r - l) / 2;
                var sq = (long) m * m;
                if (sq == x) return m;
                if (sq > x) r = m - 1;
                else
                {
                    res = res > m ? res : m;
                    l = m + 1;
                }

            }

            return res;
        }
    }
}
