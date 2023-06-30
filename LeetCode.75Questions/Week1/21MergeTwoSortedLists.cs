using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._75Questions.Week1
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


    public class _21MergeTwoSortedLists
    {

        static ListNode CreateListNode(int[] nums)
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

        public static void Test()
        {

            var list1 = CreateListNode(new[] { 1, 2, 4 });
            var list2 = CreateListNode(new[] { 1, 3, 5 });

            var result1 = MergeTwoLists(list1, list2);

            while (result1 != null)
            {
                Console.Write(result1.val + ",");
                result1 = result1.next;
            }
        }

        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            var result = new ListNode();
            var point = result;
            var point2 = list2;
            while (list1 != null || list2 != null)
            {
                if (list1 != null && list2 != null)
                {
                    if (list1.val < list2.val)
                    {
                        point.next = list1;
                        list1 = list1.next;
                    }
                    else
                    {
                        point.next = list2;
                        list2 = list2.next;
                    }
                }
                else
                {
                    point.next = list1 != null ? list1 : list2;
                    list1 = list1 != null ? list1.next : null;
                    list2 = list2 != null ? list2.next : null;
                }

                point = point.next;
            }
            return result.next;
        }
    }
}
