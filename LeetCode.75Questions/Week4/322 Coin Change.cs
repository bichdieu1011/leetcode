namespace LeetCode._75Questions.Week4
{
    public class _322_Coin_Change
    {
        public static void Test()
        {
            //var res = CoinChange(new[] { 5, 1, 2, 3 }, 34);//8
            //var res = CoinChange(new[] { 1, 2 }, 3);
            var res = CoinChange(new[] { 2 }, 3);
            //var res = CoinChange(new[] { 186, 419, 83, 408 }, 6249);//20
            //var res = CoinChange(new[] { 5, 6, 10, 11 }, 12);//2
            Console.WriteLine(res);
        }

        private static int CoinChange(int[] coins, int amount)
        {
            var temp = new int[amount +1];
            Array.Fill(temp, 10001);
            temp[0] = 0;
            for (int i = 1; i <= amount; i++)
            {
                for (var j = 0; j < coins.Length; j++)
                {
                    if (coins[j] <= i )
                        temp[i] = temp[i - coins[j]] + 1 < temp[i] ? temp[i - coins[j]] + 1 : temp[i];
                }
            }
            return temp[amount] == 10001 ? -1 : temp[amount];
        }
    }
}