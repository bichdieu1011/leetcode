using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Stack
{
    public class _13RomanToInteger
    {
        public void DoAction()
        {
            //III = 3
            //IV = 4
            //MCMXCIV = 1994
            // LVIII = 58
            Console.WriteLine(RomanToInt("MCMXCIV"));
        }
        public int RomanToInt(string s)
        {
            //var key = new List<char> { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            //var values = new List<short> { 1, 5, 10, 50, 100, 500, 1000 };
            var dictionary = new Dictionary<char, short>()
            {
                {'I',1 },
                {'V',5 },
                {'X',10 },
                {'L',50 },
                {'C',100 },
                {'D',500 },
                {'M',1000 },
            };

            Stack<short> results = new Stack<short>();

            for (var i = 0; i < s.Length; i++)
            {
                if (results.Any() && dictionary[s[i]] >= results.Peek())
                {
                    var temp = dictionary[s[i]];
                    while (results.Any())
                        temp = (short)(results.Peek() < temp ? temp - results.Pop() : temp + results.Pop());
                    results.Push(temp);
                }
                else
                    results.Push(dictionary[s[i]]);
            }

            var total = 0;
            while (results.Any())
            {
                total = results.Peek() < total ? total - results.Pop() : total + results.Pop();
            }

            return total;
        }
    }
}
