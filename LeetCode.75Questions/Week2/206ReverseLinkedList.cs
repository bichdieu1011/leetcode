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
            var result = ReverseList_Recursively( list);

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

        private static ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode prev = null;
            while (head != null)
            {
                var temp = head.next;
                head.next = prev;
                prev = head;
                head = temp;
            }

            return prev;
        }

        private static ListNode ReverseList_Recursively(ListNode recursively)
        {
            if (recursively.next == null || recursively.next == null)
            {
                //head = recursively;
                return recursively;
            }

            ListNode prev = ReverseList_Recursively(recursively.next);
            var temp = prev;
            recursively.next = null;
            while (prev.next != null) {
                prev = prev.next;
            }
            prev.next = recursively;

            return temp;
        }
    }
}