namespace LeetCode.BitManipulation
{
    public class _2595NumberOfEvenandOddBits
    {
        public static void Test()
        {
            Console.WriteLine(String.Join(",", EvenOddBit(17)));
        }

        private static int[] EvenOddBit(int n)
        {
            var checkOdd = 682 & n;// Convert.ToInt32("1010101010", 2);
            var checkEven = 341 & n;// Convert.ToInt32("0101010101", 2);

            int countOdd = 0;
            while (checkOdd != 0)
            {
                while (checkOdd == checkOdd >> 2 << 2 && checkOdd != 0)
                {
                    checkOdd = checkOdd >> 2;
                }
                countOdd++;
                checkOdd = checkOdd >> 2;
            }

            int countEven = 0;
            while (checkEven != 0)
            {
                while (checkEven == checkEven >> 2 << 2 && checkEven != 0)
                {
                    checkEven = checkEven >> 2;
                }
                countEven++;
                checkEven = checkEven >> 2;
            }
            return new[] { countEven, countOdd };
        }
    }
}