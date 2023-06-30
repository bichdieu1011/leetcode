using System.Text;

namespace LeetCode._75Questions.Week2
{
    public class _67AddBinary
    {
        public static void Test()
        {
            //var result = AddBinary("1010", "1011");//10101
            //var result = AddBinary("11", "1");//100
            var result = AddBinary("100", "110010");//100
            //var result = AddBinary("0", "0");//100

            Console.WriteLine(result);
        }

        private static string AddBinary(string a, string b)
        {
            var larger = b.Length > a.Length ? b : a;
            var smaller = b.Length > a.Length ? a : b;
            var bits = new short?[larger.Length + 1];
            var remember = false;
            for (var i = 0; i < larger.Length; i++)
            {
                var largerValue = larger[larger.Length - 1 - i];
                var smallerValue = smaller.Length - 1 - i < 0 ? '0' : smaller[smaller.Length - 1 - i];
                if (largerValue == smallerValue)
                {
                    bits[i] = (short)(remember ? 1 : 0);
                    remember = largerValue == '1';
                }
                else
                {
                    bits[i] = (short)(remember ? 0 : 1);
                }
            }

            if (remember)
            {
                bits[larger.Length] = 1;
            }

            var result = new StringBuilder();
            for (var i = bits.Length - 1; i >= 0; i--)
            {
                if (bits[i] != null)
                    result.Append(bits[i]);
            }
            return result.ToString();
        }
    }
}