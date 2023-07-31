using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._75Questions.Week7
{
    public class _438_Find_All_Anagrams_in_a_String
    {
        public static void Test()
        {
            //Console.WriteLine(JsonConvert.SerializeObject(FindAnagrams("cbaebabacd", "abc")));
            Console.WriteLine(JsonConvert.SerializeObject(FindAnagrams("cbaebabacd", "aabbc")));
            //Console.WriteLine(JsonConvert.SerializeObject(FindAnagrams("abab", "ab")));
        }

        static IList<int> FindAnagrams(string s, string p)
        {
            var res = new List<int>();

            var left = 0;
            var right = 0;
            var dict = new Dictionary<char, int>();
            var count = new Dictionary<char, int>();

            foreach (var item in p)
            {
                if (dict.ContainsKey(item))
                    dict[item]++;
                else
                {
                    dict.Add(item, 1);
                    count.Add(item, 0);
                }                    
            }

            while (right < s.Length)
            {
                if (dict.ContainsKey(s[right]))
                {
                    count[s[right]]++;

                    if (count[s[right]] > dict[s[right]])
                    {
                        while (count[s[right]] > dict[s[right]])
                        {
                            count[s[left]]--;
                            left++;
                        }
                    }
                    else
                    {
                        if (right - left + 1 == p.Length)
                        {
                            res.Add(left);
                            count[s[left]]--;
                            left++;
                        }
                    }
                    right++;
                }
                else
                {
                    while (left < right)
                    {
                        count[s[left]]--;
                        left++;
                    }
                    left++;
                    right++;
                }
            }

            return res;

        }
    }
}
