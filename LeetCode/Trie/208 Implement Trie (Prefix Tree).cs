using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Trie
{
    public class _208_Implement_Trie__Prefix_Tree_
    {
        public static void Test()
        {

            Trie obj = new Trie();
            obj.Insert("keyword");
           Console.WriteLine(obj.Search("keyword"));
            Console.WriteLine(obj.StartsWith("keys"));
        }

    }

    public class Trie
    {
        Dictionary<char, Trie> chars;
        bool isEnd = false;
        public Trie()
        {
            chars = new Dictionary<char, Trie>();
            isEnd = false;
        }

        public void Insert(string word)
        {
            var temp = this;
            foreach (var c in word)
            {
                if (!temp.chars.ContainsKey(c))
                {
                    temp.chars.Add(c, new Trie());
                }

                temp = temp.chars[c];
            }

            temp.isEnd = true;
        }

        public bool Search(string word)
        {
            var temp = this;
            for(var i =0; i < word.Length; i++)
            {
                
                if (temp.chars.ContainsKey(word[i]))
                {                    
                    temp = temp.chars[word[i]];
                }
                    
                else return false;
            }
            return temp.isEnd;
        }

        public bool StartsWith(string prefix)
        {
            var temp = chars;

            foreach (var c in prefix)
            {
                if (temp.ContainsKey(c))
                    temp = temp[c].chars;
                else return false;
            }
            return true;
        }
    }

}
