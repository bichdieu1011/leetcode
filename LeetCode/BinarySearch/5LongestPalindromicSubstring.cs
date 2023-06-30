namespace LeetCode.BinarySearch
{
    public class _5LongestPalindromicSubstring
    {
        public void DoAction()
        {
            //var result = LongestPalindrome("ababdd");//aba, bab
            //var result = LongestPalindrome("abababdd");//ababa
            //var result = LongestPalindrome("a"); //a
            //var result = LongestPalindrome("cbbd"); //bb
            var result = LongestPalindrome("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"); //aca
            //var result = LongestPalindrome("aacabdkacaa"); //aca
            //var result = LongestPalindrome("aba");//aba

            Console.WriteLine(result);
        }

        public string LongestPalindrome(string s)
        {
            var res = string.Empty;
            var count = new Dictionary<char, List<short>>();
            for (short i = 0; i < s.Length; i++)
            {
                if (count.ContainsKey(s[i]))
                    count[s[i]].Add(i);
                else count.Add(s[i], new List<short> { i });
            }

            foreach (var item in count)
            {
                var max = GetPalindromic(s, item.Value);
                res = res.Length > max.Length ? res : max;
            }
            return res;
        }

        private string GetPalindromic(string s, List<short> indexs)
        {
            var result = string.Empty;
            if (indexs.Count == 1)
            {
                return s[indexs[0]].ToString();
            }

            for (var start = 0; start < indexs.Count; start++)
            {
                for (var end = indexs.Count - 1; end >= start; end--)
                {
                    //if (indexs[end] - indexs[start] + 1 <= result.Length)
                    //    return result;
                    var isValid = true;
                    var length = indexs[end] - indexs[start] + 1;
                    var startCheck = indexs[start];
                    var endCheck = indexs[end];
                    while (startCheck <= endCheck)
                    {
                        if (s[startCheck] != s[endCheck])
                        {
                            isValid = false;
                            break;
                        }
                        startCheck++;
                        endCheck--;
                    }

                    if (isValid)
                    {
                        result = result.Length > length ? result : s.Substring(indexs[start], length);
                        break;
                    }
                }
            }

            return result;
        }
    }
}