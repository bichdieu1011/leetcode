using Newtonsoft.Json;

namespace LeetCode._75Questions.Week5
{
    public class _39_Combination_Sum
    {
        public static void Test()
        {
            //var input = new { candidate = new[] { 2, 3, 6, 7 }, target = 7 };
            var input = new { candidate = new[] { 2, 3, 5 }, target = 8 };
            //var input = new { candidate = new[] { 7, 3, 2 }, target = 18 };
            //var input = new { candidate = new[] { 2 }, target = 1 };

            var result = CombinationSum(input.candidate, input.target);
            Console.WriteLine($"{JsonConvert.SerializeObject(input)}: {JsonConvert.SerializeObject(result)}");
        }

        private static IList<IList<int>> _res;

        private static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            _res = new List<IList<int>>();           

            for (var i = 0; i < candidates.Length; i++)
            {
                var temp = new List<int>() { candidates[i] };
                if (target == candidates[i])
                {
                    _res.Add(temp);
                    continue;
                }
                pickCandidate(candidates, i, target - candidates[i], temp);
            }

            return _res;
        }

        private static void pickCandidate(int[] candidates, int start, int target, IList<int> potentials)
        {
            if (target < 0) return;

            for (var i = start; i < candidates.Length; i++)
            {
                var sol = new List<int>(potentials);
                sol.Add(candidates[i]);
                if (target == candidates[i])
                {
                    _res.Add(sol);
                    continue;
                }
                pickCandidate(candidates, i, target - candidates[i], sol);
            }
        }
    }
}