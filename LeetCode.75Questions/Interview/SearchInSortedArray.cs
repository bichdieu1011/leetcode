using Newtonsoft.Json;

namespace LeetCode._75Questions.Interview
{
    internal class Test1
    {
        public static void Test()
        {
            Console.WriteLine($"[1,3,5,6]; target = 2; res = {SearchInsert(new[] { 1, 3, 5, 6 }, 2)}");
            Console.WriteLine($"[1,3,5,6]; target = 7; res = {SearchInsert(new[] { 1, 3, 5, 6 }, 7)}");
            Console.WriteLine($"[1,3,5,6]; target = 7; res = {SearchInsert(new[] { 1, 3, 5, 6 }, 7)}");

            Console.WriteLine($"input = [[1,1,0],[1,1,0],[0,0,1]]; res = {FindCircleNum(JsonConvert.DeserializeObject<int[][]>("[[1,1,0],[1,1,0],[0,0,1]]"))}");
            Console.WriteLine($"input = [[1,0,0,1],[0,1,1,0],[0,1,1,1],[1,0,1,1]]; res = {FindCircleNum(JsonConvert.DeserializeObject<int[][]>("[[1,0,0,1],[0,1,1,0],[0,1,1,1],[1,0,1,1]]"))}");
        }

        /// <summary>
        /// https://leetcode.com/problems/search-insert-position/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private static int SearchInsert(int[] nums, int target)
        {
            var l = 0;
            var r = nums.Length - 1;

            while (l <= r)
            {
                var m = l + (r - l) / 2;
                if (nums[m] == target) return m;
                if (nums[m] >= target)
                    r = m - 1;
                else l = m + 1;
            }
            return l;
        }

        /// <summary>
        /// https://leetcode.com/problems/number-of-provinces/
        /// </summary>
        /// <param name="isConnected"></param>
        /// <returns></returns>
        private static int FindCircleNum(int[][] isConnected)
        {
            var count = 0;
            var length = isConnected.Length;
            var stacks = new Stack<int>();
            for (var i = 0; i < isConnected.Length; i++)
            {
                for (var j = 0; j < isConnected[i].Length; j++)
                    if (isConnected[i][j] == 1)
                    {
                        isConnected[i][j] = 2;
                        stacks.Push(i);
                        if (i != j)
                        {
                            stacks.Push(j);
                            isConnected[j][i] = 2;
                        }

                        while (stacks.Any())
                        {
                            var item = stacks.Pop();
                            for (var c = 0; c < length; c++)
                            {
                                if (isConnected[item][c] == 1)
                                {
                                    isConnected[item][c] = 2;
                                    isConnected[c][item] = 2;
                                    if (item != c)
                                        stacks.Push(c);
                                }

                            }
                        }
                        count++;
                    }
            }

            return count;
        }
    }
}