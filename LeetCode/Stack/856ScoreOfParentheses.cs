namespace LeetCode.Stack
{
    public class _856ScoreOfParentheses
    {
        public void DoAction()
        {
            //()()() =3
            // (()) = 2
            // ((())) = 4
            // (()(())) = 6
            // (()()) = 4
            Console.WriteLine(ScoreOfParentheses("(()(()))"));
        }

        public int ScoreOfParentheses(string s)
        {
            var open = '(';

            Stack<int> stack = new Stack<int>();
            var total = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == open)
                    stack.Push(0);
                else
                {
                    var temp = 0;
                    while (stack.Peek() != 0) temp = temp + stack.Pop();
                    temp = temp * 2 < 1 ? 1 : temp * 2;
                    stack.Pop();
                    stack.Push(temp);
                }
            }

            while (stack.Any())
                total += stack.Pop();
            return total;
        }
    }
}