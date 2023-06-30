using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var result = DiameterOfBinaryTree(tree);
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

        static int DiameterOfBinaryTree(TreeNode root)
        {
            if (root == null)
                return 0;

            var leftDepth = MaxDepth(root.left);
            var righttDepth = MaxDepth(root.right);
            var mL = DiameterOfBinaryTree(root.left);
            var mR = DiameterOfBinaryTree(root.right);

            return Math.Max(leftDepth + righttDepth, Math.Max(mL, mR));

        }
    }
}
