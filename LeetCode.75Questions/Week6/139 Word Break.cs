using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._75Questions.Week6
{
    public class _139_Word_Break
    {
        public static void Test()
        {
            Console.WriteLine(WordBreak("leetcode", new List<string> { "leet", "code" }));//true
            Console.WriteLine(WordBreak("applepenapple", new List<string> { "apple", "pen" }));//true
            Console.WriteLine(WordBreak("catsandog", new List<string> { "cats", "dog", "sand", "and", "cat" }));//false
            Console.WriteLine(WordBreak("a", new List<string> { "a" }));//true
            Console.WriteLine(WordBreak("abcd", new List<string> { "a", "abc", "b", "cd" }));//true
            Console.WriteLine(WordBreak("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab", new List<string> { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" }));//false

        }

        static bool WordBreak(string s, IList<string> wordDict)
        {
            var trie = new Trie();
            foreach (var word in wordDict)
                trie.Set(word);


            var dp = new bool[s.Length + 1];
            dp[0] = true;
            var indexs = new Stack<int>();
            indexs.Push(0);
            for (var i = 0; i < s.Length; i++)
            {
                if (!dp[i]) continue;

                var tree = trie;
                var j = i;
                while (j < s.Length && tree.childs.Any())
                {
                    if (tree.childs.ContainsKey(s[j]))
                    {
                        tree = tree.childs[s[j]];
                        if (tree.end) dp[j + 1] = true;
                        j++;
                    }
                    else break;
                }
            }

            return dp[s.Length];
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

            public List<string> pickPotential(string input, int startIndex)
            {
                var lstPotential = new List<string>();

                var temp = this;
                var end = startIndex;
                while (end < input.Length)
                {
                    if (temp.childs.Count == 0)
                    {
                        lstPotential.Add(input.Substring(startIndex, end - startIndex));
                        break;
                    };
                    if (!temp.childs.ContainsKey(input[end])) break;

                    if (temp.childs[input[end]].end) lstPotential.Add(input.Substring(startIndex, end - startIndex + 1));


                    //temp[input[startIndex]].end = true;

                    temp = temp.childs[input[end]];
                    end++;

                }
                return lstPotential;
            }
        }
    }
}
