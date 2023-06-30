using LeetCode._75Questions.Week1;

namespace LeetCode._75Questions.Week2
{
    public class _876MiddleOfTheLinkedList
    {
        public static void Test()
        {
            var list = CreateListNode(new[] { 1, 2, 3, 4, 5 });
            var result = MiddleNode(list);

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

         static ListNode MiddleNode(ListNode head)
        {
            var stacks = new List<ListNode>();
            while (head != null)
            {
                stacks.Add(head);
                head = head.next;
            }
            return stacks[stacks.Count/2];
        }

        static ListNode MiddleNode_2(ListNode head)
        {
            var _1step = head;
            var _2step = head.next.next;
            while (_2step != null && _2step.next != null &&  _2step.next.next != null)
            {
                _2step = _2step.next.next;
                _1step = _1step.next;
            }
            return _1step;
        }
    }
}