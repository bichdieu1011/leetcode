namespace LeetCode._75Questions.Week1
{
    public class _733FloodFill
    {
        public static void Test()
        {
            var input = new int[][] { new[] { 1, 1, 1 }, new[] { 1, 1, 0 }, new[] { 1, 0, 1 } };
            var result = FloodFill(input, 1, 1, 2); //[[2,2,2],[2,2,0],[2,0,1]]

            foreach (var input2 in result)
            {
                Console.WriteLine($"[{string.Join(",", input2)}]");
            }

        }

        public static int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            if (image[sr][sc] == color) return image;
            return FloodFill(image, sr, sc, color, image[sr][sc]);
        }

        public static int[][] FloodFill(int[][] image, int sr, int sc, int color, int originColor)
        {

            if (sr < 0 || sr > image.Length)
                return image;
            if (sc < 0 || sc > image[sr].Length)
                return image;

            if (image[sr][sc] == color) return image;
            image[sr][sc] = color;

            if (sr - 1 >= 0 && image[sr - 1][sc] == originColor)
                image = FloodFill(image, sr - 1, sc, color, originColor);

            if (sc - 1 >= 0 && image[sr][sc - 1] == originColor)
                image = FloodFill(image, sr, sc - 1, color, originColor);

            if (sr + 1 < image.Length && image[sr + 1][sc] == originColor)
                image = FloodFill(image, sr + 1, sc, color, originColor);

            if (sc + 1 < image[sr].Length && image[sr][sc + 1] == originColor)
                image = FloodFill(image, sr, sc + 1, color, originColor);

            return image;
        }
    }
}