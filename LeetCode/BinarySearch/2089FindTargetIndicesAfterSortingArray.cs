using System;

namespace LeetCode.BinarySearch
{
    public class _2089FindTargetIndicesAfterSortingArray
    {
        /*
         Intuition
            You don't need to sort the Array, you only need to find numbers bigger than target and smaller than target. Once you have that you can easily count the indices.
        */
        public void DoAction()
        {
            //var input = new[] { 1, 2, 5, 2, 3 }; //5 -- 4
            //var input = new[] { 1, 10, 2, 9, 3, 8, 4, 7, 5, 6 }; //4,2
            //var input = new[] { 48, 90, 9, 21, 31, 35, 19, 69, 29, 52, 100, 54, 21, 86, 6, 45, 42, 5, 62, 77, 15, 38 }; //6 --1
            var input = new[] { 47, 39, 27, 16, 5, 51, 51, 40, 30, 100, 83, 7, 80, 3, 14, 52, 39, 43, 8, 39, 100, 14, 90, 7, 17, 72, 16, 9 }; //14 --6,7

            var result = TargetIndices_BetterSolutionNoSortNoSearch(input, 14);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Count: {input.Length}. Total Step: {_countStep}");
        }
        int _countStep = 0;

        public IList<int> TargetIndices_MySolutionInBinarySearch(int[] nums, int target)
        {
            IList<int> result = new List<int>();
            //if (nums.Length - 1 < target)
            //{
            //    return result;
            //}
            var index = SearchIndex(nums, target);
            if (index < 0)
                return result;

            index = Sorting(nums, index, target);
            for (var i = index; i < nums.Length; i++)
            {
                if (nums[i] != target)
                    break;
                result.Add(i);
            }


            return result;
        }

        public IList<int> TargetIndices_BetterSolutionNoSortNoSearch(int[] nums, int target)
        {
            List<int> nos = new List<int>();
            int startSkip = 0;
            int endSkip = 0;
            foreach (int num in nums)
            {
                if (num > target)
                {
                    endSkip++;
                }
                if (num < target)
                {
                    startSkip++;
                }
            }

            for (int i = startSkip; i < nums.Length - endSkip; i++)
            {
                nos.Add(i);
            }

            return nos;
        }

        private int SearchIndex(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                _countStep++;
                if (nums[i] == target)
                    return i;
            }
            return -1;
        }

        private int Sorting(int[] nums, int index, int target)
        {
            for (var i = 0; i < index; i++)
            {
                _countStep++;
                if (nums[i] >= target)
                {
                    var temp = nums[i];
                    nums[i] = nums[index];
                    nums[index] = temp;
                    index = i;
                    i = 0;
                }
            }

            for (var i = index + 1; i < nums.Length; i++)
            {
                _countStep++;
                if (nums[i] < nums[index])
                {
                    var temp = nums[i];
                    for (var j = i; j >= index + 1; j--)
                    {
                        _countStep++;
                        nums[j] = nums[j - 1];
                    }

                    nums[index] = temp;
                    index++;
                }
                else if (nums[i] == nums[index])
                {
                    var temp = nums[i];
                    for (var j = i; j >= index + 1; j--)
                    {
                        _countStep++;
                        nums[j] = nums[j - 1];
                    }
                    nums[index] = temp;
                    
                }
            }
            return index;
        }
    }
}