using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Plume
{
    public class Test1
    {
        public static void Test()
        {
            var inpu = "MinusPlusMinusMinusPlusMinusMinusPlusMinusPlusMinusMinusPlusMinusMinusPlusMinusMinusPlusMinusMinusPlusMinusMinus";
            Console.WriteLine(solution(inpu));

        }

        static string solution(string S)
        {            
            StringBuilder sb = new StringBuilder();
            for(var i = 0; i < S.Length;i++)
            {
                switch (S[i])
                {
                    case 'm':
                    case 'M':
                        sb.Append("-");
                        i = i + 3;
                        break;
                    case 'p':
                    case 'P':
                        sb.Append("+");
                        i = i + 2;
                        break;
                }
            }
            return sb.ToString();
        }
    }
}
