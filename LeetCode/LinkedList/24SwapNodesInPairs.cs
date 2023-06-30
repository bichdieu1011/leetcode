using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LinkedList
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class _24SwapNodesInPairs
    {
        public ListNode SwapPairs(ListNode head)
        {
            head = new ListNode(0){ next = head };
             //var firstTime = true;
             //var tempNode = new ListNode() { val = 0, next = head};
            var current = head;
            while (current.next != null && current.next.next != null)
            {
                //var A = current.next;
                var B = current.next.next;
                //var C = B.next;

                current.next.next = current.next.next.next;
                B.next = current.next;
                
                current.next = B;
                current = current.next.next;
            }

            return head.next;
        }

        public void DoAction()
        {

            var data = new[] { 1, 2, 3, 4 };
            ListNode listNode = null;
            ListNode point = null;
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
            }

            var result = SwapPairs(listNode);
           

            while(result != null)
            {
                Console.Write(result.val +",");
                result = result.next;
            }
        }
    }

    
}
