using Newtonsoft.Json;

namespace LeetCode._75Questions.Week5
{
    public class _46_Permutations
    {
        public static void Test()
        {
            var res = Permute(new[] { 1, 2, 3 });
            //var res = Permute(new[] { 5, 4, 6, 2 });
            Console.WriteLine(JsonConvert.SerializeObject(res));
        }

        private static IList<IList<int>> Permute(int[] nums)
        {
            var res = Permute(nums.ToList());

            return res;
        }

        static List<IList<int>> Permute(List<int> nums)
        {

            if (nums.Count == 2)
            {
                return new List<IList<int>>
                {
                    new List<int> { nums[0], nums[1] },
                    new List<int> { nums[1], nums[0] }
                };
            }

            if (nums.Count > 2)
            {
                var res = new List<IList<int>>();
                for (var i = 0; i < nums.Count; i++)
                {
                    var list = new List<int>(nums);
                    list.RemoveAt(i);
                    var listPermuteWithoutI = Permute(list);

                    foreach (var item in listPermuteWithoutI)
                    {
                        item.Add(nums[i]);                        
                    }
                    res.AddRange(listPermuteWithoutI);
                }

                return res;
            }

            return new List<IList<int>>() { nums };
        }

        private static int factorial(int x)
        {
            if (x == 1) return 1;
            return x * factorial(x - 1);
        }
    }
}