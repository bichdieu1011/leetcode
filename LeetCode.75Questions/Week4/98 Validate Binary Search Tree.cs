namespace LeetCode._75Questions.Week4
{
    public class _98_Validate_Binary_Search_Tree
    {
        public static void Test()
        {
            //var s = new int?[] { 1, 2, 3, 4 };//false
            var s = new int?[] { 32, 26, 47, 19, null, null, 56, null, 27 };
            var tree = CreateTreeNode(s, 0);
            var res = IsValidBST(tree);
            Console.WriteLine(res);
        }

        public static TreeNode CreateTreeNode(int?[] nums, int index)
        {
            if (index > nums.Length - 1 || nums[index] == null)
            {
                return null;
            }

            if (index == 0) // root
            {
                //level++;
                var tree = new TreeNode(nums[0].Value);
                tree.left = CreateTreeNode(nums, index * 2 + 1);
                tree.right = CreateTreeNode(nums, index * 2 + 2);
                return tree;
            }
            else
            {
                //level++;
                var tree = new TreeNode(nums[index].Value);
                tree.left = CreateTreeNode(nums, index * 2 + 1);
                tree.right = CreateTreeNode(nums, index * 2 + 2);
                return tree;
            }
        }

        private static bool IsValidBST(TreeNode root)
        {
            var stacks = new Stack<TreeNode>();
            var listVal = new List<int>();

            while (root != null || stacks.Count > 0)
            {
                while (root != null)
                {
                    stacks.Push(root);
                    root = root.left;
                }

                root = stacks.Pop();
                listVal.Add(root.val);
                root = root.right;
            }

            for (var i = 0; i < listVal.Count - 1; i++)
            {
                if (listVal[i] >= listVal[i + 1])
                    return false;
            }


            return true;
        }

    }
}