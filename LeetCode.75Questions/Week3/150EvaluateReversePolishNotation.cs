namespace LeetCode._75Questions.Week3
{
    public class _150EvaluateReversePolishNotation
    {
        public static void Test()
        {
            //var input = new[] { "2", "1", "+", "3", "*" };//9
            //var input = new[] { "4", "13", "5", "/", "+" };//6
            var input = new[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };//22

            var output = EvalRPN(input);
            Console.WriteLine(output);

        }
        static int EvalRPN(string[] tokens)
        {
            var stacks = new Stack<int>();
            var length = tokens.Length;
            for (var i = 0; i < length; i++)
            {
                switch (tokens[i])
                {
                    case "+":
                        var _plussecond = stacks.Pop();
                        var _plusfirst = stacks.Pop();
                        stacks.Push(_plusfirst + _plussecond);
                        break;
                    case "-":
                        var _subsecond = stacks.Pop();
                        var _subfirst = stacks.Pop();
                        stacks.Push(_subfirst - _subsecond);

                        break;
                    case "*":
                        var _multisecond = stacks.Pop();
                        var _multifirst = stacks.Pop();
                        stacks.Push(_multifirst * _multisecond);

                        break;
                    case "/":
                        var _divsecond = stacks.Pop();
                        var _divfirst = stacks.Pop();
                        stacks.Push(_divfirst / _divsecond);
                        break;
                    default:
                        var num = convert(tokens[i]);
                        stacks.Push(num);
                        break;
                }
            }

            return stacks.Pop();
        }

        static short convert(string input)
        {
            short res = 0;

            var length = input.Length - 1;
            for (var i = length; i >= 0; i--)
            {
                if (input[i] >= '0' && input[i] <= '9')
                    res += (short)((input[i] - '0') * Math.Pow(10, length - i));
            }

            if (input[0] == '-')
            {
                res = (short)(0 - res);
            }
            return res;
        }
    }


}