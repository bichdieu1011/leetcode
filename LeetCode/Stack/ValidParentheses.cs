using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Stack
{
    public class ValidParentheses
    {
        public bool IsValid(string s)
        {
            Stack<char> temp = new Stack<char>();
            var correcspondingChar = new Dictionary<char, char>()
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' }
            };

            var lenth = s.Length;
            for (var i = 0; i < lenth; i++)
            {
                if (correcspondingChar.ContainsKey(s[i]))
                {
                    temp.Push(s[i]);
                }
                else if (temp.Any() && correcspondingChar[temp.Peek()] == s[i])
                {
                    temp.Pop();
                }
                else
                {
                    return false;
                }
            }

            return !temp.Any();

        }
    }
}
