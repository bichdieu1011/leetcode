namespace LeetCode._75Questions.Week4
{
    public class _322_Coin_Change
    {
        public static void Test()
        {
            //var res = CoinChange(new[] { 5, 1, 2, 3 }, 34);//8
            //var res = CoinChange(new[] { 1,2 }, 3);
            //var res = CoinChange(new[] { 186, 419, 83, 408 }, 6249);//20
            var res = CoinChange(new[] { 5, 6, 10, 11 }, 12);//2
            Console.WriteLine(res);
        }

        private static int CoinChange(int[] coins, int amount)
        {
            var res = 0;
            var sort = _sort(coins);
            for (var i = 0; i < sort.Length; i++)
            {
                if (amount / sort[i] >= 1)
                {
                    var addMore = amount / sort[i];
                    amount -= addMore * sort[i];
                    res += addMore;
                }

            }
            return amount > 0 ? -1 : res;
        }

        static int[] _sort(int[] coins)
        {
            var tok = coins.Length / 2;
            var left = 0;
            var right = coins.Length - 1;
            while (left < right)
            {
                if (tok >= coins.Length)
                    break;
                while (coins[left] > coins[tok])
                {
                    left++;
                }

                while (coins[right] < coins[tok])
                {
                    right--;
                }

                if (coins[left] < coins[right])
                {
                    var temp = coins[left];
                    coins[left] = coins[right];
                    coins[right] = temp;
                    tok = left;
                    left = 0;
                    right = coins.Length - 1;
                }
                else if (left == right)
                {
                    tok++;
                    left = 0;
                    right = coins.Length - 1;
                }
            }
            return coins;
        }

    }
}