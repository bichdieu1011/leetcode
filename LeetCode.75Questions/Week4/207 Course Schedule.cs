namespace LeetCode._75Questions.Week4
{
    public class _207_Course_Schedule
    {
        public static void Test()
        {
            //new Item { }
            //var res = CanFinish(5, new int[][] { new[] { 1, 4 }, new[] { 2, 4 }, new[] { 3, 4 }, new[] { 3, 2 } });
            //var res = CanFinish(5, new int[][] { new[] { 1, 0 }, new[] { 0, 1 } });
            //var res = CanFinish(8, new int[][] { new[] { 1, 0 }, new[] { 2, 6 }, new[] { 1, 7 }, new[] { 6, 4 }, new[] { 7, 0 }, new[] { 0, 5 } });
            //var res = CanFinish(7, new int[][] { new[] { 1, 0 }, new[] { 0, 3 }, new[] { 0, 2 },
            //        new[] {3,2}, new[] {2,5 }, new[] { 4,5 }, new[] { 5,6 }, new[] { 2, 4 } });
            //Console.WriteLine(res);

            var s = new MinStack();
            s.Push(2147483646);
            s.Push(2147483646);
            s.Push(2147483647);
            Console.WriteLine(s.Top());
            s.Pop();
            Console.WriteLine(s.GetMin());
            s.Pop();
            Console.WriteLine(s.GetMin());
            s.Pop();
            s.Push(2147483647);
            Console.WriteLine(s.Top());
            Console.WriteLine(s.GetMin());
            s.Push(-2147483648);
            Console.WriteLine(s.Top());
            Console.WriteLine(s.GetMin());
            s.Pop();
            Console.WriteLine(s.GetMin());
        }

        private static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var check = new int[numCourses];
            Array.Fill(check, 1);

            var dict = new Dictionary<int, List<int>>();

            var prerequisitesLength = prerequisites.Length;
            for (var i = 0; i < prerequisitesLength; i++)
            {
                check[prerequisites[i][0]] = 0;
                if (!dict.ContainsKey(prerequisites[i][0]))
                    dict.Add(prerequisites[i][0], new List<int> { prerequisites[i][1] });
                else
                    dict[prerequisites[i][0]].Add(prerequisites[i][1]);
            }

            //var toCheckValue = new List<int>();
            //for (var i = 0; i < numCourses; i++)
            //{
            //    if (check[i] == 0)
            //        toCheckValue.Add(i);
            //}

            //var toCheckValueCount = toCheckValue.Count;
            for (var i = 0; i < numCourses; i++)
            {
                if (check[i] == 1)
                    continue;
                var inQueue = new int[numCourses];
                var res = CanComplete(check, inQueue, dict, i);
                if (!res)
                    return false;
                check[i] = 1;
                //check[toCheckValue[i]] = 1;
            }

            return true;
        }

        private static bool CanComplete(int[] check, int[] inQueue, Dictionary<int, List<int>> dict, int num)
        {
            if (check[num] == 1 || !dict.ContainsKey(num))
            {
                inQueue[num] = 0;
                check[num] = 1;
                return true;
            }

            var res = true;
            inQueue[num] = 1;

            foreach (var item in dict[num])
            {
                if (inQueue[item] == 1)
                    return false;

                res &= CanComplete(check, inQueue, dict, item);
            }
            inQueue[num] = 0;
            return res;
        }
    }

    public class MinStack
    {
        private class Item
        {
            public int value { get; set; }
            public int? higher { get; set; }
            public int? lower { get; set; }
            public int count { get; set; }
        }

        private int? _min;
        private Stack<int> _stack;
        private Dictionary<int, Item> _dict;

        public MinStack()
        {
            _stack = new Stack<int>();
            _min = null;
            _dict = new Dictionary<int, Item>();
        }

        public void Push(int val)
        {
            if (_min is null)
            {
                _min = val;
                _dict.Add(val, new Item { value = val, lower = null, higher = null, count = 1 });
                _stack.Push(val);

                return;
            }

            if (_dict.ContainsKey(val))
            {
                _dict[val].count++;
                _min = _min > val ? val : _min;
            }
            else
            {
                if (_min > val)
                {
                    _dict.Add(val, new Item { higher = _min, lower = null, value = val, count = 1 });
                    _min = val;
                }
                else if (_min < val)
                {
                    var s = _dict[_min.Value];
                    while (s.higher != null && s.higher < val) s = _dict[s.higher.Value];
                    _dict.Add(val, new Item { value = val, lower = s.value, higher = s.higher, count = 1 });
                    if (s.higher != null)
                    {
                        _dict[s.higher.Value].lower = val;
                        s.higher = val;
                    }
                }
            }

            _stack.Push(val);
        }

        public void Pop()
        {
            var x = _stack.Pop();
            _dict[x].count = _dict[x].count - 1;
            if (_dict[x].count <= 0)
            {
                if (x == _min)
                    _min = _dict[x].higher;
                if (_dict[x].higher != null)
                    _dict[_dict[x].higher.Value].lower = _dict[x].lower;
                if (_dict[x].lower != null)
                    _dict[_dict[x].lower.Value].higher = _dict[x].higher;
                _dict.Remove(x);
            }
        }

        public int Top()
        {
            return _stack.Peek();
        }

        public int GetMin()
        {
            return _min.Value;
        }
    }

    /**
     * Your MinStack object will be instantiated and called as such:
     * MinStack obj = new MinStack();
     * obj.Push(val);
     * obj.Pop();
     * int param_3 = obj.Top();
     * int param_4 = obj.GetMin();
     */
}