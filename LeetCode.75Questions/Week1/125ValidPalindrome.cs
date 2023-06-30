using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._75Questions.Week1
{
    public class _125ValidPalindrome
    {
        public static void Test()
        {
            //var result1 = MaxProfit(new[] { 1, 3, 5, 2, 8 });
            //var result1 = IsPalindrome("A man, a plan, a canal: Panama");//true
            //var result1 = IsPalindrome("race a car");
            //var result1 = IsPalindrome("");//false
            var result1 = IsPalindrome("ab");//false

            Console.Write(result1 + ",");
        }
        public static bool IsPalindrome(string s)
        {
            var input = s.ToArray();
            var newS = new StringBuilder();
            for (var i = 0; i <= input.Length - 1; i++)
            {
                if (input[i] <= 'Z' && input[i] >= 'A')
                {
                    newS.Append((char)(input[i] + 32));
                }
                else if (input[i] >= 'a' && input[i] <= 'z' || input[i] >= '0' && input[i] <= '9')
                {
                    newS.Append(input[i]);
                }
            }

            //input = newS.();
            if (newS.Length == 0)
                return true;
            var length = (newS.Length - 1) / 2;

            for (var i = 0; i <= length; i++)
            {
                if (newS[i] != newS[newS.Length - 1 - i])
                    return false;
            }

            return true;
        }
    }
}
