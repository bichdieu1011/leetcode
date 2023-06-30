namespace LeetCode.BinarySearch
{
    public class _400NthDigit
    {
        public void DoAction()
        {
            var result = FindNthDigit(3);
            Console.WriteLine($"FindNthDigit: {result}");
        }

        public int FindNthDigit(int n)
        {
            int iterator = 1;
            var numbertoDevide = 9 * Math.Pow(10, iterator - 1) * iterator;
            while (n / numbertoDevide > 1)
            {
                iterator++;
                n = n - (int)numbertoDevide;
                numbertoDevide = 9 * Math.Pow(10, iterator - 1) * iterator;
            }

            var valueContainsNumber = Math.Pow(10, iterator - 1) + n/iterator -1;
            var numberOf10ToDevide = iterator - (n + iterator - 1) % iterator - 1;
            for (var i = 0; i < numberOf10ToDevide; i++)
            {
                valueContainsNumber = valueContainsNumber / 10;
            }

            return (int)valueContainsNumber % 10;
        }
    }
}