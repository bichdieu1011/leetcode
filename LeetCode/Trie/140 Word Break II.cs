using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Trie
{
    public class _140_Word_Break_II
    {
        /// <summary>
        /// https://leetcode.com/problems/word-break-ii/
        /// </summary>
        public static void Test()
        {
            Console.WriteLine(JsonConvert.SerializeObject(WordBreak("leetcode", new List<string> { "leet", "code" })));
            Console.WriteLine(JsonConvert.SerializeObject(WordBreak("applepenapple", new List<string> { "apple", "pen", "applepen", "pine", "pineapple" })));
            Console.WriteLine(JsonConvert.SerializeObject(WordBreak("catsandog", new List<string> { "cat", "cats", "and", "sand", "dog" })));
            Console.WriteLine(JsonConvert.SerializeObject(WordBreak("catsandog", new List<string> { "cats", "dog", "sand", "and", "cat" })));
            Console.WriteLine(JsonConvert.SerializeObject(WordBreak("a", new List<string> { "a" })));
            Console.WriteLine(JsonConvert.SerializeObject(WordBreak("abcd", new List<string> { "a", "abc", "b", "cd" })));

        }

        static IList<string> WordBreak(string s, IList<string> wordDict)
        {
            var trie = new Trie();
            foreach (var word in wordDict)
                trie.Set(word);

            var dp = new bool[s.Length + 1];
            dp[0] = true;

            var subString = new List<string>[s.Length + 1];
            subString[0] = new List<string>();

            for (var i = 0; i < s.Length; i++)
            {
                if (subString[i] == null) continue;

                var tree = trie;
                var j = i;
                while (j < s.Length && tree.childs.Any())
                {
                    if (tree.childs.ContainsKey(s[j]))
                    {
                        tree = tree.childs[s[j]];
                        if (tree.end)
                        {
                            if (subString[j + 1] is null) subString[j + 1] = new List<string>();
                            if (subString[i].Any())
                                foreach (var item in subString[i])
                                    subString[j + 1].Add(item + " " + s.Substring(i, j - i + 1));
                            else subString[j + 1].Add(s.Substring(i, j - i + 1));
                        }
                        j++;
                    }
                    else break;
                }
            }

            return subString[s.Length] == null ? new List<string>() : subString[s.Length];
        }


        class Trie
        {
            public bool end = false;
            public Dictionary<char, Trie> childs;
            public Trie()
            {
                childs = new Dictionary<char, Trie>();
            }

            public void Set(string input)
            {
                var temp = this;
                foreach (char c in input)
                {
                    if (!temp.childs.ContainsKey(c))
                        temp.childs.Add(c, new Trie());
                    temp = temp.childs[c];
                }
                temp.end = true;
            }
        }
    }
}
