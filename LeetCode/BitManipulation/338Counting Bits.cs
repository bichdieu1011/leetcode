namespace LeetCode.BitManipulation
{
    public class _338Counting_Bits
    {
        public static void Test()
        {
            var res = CountBits(5);
            //var res = CountBits(2);
            //var res = CountBits(16);//0,1,1,2,1,2,2,3,1,2,2,3,2,3,3,4,1
            Console.WriteLine(string.Join(",", res));
        }

        private static int[] CountBits(int n)
        {
            var res = new int[n + 1];
            short count = 0;
            for (var i = 1; i <= n; i++)
            {
                if (1 << count == i)
                {
                    count++;
                    res[i] = 1;
                }
                else
                {
                    res[i] = 1 + res[i - (1 << (count - 1))];
                }
            }

            return res;
        }
    }
}