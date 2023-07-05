namespace LeetCode._75Questions.Week3
{
    public class _124BinaryTreeMaximumPathSum
    {
        public static void Test()
        {
            var nums = new int?[] { 1, 2, 3 };//6
            //var nums = new int?[] { -10, 9, 20, null, null, 15, 7 };//42
            //var nums = new int?[] { -3 };//-3
            //var nums = new int?[] { -2, 1 };//-1
            //var nums = new int?[] { 2, -1, -2 };//2
            //var nums = new int?[] { -1, null, 9, null, null, -6, 3, null, null, null, null, null, null, null, -2 };//12

            var tree = new TreeNode(0, null, null);
            tree = CreateTreeNode(nums, 0);
            var result = MaxPathSum(tree);
            Console.WriteLine(result);
        }

        private static TreeNode CreateTreeNode(int?[] nums, int index)
        {
            if (index > nums.Length - 1 || nums[index] == null)
            {
                return null;
            }

            if (index == 0) // root
            {
                //level++;
                var tree = new TreeNode(nums[0].Value, null, null);
                tree.left = CreateTreeNode(nums, index * 2 + 1);
                tree.right = CreateTreeNode(nums, index * 2 + 2);
                return tree;
            }
            else
            {
                //level++;
                var tree = new TreeNode(nums[index].Value, null, null);
                tree.left = CreateTreeNode(nums, index * 2 + 1);
                tree.right = CreateTreeNode(nums, index * 2 + 2);
                return tree;
            }
        }

        private static int MaxPathSum(TreeNode root)
        {
            int max = int.MinValue;
            var res = MaxPathSum(root, ref max);

            return max > res ? max : res;
        }

        private static int MaxPathSum(TreeNode root, ref int max)
        {
            if (root == null)
                return 0;

            if (root.left == null && root.right == null)
            {
                max = max > root.val ? max : root.val;
                return root.val;
            }

            var maxLeft = MaxPathSum(root.left, ref max);
            var maxRight = MaxPathSum(root.right, ref max);

            var res = Math.Max(maxLeft + root.val, Math.Max(root.val, maxRight + root.val));
            max = Math.Max(max, Math.Max(maxLeft + maxRight + root.val, res));
            return res;
        }

        private static int MaxPathSum_iterator(TreeNode root)
        {
            var stacks = new Stack<TreeNode>();
            var weight = new Dictionary<TreeNode, int>();
            stacks.Push(root);

            int max = -1001;

            while (stacks.Count > 0)
            {
                var node = stacks.Pop();
                if (weight.ContainsKey(node))
                {
                    int maxLeft = -1001;
                    int maxRight = -1001;
                    if (node.left != null)
                        maxLeft = weight[node.left];
                    if (node.right != null)
                        maxRight = weight[node.right];

                    var maxNode = Math.Max(node.val + maxLeft, Math.Max(node.val + maxRight, node.val));
                    max = Math.Max(max, Math.Max(maxNode, node.val + maxLeft + maxRight));
                    weight[node] = maxNode;
                }
                else
                {
                    stacks.Push(node);
                    weight.Add(node, 0);

                    if (node.left != null)
                        stacks.Push(node.left);

                    if (node.right != null)
                        stacks.Push(node.right);
                }
            }

            return max;
        }
    }
}