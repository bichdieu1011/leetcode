using LeetCode._75Questions.Week1;

namespace LeetCode._75Questions.Week2
{
    public class _206ReverseLinkedList
    {
        public static void Test()
        {
            var list = CreateListNode(new[] { 1, 2, 3, 4, 5 });
            //var result = ReverseList(list);
            //ListNode head = null;
            var result = ReverseList( list);

            while (result != null)
            {
                Console.Write(result.val + ",");
                result = result.next;
            }
        }

        private static ListNode CreateListNode(int[] nums)
        {
            ListNode listNode = null;
            ListNode point = null;
            for (var i = 0; i < nums.Length; i++)
            {
                var newNode = new ListNode();
                newNode.val = nums[i];
                if (listNode == null)
                {
                    listNode = newNode;
                    point = newNode;
                }
                else
                {
                    point.next = newNode;
                    point = newNode;
                }
            }
            return listNode;
        }



        private static ListNode ReverseList(ListNode recursively)
        {
            if (recursively == null || recursively.next == null)
                return recursively;

            var stacks = new Stack<ListNode>();
            while (recursively != null)
            {
                stacks.Push(recursively);
                recursively = recursively.next;
            }
            recursively = stacks.Peek();
            while(stacks.Count > 1)
            {
                stacks.Pop().next = stacks.Peek();
            }
            stacks.Peek().next = null;
            return recursively;
        }
    }
}