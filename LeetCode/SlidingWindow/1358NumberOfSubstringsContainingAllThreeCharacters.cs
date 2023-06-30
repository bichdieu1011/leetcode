using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.SlidingWindow
{
    public class _1358NumberOfSubstringsContainingAllThreeCharacters
    {
        public void DoAction()
        {
            //abcabc = 10
            // aaacb = 3
            // abc =1
            Console.WriteLine(NumberOfSubstrings("aaabc"));
        }
        public int NumberOfSubstrings(string s)
        {
            var score = new Dictionary<char, short>()
            {
                {'a',0 },
                {'b',0 },
                {'c',0 }
            };

            int count = 0,
                start = 0,
                end = 0,
                length = s.Length;

            while (end <= length)
            {               

                if (score['a'] > 0 && score['b'] > 0 && score['c'] > 0)
                {
                    count += length - end + 1;
                    score[s[start]]--;
                    start++;
                }
                else
                {
                    if (end >= length)
                        break;

                    score[s[end]]++;
                    end++;

                }


            }
            return count;
        }
    }
}
