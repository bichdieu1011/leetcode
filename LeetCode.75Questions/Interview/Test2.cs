using Newtonsoft.Json;

namespace LeetCode._75Questions.Interview
{
    public class Test2
    {
        public static void Test()
        {
            //var res = ShortestToChar("loveleetcode", 'e');
            //var res = ShortestToChar("bbba", 'b');
            //Console.WriteLine($"{String.Join(",", res)}");

            //var matrix = JsonConvert.DeserializeObject<int[][]>("[[-48]]");
            //var matrix = JsonConvert.DeserializeObject<int[][]>("[[17,82],[1,-44]]");
            var matrix = JsonConvert.DeserializeObject<int[][]>("[[-19,-1,-96,48,-94,36,16,55,-42,37,-59,6,-32,96,95,-58,13,-34,94,85],[17,44,36,-29,84,80,-34,50,-99,64,13,91,-27,25,-36,57,20,98,-100,-72],[-92,-75,86,90,-4,90,64,56,50,-63,10,-15,90,-66,-66,32,-69,-78,1,60],[21,51,-47,-43,-14,99,44,90,8,11,99,-62,57,59,69,50,-69,32,85,13],[-28,90,12,-18,23,61,-55,-97,6,89,36,26,26,-1,46,-50,79,-45,89,86],[-85,-10,49,-10,2,62,41,92,-67,85,86,27,89,-50,77,55,22,-82,-94,-98],[-50,53,-23,55,25,-22,76,-93,-7,66,-75,42,-35,-96,-5,4,-92,13,-31,-100],[-62,-78,8,-92,86,69,90,-37,81,97,53,-45,34,19,-19,-39,-88,-75,-74,-4],[29,53,-91,65,-92,11,49,26,90,-31,17,-84,12,63,-60,-48,40,-49,-48,88],[100,-69,80,11,-93,17,28,-94,52,64,-86,30,-9,-53,-8,-68,-33,31,-5,11],[9,64,-31,63,-84,-15,-30,-10,67,2,98,73,-77,-37,-96,47,-97,78,-62,-17],[-88,-38,-22,-90,54,42,-29,67,-85,-90,-29,81,52,35,13,61,-18,-94,61,-62],[-23,-29,-76,-30,-65,23,31,-98,-9,11,75,-1,-84,-90,73,58,72,-48,30,-81],[66,-33,91,-6,-94,82,25,-43,-93,-25,-69,10,-71,-65,85,28,-52,76,25,90],[-3,78,36,-92,-52,-44,-66,-53,-55,76,-7,76,-73,13,-98,86,-99,-22,61,100],[-97,65,2,-93,56,-78,22,56,35,-24,-95,-13,83,-34,-51,-73,2,7,-86,-19],[32,94,-14,-13,-6,-55,-21,29,-21,16,67,100,77,-26,-96,22,-5,-53,-92,-36],[60,93,-79,76,-91,43,-95,-16,74,-21,85,43,21,-68,-32,-18,18,100,-43,1],[87,-31,26,53,26,51,-61,92,-65,17,-41,27,-42,-14,37,-46,46,-31,-74,23],[-67,-14,-20,-85,42,36,56,9,11,-66,-59,-55,5,64,-29,77,47,44,-33,-77]]");
            //var matrix = JsonConvert.DeserializeObject<int[][]>("[[2,1,3],[6,5,4],[7,8,9]]");
            //var matrix = JsonConvert.DeserializeObject<int[][]>("[[-19,57],[-40,-5]]");
            //Console.WriteLine(MinFallingPathSum(matrix));

            var arr = new[] { 1, 2, 3, 0,4,5,0,3,2 };
            for (var i = 0; i < arr.Length -1; i++)
            {
                if (arr[i] == 0)
                {
                    for (var j = arr.Length - 1; j > i; j--)
                        arr[j] = arr[j - 1];
                    i++;
                }
            }
            Console.WriteLine($"{String.Join(",", arr)}");

        }

        private static int[] ShortestToChar(string s, char c)
        {
            var res = new int[s.Length];
            var occurs = new List<int>();

            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == c)
                {
                    res[i] = 0;
                    occurs.Add(i);
                }
            }

            var index = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == c) continue;
                while (index < occurs.Count - 1 && Math.Abs(occurs[index] - i) >= Math.Abs(occurs[index + 1] - i))
                    index++;

                res[i] = Math.Abs(occurs[index] - i);
            }
            return res;
        }

        private static int MinFallingPathSum(int[][] matrix)
        {
            for (int i = 1; i < matrix.Length; ++i)
                for (int j = 0; j < matrix.Length; ++j)
                    matrix[i][j] += Math.Min(matrix[i - 1][j], Math.Min(matrix[i - 1][Math.Max(0, j - 1)], matrix[i - 1][Math.Min(matrix.Length - 1, j + 1)]));

            var min = int.MaxValue;
            for (var i = 0; i < matrix.Length; i++)
                min = matrix[matrix.Length - 1][i] > min ? min : matrix[matrix.Length - 1][i];
            return min;
        }

    }
}