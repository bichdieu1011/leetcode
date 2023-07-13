using Newtonsoft.Json;

namespace LeetCode._75Questions.Week5
{
    public class _39_Combination_Sum
    {
        public static void Test()
        {
            //var input = new { candidate = new[] { 2, 3, 6, 7 }, target = 7 };
            //var input = new { candidate = new[] { 2, 3, 5 }, target = 8 };
            var input = new { candidate = new[] { 7, 3, 2 }, target = 18 };
            //var input = new { candidate = new[] { 2 }, target = 1 };

            var result = CombinationSum(input.candidate, input.target);
            Console.WriteLine($"{JsonConvert.SerializeObject(input)}: {JsonConvert.SerializeObject(result)}");
        }
        static IList<IList<int>> _res;
        private static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            _res = new List<IList<int>>();
            candidates = candidates.OrderBy(x => x).ToArray();

            for (var i = 0; i < candidates.Length; i++)
            {
                var tar = target - candidates[i];
                if (tar == 0) _res.Add(new List<int>() { candidates[i] });
                for (var j = i; j < candidates.Length; j++)
                {
                    var temp = new List<int>() { candidates[i], candidates[j] };
                    if (pickCandidate(candidates, tar - candidates[j], j, temp))
                    {
                        //_res.Add(temp);
                    }

                }
            }

            return _res;
        }

        private static List<IList<int>> pickCandidate(int[] candidates, int target, int start)
        {
            var res = new List<IList<int>>();
            for (var i = start; i < candidates.Length; i++)
            {
                var temp = new List<int>() { candidates[start] };
                if (target < candidates[i])
                    continue;

                if (pickCandidate(candidates, target - candidates[i], start, temp))
                {
                    temp.Add(candidates[i]);
                    res.Add(temp);
                }

            }
            return res;
        }
        static bool pickCandidate(int[] candidates, int target, int start, IList<int> potentials)
        {
            if (target <= 0)
                return target == 0;

            for (var i = start; i < candidates.Length; i++)
            {
                if (target < candidates[i])
                    continue;

                if (pickCandidate(candidates, target - candidates[i], start, potentials))
                {
                    potentials.Add(candidates[i]);
                    _res.Add(potentials);
                }

            }
            return false;
        }

    }
}