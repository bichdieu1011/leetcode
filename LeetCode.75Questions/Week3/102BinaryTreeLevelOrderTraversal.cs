namespace LeetCode._75Questions.Week3
{
    public class _102BinaryTreeLevelOrderTraversal
    {
        public static void Test()
        {
            var nums = new int?[] { 3, 9, 20, null, null, 15, 7 };// [[3],[9,20],[15,7]]
            //var nums = new int?[] { 1 };// [[1]]
            //var nums = new int?[] { };// [[]]

            var tree = new TreeNode(0, null, null);
            tree = CreateTreeNode(nums, 0);
            var result = LevelOrder(tree);
            Console.WriteLine("[" + string.Join(',', result.Select(s => "[" + string.Join(",", s) + "]")) + "]");
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

        private static IList<IList<int>> LevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();

            if (root == null)
                return result;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            short countInLevel = 1;
            short level = 1;
            short queueCount = 1;

            while (queueCount > 0)
            {
                countInLevel--;
                queueCount--;
                var node = queue.Dequeue();
                if (result.Count < level)
                    result.Add(new List<int>() { node.val });
                else result[level - 1].Add(node.val);

                if (node.left != null)
                {
                    queueCount++;
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queueCount++;
                    queue.Enqueue(node.right);
                }

                if (countInLevel == 0)
                {
                    countInLevel = queueCount;
                    level++;
                }
            }

            return result;
        }

        private static void LevelOrder(TreeNode root, int level, List<IList<int>> keyValuePairs)
        {
            if (root == null)
                return;

            if (keyValuePairs.Count >= level)
                keyValuePairs[level - 1].Add(root.val);
            else keyValuePairs.Add(new List<int>() { root.val });

            LevelOrder(root.left, level + 1, keyValuePairs);
            LevelOrder(root.right, level + 1, keyValuePairs);
        }
    }
}