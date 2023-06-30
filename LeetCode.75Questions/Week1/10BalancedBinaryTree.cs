using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._75Questions.Week1
{
    public class _10BalancedBinaryTree
    {
        public static void Test()
        {
            //var nums = new int?[] { 3, 9, 20, null, null, 15, 7 };//true
            //var nums = new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 };//false
            //var nums = new int?[] {  };//false
            //var nums = new int?[] { 1, null, 3, null, null, 2 };//false
            var nums = new int?[] { 1, 2, 2, 3, null, null, 3, 4, null, null, null, null, null, null, 4 };//false

            var tree = new TreeNode(0, null, null);
            tree = CreateTreeNode(nums, 0);
            var result = IsBalanced(tree);
            Console.WriteLine(result);

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

        public static bool IsBalanced(TreeNode root)
        {
            if (root is null)
                return true;

            var over = false;

            var leftLevel = root.left != null ? Calculate(root.left, ref over) + 1 : 0;
            var rightLevel = root.right != null ? Calculate(root.right, ref over) + 1 : 0;
            return  !((rightLevel > leftLevel ? rightLevel - leftLevel : leftLevel - rightLevel) >= 2 || over);



            //var min = int.MaxValue;
            //var max = 0;
            //foreach (var level in levels)
            //{
            //    min = min > level ? level : min;

            //    max = max < level ? level : max;
            //    if (max - min > 1)
            //        return false;
            //}
            //return true;
        }

        static int Calculate(TreeNode node, ref bool overs)
        {
            if (node == null)
                return 0;

            if (node.left != null || node.right != null)
            {
                var right = node.right != null ? Calculate(node.right, ref overs) + 1 : 0;
                var left = node.left != null ? Calculate(node.left, ref overs) + 1 : 0;
                var level = right > left ? right - left : left - right ;
                if (level >= 2)
                    overs = true;

                return right > left ? right : left;
            }            
            return 0;
        }
    }
}
