using Newtonsoft.Json;

namespace LeetCode._75Questions.Week5
{
    public class _56_Merge_Intervals
    {
        /// <summary>
        /// https://leetcode.com/problems/merge-intervals/
        /// </summary>
        public static void Test()
        {
            //var input = JsonConvert.DeserializeObject<int[][]>("[[1,3],[2,6],[8,10],[15,18]]");
            var input = JsonConvert.DeserializeObject<int[][]>("[[1,4],[0,0]]");
            //var input = JsonConvert.DeserializeObject<int[][]>("[[1,4],[4,5]]");
            var res = Merge_Sort(input);

            Console.WriteLine(JsonConvert.SerializeObject(res));
        }

        private static int[][] Merge_Sort(int[][] intervals)
        {
            intervals = intervals.OrderBy(s => s[0]).ToArray();
            var stack = new Stack<int[]>();

            var index = 0;
            while (index < intervals.Length)
            {
                var top = stack.Any() ? stack.Peek() : null;
                while (top != null && top[1] >= intervals[index][0])
                {
                    stack.Pop();
                    intervals[index][0] = Math.Min(top[0], intervals[index][0]);
                    intervals[index][1] = Math.Max(top[1], intervals[index][1]);
                    top = stack.Any() ? stack.Peek() : null;
                }

                stack.Push(intervals[index]);
                index++;
            }

            var res = new int[stack.Count][];
            for (var i = res.Length - 1; i >= 0; --i)
            {
                res[i] = stack.Pop();
            }
            return res;
        }

    }
}