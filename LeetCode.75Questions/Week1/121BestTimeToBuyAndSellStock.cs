namespace LeetCode._75Questions.Week1
{
    public class _121BestTimeToBuyAndSellStock
    {
        public static void Test()
        {
            //var result1 = MaxProfit(new[] { 1, 3, 5, 2, 8 });
            var result1 = MaxProfit(new[] { 7, 6, 4, 3, 1 });

            Console.Write(result1 + ",");
        }

        public static int MaxProfit(int[] prices)
        {
            var result = 0;
            var min = prices[0];
            var max = prices[0];
            foreach (var pr in prices)
            {
                if (pr < min && pr < max)
                {
                    min = pr;
                    max = pr;
                }
                else if (pr > max)
                {
                    max = pr;
                    result = max - min > result ? max - min : result;
                }
                
            }


            return result;
        }
    }
}