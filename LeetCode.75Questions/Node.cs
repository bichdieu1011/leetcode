using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._75Questions
{
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }

    public class NodeHelper
    {
        public static Node Create(int[][] input)
        {
            var lstNode = new List<Node>();
            for (var i = 0; i < input.Length; i++)
            {
                lstNode.Add(new Node(i + 1, new List<Node>()));
            }

            for (var i = 0; i < input.Length; i++)
            {
                foreach (var j in input[i])

                    lstNode[i].neighbors.Add(lstNode[j - 1]);
            }

            if (lstNode.Count == 0)
                return null;
            return lstNode[0];
        }
    }
}
