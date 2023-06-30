using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LeetCode.Stack
{
    public class _496NextGreaterElement
    {
        public void DoAction()
        {

            //var result = NextGreaterElement(new[] { 4, 1, 2 }, new[] { 1, 3, 4, 2 }); //[-1,3,-1]
            //var result = NextGreaterElement(new[] { 2, 4 }, new[] { 1, 2, 3, 4 }); //[3,-1]
            //var result = NextGreaterElement(new[] { 1, 3, 5, 2, 4 }, new[] { 5, 4, 3, 2, 1 }); //[-1,-1,-1,-1,-1]
            //var result = NextGreaterElement(new[] { 1, 3, 5, 2, 4 }, new[] { 6, 5, 4, 3, 2, 1, 7 }); //[7,7,7,7,7]
            //var result = NextGreaterElement(new[] { 3,1,5,7,9,2,6 }, new[] { 1,2,3,5,6,7,9,11 }); //[5,2,6,9,11,3,7]

            var result = NextGreaterElement(new[] { 137, 59, 92, 122, 52, 131, 79, 236, 94 },
            new[] { 137, 59, 92, 122, 52, 131, 79, 236, 94 }); //[236,92,122,131,131,236,236,-1,-1]

            Console.WriteLine($"[{string.Join(",", result)}]");
        }


        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            var dictionary = new Dictionary<int, int>();
            var stacks = new Stack<int>();

            var length = nums2.Length - 1;
            var index = 0;


            while (index <= length)
            {
                while (stacks.Any() && nums2[index] > stacks.Peek())
                {
                    dictionary[stacks.Pop()] = nums2[index];
                }

                stacks.Push(nums2[index]);
                index++;
            }
            
            var result = new int[nums1.Length];
            for (var i = 0; i < nums1.Length; i++)
            {
                result[i] = dictionary.ContainsKey(nums1[i]) ? dictionary[nums1[i]] : -1;
            }
            return result;
        }
    }
}
