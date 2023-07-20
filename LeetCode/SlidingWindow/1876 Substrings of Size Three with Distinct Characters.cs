using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.SlidingWindow
{
    public class _1876_Substrings_of_Size_Three_with_Distinct_Characters
    {
        public static void Test()
        {
            Console.WriteLine(CountGoodSubstrings("xyzzaz"));//1
            //Console.WriteLine(CountGoodSubstrings("aababcabc"));//4
            Console.WriteLine(CountGoodSubstrings("icolgrjedehnd"));//10


        }
        static int CountGoodSubstrings(string s)
        {
            var start = 0;
            var count = 0;
            var _dic = new Dictionary<char, int>();
            for (var i = 0; i < s.Length; i++)
            {
                if (!_dic.ContainsKey(s[i]))
                    _dic.Add(s[i], 1);
                else _dic[s[i]]++;


                if (_dic[s[i]] > 1)
                {
                    for (var j = start; _dic[s[i]] > 1; j++)
                    {
                        _dic[s[j]]--;
                        start = j + 1;
                    }
                }
                else if (i - start + 1 == 3)
                {
                    _dic[s[start]]--;
                    start++;
                    count++;
                }
            }
            return count;
        }
    }
}
