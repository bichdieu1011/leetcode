namespace LeetCode._75Questions.Week2
{
    internal class _383RansomNote
    {
        public static void Test()
        {
            var result = CanConstruct("anagram", "anagrma");

            Console.WriteLine(result);
        }

        private static bool CanConstruct(string ransomNote, string magazine)
        {
            var dicts = new Dictionary<char, int>();

            for (int i = 0; i < magazine.Length; i++)
            {
                if (dicts.ContainsKey(magazine[i]))
                    dicts[magazine[i]]++;
                else dicts.Add(magazine[i], 1);
            }

            foreach (var character in ransomNote)
            {
                if (!dicts.ContainsKey(character) || dicts[character] <= 0)
                    return false;

                dicts[character]--;
            }
            return true;
        }
    }
}