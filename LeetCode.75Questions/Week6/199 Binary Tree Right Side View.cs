using Newtonsoft.Json;

namespace LeetCode._75Questions.Week6
{
    public class _199_Binary_Tree_Right_Side_View
    {
        public static void Test()
        {
            //var input = new int?[] { 1, 2, 3, null, 5, null, 4 };//[1,3,4]
            //var input = new int?[] {1,null,3};//[1,3]
            //var input = new int?[] {1,3};//[1,3]
            var input = new int?[] { };//[]
            
            var tree = CreateTreeNode(input, 0);
            var result = RightSideView(tree);
            Console.WriteLine(JsonConvert.SerializeObject(result));
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

        private static IList<int> RightSideView(TreeNode root)
        {
            var res = new List<int>();
            if (root == null) return res;
            var nodes = new List<TreeNode>() { root };
            var level = 0;

            while (nodes.Any())
            {
                res.Add(nodes[nodes.Count - 1].val);
                var childs = new List<TreeNode>();
                for(var i = 0; i < nodes.Count; i++)
                {
                    if(nodes[i].left != null)
                        childs.Add(nodes[i].left);
                    if (nodes[i].right != null)
                        childs.Add(nodes[i].right);
                }

                nodes = childs;
                level++;
            }
            
            return res;
        }
    }
}