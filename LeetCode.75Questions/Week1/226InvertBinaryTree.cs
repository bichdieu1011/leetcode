using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._75Questions.Week1
{
    public class _226InvertBinaryTree
    {
        public static void Test()
        {
            var nums = new[] { 4, 2, 7, 1, 3, 6, 9 };
            var tree = new TreeNode(0, null, null);
            tree = CreateTreeNode(nums, 0);
            var result = InvertTree(tree);


        }

        static TreeNode CreateTreeNode(int[] nums, int index)
        {
            if (index > nums.Length - 1)
            {
                return null;
            }

            if (index == 0) // root
            {
                //level++;
                var tree = new TreeNode(nums[0], null, null);
                tree.left = CreateTreeNode(nums, index * 2 + 1);
                tree.right = CreateTreeNode(nums, index * 2 + 2);
                return tree;
            }
            else
            {
                //level++;
                var tree = new TreeNode(nums[index], null, null);
                tree.left = CreateTreeNode(nums, index * 2 + 1);
                tree.right = CreateTreeNode(nums, index * 2 + 2);
                return tree;
            }
        }

        public static TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return root;
            }
            var temp = root.left;
            root.left = InvertNode(root.right);
            root.right = InvertNode(temp);
            return root;
        }

        public static TreeNode InvertNode(TreeNode tree)
        {
            if (tree == null)
            {
                return tree;
            }

            tree.left = InvertNode(tree.right); 
            tree.right = InvertNode(tree.left);
            return tree;
        }
    }
}
