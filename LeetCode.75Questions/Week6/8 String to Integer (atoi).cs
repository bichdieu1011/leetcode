namespace LeetCode._75Questions.Week6
{
    public class _8_String_to_Integer__atoi_
    {
        public static void Test()
        {
            Console.WriteLine(MyAtoi("43"));
            Console.WriteLine(MyAtoi("-43"));
            Console.WriteLine(MyAtoi("+43"));
            Console.WriteLine(MyAtoi(" s  --43"));
            Console.WriteLine(MyAtoi("-91283472332"));
            Console.WriteLine(MyAtoi("0000000000012345678"));
            Console.WriteLine(MyAtoi("00000 - 42a1234"));//0
        }

        private static int MyAtoi(string s)
        {
            bool? isNegative = null;
            
            long res = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (isNegative == null)
                {
                    if (s[i] == '-' || s[i] == '+')
                    {
                        isNegative = s[i] == '-';
                    }
                    else if (s[i] == ' ') continue;
                    else if (!(s[i] >= '0' && s[i] <= '9')) break;
                    else
                    {
                        isNegative = isNegative ?? false;
                        res = res * 10 + (byte)(s[i] - '0');
                    }
                }
                else
                {
                    if (!(s[i] >= '0' && s[i] <= '9')) break;
                    res = res * 10 + (byte)(s[i] - '0');
                    if (res > int.MaxValue)
                    {
                        return isNegative == true ? int.MinValue : int.MaxValue;
                    }
                }
            }

            return isNegative == true ? (int)-res : (int)res;
        }
    }
}