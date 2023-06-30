namespace LeetCode._75Questions.Week3
{
    public class _3LongestSubstringWithoutRepeatingCharacters
    {
        public static void DoAction()
        {
            //var result = LengthOfLongestSubstring("abcggfbasc");//573509250
            var result = LengthOfLongestSubstring("abcabcbb");//573509250

            Console.WriteLine(result);
        }

        static int LengthOfLongestSubstring(string s)
        {
            var result = 0;
            if (s.Length <= 1)
                return s.Length;

            var pointer1 = 0;
            var pointer2 = 0;

            var dicts = new Dictionary<char, short>();
            while (pointer2 < s.Length && pointer1 <= pointer2)
            {
                if (!dicts.ContainsKey(s[pointer2]))
                {
                    dicts.Add(s[pointer2], 1);

                    result = result > pointer2 - pointer1 + 1 ? result : pointer2 - pointer1 + 1;
                    pointer2++;

                }
                else
                {
                    if (dicts[s[pointer2]] == 1)
                    {
                        dicts[s[pointer1]]--;
                        pointer1++;
                        pointer2 = pointer1 >= pointer2 ? pointer1 : pointer2;

                    }
                    else
                    {
                        dicts[s[pointer2]]++;
                        result = result > pointer2 - pointer1 + 1 ? result : pointer2 - pointer1 + 1;
                        pointer2++;
                    }
                }

            }

            return result;
        }
    }
}