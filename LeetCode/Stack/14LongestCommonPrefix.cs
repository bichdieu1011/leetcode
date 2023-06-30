using System.Text;

namespace LeetCode.Stack
{
    public class _14LongestCommonPrefix
    {
        public void DoAction()
        {
            var input = new[] { "flower", "flow", "flight" }; //fl
            //var input = new[] { "dog", "racecar", "car" }; //""
            //var input = new[] { "ab", "a" }; //f
            Console.WriteLine(LongestCommonPrefix(input));
        }

        public string LongestCommonPrefix2(string[] strs)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < strs[0].Length; i++)
            {
                for (int j = 0; j < strs.Length; j++)
                {
                    if (strs[j].Length <= i || strs[j][i] != strs[0][i])
                        return stringBuilder.ToString();
                }

                stringBuilder.Append(strs[0][i]);
            }

            return stringBuilder.ToString();
        }

        public string LongestCommonPrefix(string[] strs)
        {
            var trie = new Node();
            var temp = trie;
            for (var i = 0; i < strs[0].Length - 1; i++)
            {
                temp.Char = strs[0][i];
                temp.child = new Node();
                temp = temp.child;
            }
            temp.Char = strs[0][strs[0].Length - 1];
            temp.end = true;

            temp = trie;
            Node prefix = new Node();
            var count = 0;
            while (temp != null)
            {
                for (var i = 1; i < strs.Length; i++)
                    if (count > strs[i].Length - 1 || strs[i][count] != temp.Char)
                    {
                        temp = null;
                        break;
                    }

                if (temp != null)
                {
                    prefix = temp;
                    temp = temp.child;
                }

                count++;
            }
            StringBuilder stringBuilder = new StringBuilder();
            while (trie != prefix)
            {
                stringBuilder.Append(trie.Char);
                trie = trie.child;
            }
            if (prefix != null)
                stringBuilder.Append(prefix.Char);
            return stringBuilder.ToString();
        }

        private class Node
        {
            public bool end = false;
            public char Char { get; set; }
            public Node child { get; set; }
        }
    }
}