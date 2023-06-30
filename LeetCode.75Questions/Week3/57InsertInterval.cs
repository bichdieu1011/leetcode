namespace LeetCode._75Questions.Week3
{
    public class _57InsertInterval
    {
        public static void Test()
        {
            //var intervals = new[]{
            //    new[] {1,3},
            //    new[] {6,9}};
            //var newInterval = new[] { 2, 5 };

            //var intervals = new[]{
            //    new[] {1,2},
            //    new[] {3,5},
            //    new[] {6,7},
            //    new[] {8,10},
            //    new[] {12,16},

            //};
            //var newInterval = new[] { 4, 8 }; 

            var intervals = new[]{
                new[] {1,5},

            };
            var newInterval = new[] { 5, 7 };

            var result = Insert(intervals, newInterval);

            foreach (var interval in result)
            {
                Console.WriteLine($"[{string.Join(",", interval)}]");
            }
        }

        private static int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var stacks = new Stack<int[]>();
            stacks.Push(newInterval);

            for (var i = 0; i < intervals.Length; i++)
            {
                if (intervals[i][0] < newInterval[0] && intervals[i][1] >= newInterval[0])
                {
                    //intervals[i][0] = newInterval[0];
                    intervals[i][1] = newInterval[1] > intervals[i][1] ? newInterval[1] : intervals[i][1];
                }
                else if (intervals[i][1] > newInterval[1] && intervals[i][0] <= newInterval[1])
                {
                    //intervals[i][0] = newInterval[0];
                    intervals[i][0] = newInterval[0] < intervals[i][0] ? newInterval[0] : intervals[i][0];
                }
                else if (intervals[i][1] <= newInterval[1] && intervals[i][0] >= newInterval[0])
                {
                    intervals[i][0] = newInterval[0];
                    intervals[i][1] = newInterval[1];
                }

                var prev = stacks.Peek();
                if (prev[0] > intervals[i][1])
                {
                    var temp = stacks.Pop();
                    stacks.Push(intervals[i]);

                    stacks.Push(temp);
                    continue;
                }

                if (prev[1] >= intervals[i][0])
                {
                    intervals[i][0] = prev[0] > intervals[i][0] ? intervals[i][0] : prev[0];
                    stacks.Pop();
                    if (!stacks.Any())
                        break;
                }

                stacks.Push(intervals[i]);
            }

            var result = new int[stacks.Count][];
            while (stacks.Count > 0)
            {
                result[stacks.Count - 1] = stacks.Pop();
            }

            return result;
        }
    }
}