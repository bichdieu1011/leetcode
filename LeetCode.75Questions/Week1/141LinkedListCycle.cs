namespace LeetCode._75Questions.Week1
{
    public class _141LinkedListCycle
    {
        public static void Test()
        {
            //var data = new[] { 1, 2, 3, 4 };
            var data = new[] { 1, 1,1,1 };
            int post = 1;

            ListNode listNode = null;
            ListNode point = null;
            ListNode pos = null;
            for (var i = 0; i < data.Length; i++)
            {
                var newNode = new ListNode();
                newNode.val = data[i];
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
                if (post == i)
                {
                    pos = newNode;
                }
            }

            point.next = pos;

            var result = HasCycle(listNode);
            Console.WriteLine(result);
        }

        public static bool HasCycle(ListNode head)
        {
            if(head == null) return false;
            var _1step = head;
            var _2step = head.next;
            while (_2step != null && _2step.next != null)
            {
                if (_1step == _2step)
                    return true;
                _1step = _1step.next;
                _2step = _2step.next.next;
            }
            return false;
        }
    }
}