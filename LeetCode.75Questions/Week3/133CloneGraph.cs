namespace LeetCode._75Questions.Week3
{
    public class _133CloneGraph
    {
        public static void Test()
        {
            var input = new int[][] { new[] { 2, 4 }, new[] { 1, 3 }, new[] { 2, 4 }, new[] { 1, 3 } };
            var node = NodeHelper.Create(input);
            var output = CloneGraph(node);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(node));
        }

        private static Node CloneGraph(Node node)
        {
            if (node == null)
                return null;

            var newNode = new Node(node.val, new List<Node>());
            var queue = new Queue<Node>();
            var originalQueue = new Queue<Node>();

            queue.Enqueue(newNode);
            originalQueue.Enqueue(node);
            var nodes = new Dictionary<int, Node>();

            while (queue.Count > 0)
            {
                var cloneNode = queue.Dequeue();
                var originalNode = originalQueue.Dequeue();
                foreach (var neighbor in originalNode.neighbors)
                {
                    var hasNeighbour = false;
                    foreach (var neighbor2 in cloneNode.neighbors)
                    {
                        if (neighbor.val == neighbor2.val)
                        {
                            hasNeighbour = true;
                            break;
                        }
                    }

                    if (!hasNeighbour)
                    {
                        Node newNeighbour = null;
                        if (nodes.ContainsKey(neighbor.val))
                            newNeighbour = nodes[neighbor.val];
                        else
                        {
                            newNeighbour = new Node(neighbor.val, new List<Node>() { cloneNode });
                            nodes.Add(neighbor.val, newNeighbour);
                            
                            queue.Enqueue(newNeighbour);
                            originalQueue.Enqueue(neighbor);
                        }

                        cloneNode.neighbors.Add(newNeighbour);
                    }
                }
            }

            return newNode;
        }
    }
}