using Newtonsoft.Json;
using System.Text;

namespace LeetCode._75Questions.Week7
{
    public class _17_Letter_Combinations_of_a_Phone_Number
    {
        public static void Test()
        {
            Console.WriteLine(JsonConvert.SerializeObject(LetterCombinations("23")));
            Console.WriteLine(JsonConvert.SerializeObject(LetterCombinations("2")));
            Console.WriteLine(JsonConvert.SerializeObject(LetterCombinations("")));
        }

        private static IList<string> LetterCombinations(string digits)
        {
            var keyboards = new Dictionary<char, string>
            {
                {'2',"abc"},
                {'3',"def"},
                {'4',"ghi"},
                {'5',"jkl"},
                {'6',"mno"},
                {'7',"pqrs"},
                {'8',"tuv"},
                {'9',"wxyz"}
            };
            if (digits.Length == 0) return new List<string>();

            var st = new Stack<List<char>>();
            st.Push(new List<char>());
            foreach (var digit in digits)
            {
                var lst = new List<List<char>>();
                while (st.Count > 0) lst.Add(st.Pop());
                for (var j = 0; j < keyboards[digit].Length; j++)
                {
                    for (var i = 0; i < lst.Count; i++)
                    {

                        var newItem = lst[i].ToList();
                        newItem.Add(keyboards[digit][j]);
                        st.Push(newItem);
                    }
                }
            }

            var res = new List<string>();
            while (st.Count > 0)
            {
                var sb = new StringBuilder();
                var tops = st.Pop();
                foreach (var digit in tops) sb.Append(digit);
                res.Add(sb.ToString());
            }
            return res.ToList();
        }
    }
}