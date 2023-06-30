using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Stack
{
    public class _1425ConstrainedSubsequenceSum
    {
        public int ConstrainedSubsetSum(int[] nums, int k)
        {
            var que = new Queue<int>();
            bool hasItem = false;
            var temp = new Stack<int>();
            var result = new Stack<int>();
            var length = nums.Length;
            var maxItem = nums[0];
            for (var i = 0; i < length; i++)
            {
                maxItem = maxItem > nums[i] ? maxItem : nums[i];

                if (nums[i] >= 0)
                {
                    result.Push(nums[i]);
                    hasItem = true;
                    temp.Clear();
                    continue;
                }

                if (nums[i] < 0 && hasItem)
                {
                    temp.Push(nums[i]);
                }


                if (temp.Any() && temp.Count() >= k -1 )
                {
                    var maxValue = temp.Pop();
                    var temporary = new Stack<int>();
                    temporary.Push(nums[i]);
                    while (temp.Any())
                    {
                        maxValue = maxValue < temp.Peek() ? temp.Peek() : maxValue;
                        temporary.Push(temp.Pop());
                    }

                    while (temporary.Peek() != maxValue)
                    {
                        temporary.Pop();
                    }
                    result.Push(temporary.Pop());
                    hasItem = true;
                    temp = temporary;
                }
            }

            if (hasItem)
            {
                var sum = 0;
                var hasPossitive = false;
                while (result.Any())
                {
                    if(result.Peek() > 0 || hasPossitive)
                    {
                        sum += result.Pop();
                        hasPossitive = true;
                    }
                    else
                    {
                        result.Pop();
                    }
                }
                return sum;
            }
            
            return maxItem;

        }
    }
}
