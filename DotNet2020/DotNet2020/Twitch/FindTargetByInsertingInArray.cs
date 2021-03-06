using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet2020.Twitch
{
    public class FindTargetByInsertingInArray
    {
        /**
         * Given an array and a target of int, return if we can get to the target by inserting + or * in array
         */
        public bool GetTarget(int[] nums, int target)
        {
            // curr[0] stores the result of applying +
            // curr[1] stores the result of applying *
            return nums.Length != 0 && Backtracking(nums, 0, target, new[] { 0, 1 });
        }

        private bool Backtracking(int[] nums, int start, int target, int[] curr)
        {
            if (start >= nums.Length)
                return false;
            for (var i = start; i < nums.Length; i++)
            {
                var orinal = curr[1];
                curr[0] += nums[i];
                curr[1] *= nums[i];
                if (curr.Any(c => c == target))
                    return true;
                Backtracking(nums, i + 1, target, curr);
                curr[0] -= nums[i];
                curr[1] = nums[i] == 0 ? orinal : curr[1] / nums[i];
            }

            return false;
        }
    }
}
