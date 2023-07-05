namespace LeetCode._75Questions.Week2
{
    public class _543DiameterOfBinaryTree
    {
        public static void Test()
        {
            //var nums = new int?[] { 1, 2, 3, 4, 5 };//3
            var nums = new int?[] { 1, 2 };//1

            var tree = new TreeNode(0, null, null);
            tree = CreateTreeNode(nums, 0);
            var result = DiameterOfBinaryTree_travel(tree);
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

            /* //the same
              var max = 0;
            while (root != null) {
                var leftDepth = MaxDepth(root.left);
                var righttDepth = MaxDepth(root.right);
                max = max > leftDepth + righttDepth ? max : leftDepth + righttDepth;
                root = leftDepth > righttDepth ? root.left : root.right;
            }
            return max;

             */
        }

        private static int DiameterOfBinaryTree(TreeNode root)
        {
            if (root == null)
                return 0;

            var leftDepth = MaxDepth(root.left);
            var righttDepth = MaxDepth(root.right);
            var mL = DiameterOfBinaryTree(root.left);
            var mR = DiameterOfBinaryTree(root.right);

            return Math.Max(leftDepth + righttDepth, Math.Max(mL, mR));
        }

        private static int DiameterOfBinaryTree_travel(TreeNode root)
        {
            if (root == null)
                return 0;

            var nodes = new Stack<KeyValuePair<TreeNode, bool>>();
            var max = 0;

            nodes.Push(new KeyValuePair<TreeNode, bool>(root, false));
            var dict = new Dictionary<TreeNode, int>();

            while (nodes.Count > 0)
            {
                var node = nodes.Pop();
                if (node.Value)
                {
                    var lh = 0;
                    var rh = 0;
                    if (node.Key.left != null)
                        lh = dict[node.Key.left];
                    if (node.Key.right != null)
                        if (node.Key.right != null)
                            rh = dict[node.Key.right];

                    max = max > lh + rh ? max : lh + rh;
                    dict.Add(node.Key, rh + 1 > lh + 1 ? rh + 1 : lh + 1);
                }
                else
                {
                    nodes.Push(new KeyValuePair<TreeNode, bool>(node.Key, true));
                    if (node.Key.left != null) nodes.Push(new KeyValuePair<TreeNode, bool>(node.Key.left, false));
                    if (node.Key.right != null) nodes.Push(new KeyValuePair<TreeNode, bool>(node.Key.right, false));
                }
            }

            return max;
        }
    }
}