using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._75Questions.Week1
{
    public class _235LowestCommonAncestorOfABinarySearchTree
    {
        public static void Test()
        {
            var input = new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 };
            var tree = CreateTreeNode(input, 0);
            var result = LowestCommonAncestor(tree, new TreeNode(2), new TreeNode(8)); //2

            Console.WriteLine(result.val);
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


        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root.val > p.val && root.val > q.val)
            {
                root = LowestCommonAncestor(root.left, p, q);
            }

            if (root.val < p.val && root.val < q.val)
            {
                root = LowestCommonAncestor(root.right, p, q);
            }

            return root;
        }
    }
}
