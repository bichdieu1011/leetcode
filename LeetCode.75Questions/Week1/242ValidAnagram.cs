using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._75Questions.Week1
{
    public class _242ValidAnagram
    {
        public static void Test()
        {
           
            var result = IsAnagram("anagram", "anagrma");

            Console.WriteLine(result);
        }

        public static bool IsAnagram(string s, string t)
        {
            var count1 = new Dictionary<char, int>();
            for(var i=0; i<s.Length; i++)
            {
                if (count1.ContainsKey(s[i]))
                    count1[s[i]]++;
                else count1.Add(s[i], 1);
            }

            for(var i=0;i<t.Length; i++)
            {
                if (!count1.ContainsKey(t[i]))
                    return false;
                else
                {
                    count1[t[i]]--;
                    if (count1[t[i]] < 0)
                        return false;
                }
            }

            foreach(var key in  count1.Keys) {
                if (count1[key] > 0)
                    return false;
            }
            return true;
        }
    }
}
