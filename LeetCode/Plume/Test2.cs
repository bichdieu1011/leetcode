using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Plume
{
    public class Test2
    {
        public static void Test()
        {
            int input = 0;
            //Console.WriteLine(Convert.ToString(1000000000, 2));//-1
            //Console.WriteLine(Convert.ToString(82, 2));//-1

            //input = 892;//-1
            //input = Convert.ToInt32("1111111111111111", 2);//1
            input = Convert.ToInt32("1010101", 2);//2

            //input = Convert.ToInt32("110111101111101111011111011", 2);//11//116907771
            //input = Convert.ToInt32("111111111101000111111111010001", 2);//14
            //input = Convert.ToInt32("11111101111101111111011111011", 2);//14
            Console.WriteLine(solution(input));
        }

        static int solution(int n)
        {
            int[] d = new int[30];
            int l = 0;
            int p;
            while (n > 0)
            {
                d[l] = n % 2;
                n /= 2;
                l++;
            }

            for (p = 1; p < 1 + l; ++p)
            {
                int i;
                bool ok = true;
                for (i = 0; i < l - p; ++i)
                {
                    if (d[i] != d[i + p])
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok && p <= (1+l)/2)
                {
                    return p;
                }
            }
            return -1;
        }

    }
}
