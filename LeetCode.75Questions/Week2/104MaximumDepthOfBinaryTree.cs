namespace LeetCode._75Questions.Week2
{
    public class _104MaximumDepthOfBinaryTree
    {
        public static void Test()
        {
            //var nums = new int?[] { 3, 9, 20, null, null, 15, 7 };//3
            var nums = new int?[] { 1, null, 2 };//2
            var tree = new TreeNode(0, null, null);
            tree = CreateTreeNode(nums, 0);
            var result = MaxDepth(tree);
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

        private static int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            var checkLeft = root.left != null ? MaxDepth(root.left) : 0;
            var checkRight = root.right != null ? MaxDepth(root.right) : 0;
            return checkLeft > checkRight ? checkLeft + 1 : checkRight + 1;
        }

        private static int GetDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            var checkLeft = root.left != null ? MaxDepth(root.left) + 1 : 0;
            var checkRight = root.right != null ? MaxDepth(root.right) + 1 : 0;

            return checkLeft > checkRight ? checkLeft : checkRight;
        }
    }
}