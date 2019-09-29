using System;
using System.Collections.Generic;
using System.IO;

namespace TwoSum
{
    /*
     * Assignment: https://leetcode.com/problems/two-sum/
     */
    class TwoSum
    {

        static int[] TwoSumFunc(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var currentNumber = nums[i];
                var complement = target - currentNumber;
                // Check if we have seen the complement before and that the indices are different for an acceptable solution
                if (dict.ContainsKey(complement) && dict[complement] != i)
                {
                    return new int[] { dict[complement], i };
                }

                // Save the current index at position currentNumber
                dict[currentNumber] = i;
            }
            throw new ArgumentException("No solution found.");
        }

        static void Main(string[] args)
        {



            int[] arr = { 1, 2, 3 };
            var target = 9;
            int[] result = TwoSumFunc(arr, target);

            Console.WriteLine(result[0] + " " + result[1]);

        }

    }
}
