using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet2020.Twitch
{
    public class DuplicatedNumberArray
    {
        /**
         * Return a duplicated number array with given array.
         * For example:
         * [1,2,3,4,5] => []
         * [1,1,2,3,3,3,3] => [1,3,3]
         * [1,3,3,3] => [3,3]
         * [2,2] => [2]
         */
        public int[] DuplicatedArray(int[] nums)
        {
            // hashtable?
            Array.Sort(nums);
            var res = new List<int>();
            var prev = -1;
            for (var i = 0; i < nums.Length; i++)
            {
                if (i != nums.Length - 1 && nums[i] == nums[i + 1]) continue;
                var count = i - prev;
                var total = count % 2 != 0 ? (count + 1) / 2 : count / 2;
                for (var j = 0; j < total; j++)
                {
                    res.Add(nums[i]);
                }
                prev = i;
            }

            return res.ToArray();
        }
    }
}
