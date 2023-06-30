namespace LeetCode._75Questions.Week2
{
    public class _409LongestPalindrome
    {
        public static void Test()
        {
            var result = LongestPalindrome("abccccdd");

            Console.WriteLine(result);
        }
        static int LongestPalindrome(string s)
        {
            var dicts = new Dictionary<char, int>();
            for (var i = 0; i < s.Length; i++)
            {
                if (!dicts.ContainsKey(s[i]))
                    dicts.Add(s[i], 1);
                else dicts[s[i]]++;
            }
            var sum = 0;
            var get1cHAR = false;
            foreach (var dict in dicts)
            {
                if (dict.Value / 2 > 0)
                    sum += dict.Value - dict.Value % 2;
                if(dict.Value % 2 > 0 && !get1cHAR)
                {
                    get1cHAR = true;
                    sum++;
                }
            }
            return sum;
        }

    }
}