using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._75Questions.Week5
{
    public class _236_Lowest_Common_Ancestor_of_a_Binary_Tree
    {
        public static void Test()
        {
            var input = new int?[] { 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4 };
            var tree = CreateTreeNode(input, 0);
            //var result = LowestCommonAncestor_Recursive(tree, new TreeNode(5), new TreeNode(1)); //3
            var result = LowestCommonAncestor(tree, new TreeNode(5), new TreeNode(2)); //5

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

        static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            var searchVal = new int[] { p.val, q.val };
            var foundCount = 0;
            var stack = new Stack<(TreeNode node, bool traveled)>();
            stack.Push((root, false));
            var ancestors = new Dictionary<TreeNode, TreeNode>();
            var tree = new Dictionary<TreeNode, List<TreeNode>>();
            while (foundCount < searchVal.Length)
            {
                var node = stack.Pop();
                if (node.traveled)
                {
                    if (searchVal.Contains(node.node.val))
                    {
                        foundCount++;
                        var nodeToCheck = node.node;
                        while (ancestors.ContainsKey(nodeToCheck))
                        {
                            if (tree.ContainsKey(ancestors[nodeToCheck]))
                            {
                                if(!tree[ancestors[nodeToCheck]].Contains(nodeToCheck))
                                    tree[ancestors[nodeToCheck]].Add(nodeToCheck);
                            }
                                
                            else tree.Add(ancestors[nodeToCheck], new List<TreeNode> { nodeToCheck });

                            nodeToCheck = ancestors[nodeToCheck];
                        }
                    }
                }
                else
                {
                    stack.Push((node.node, true));
                    if (node.node.left != null)
                    {
                        stack.Push((node.node.left, false));
                        ancestors.Add(node.node.left, node.node);
                    }
                    if (node.node.right != null)
                    {
                        stack.Push((node.node.right, false));
                        ancestors.Add(node.node.right, node.node);
                    }
                }
            }
            //var result = root;
            while (tree.ContainsKey(root) && tree[root].Count == 1 && !searchVal.Contains(root.val))
            {                
                root = tree[root].FirstOrDefault();
            }
            return root;
        }

        static TreeNode LowestCommonAncestor_Recursive(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return root;

            if(root.val == q.val || root.val == p.val) return root;

            var left = LowestCommonAncestor_Recursive(root.left, p, q);
            var right  = LowestCommonAncestor_Recursive(root.right, p, q);

            if (left != null && right != null) return root;

            if (right == null && left != null) return left;
            if (left == null && right != null) return right;

            return null;
        }

        //static TreeNode HasNode(TreeNode root, TreeNode p, TreeNode q) { }

    }
}
