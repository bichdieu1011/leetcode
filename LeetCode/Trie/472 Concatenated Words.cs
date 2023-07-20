using Newtonsoft.Json;

namespace LeetCode.Trie
{
    public class _472_Concatenated_Words
    {
        public static void Test()
        {
            Console.WriteLine(JsonConvert.SerializeObject(FindAllConcatenatedWordsInADict(new[] { "cat", "cats", "catsdogcats", "dog", "dogcatsdog", "hippopotamuses", "rat", "ratcatdogcat" })));
        }

        private static IList<string> FindAllConcatenatedWordsInADict(string[] words)
        {
            var res = new List<string>();

            return res;
        }

        private class Trie
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