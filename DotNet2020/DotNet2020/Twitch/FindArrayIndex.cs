using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet2020.Twitch
{
    public class FindArrayIndex
    {
        /*
         * Find an index in given array such that everything before index is less than everything after index
         * Left side needs to be as small as possible
         * For example: [-5, -5, -5, -42, 6, 8]
         * returns 4
         */
        public int FindIndex(int[] nums)
        {
            var l = 0;
            var r = nums.Length;
            while (l < r)
            {
                var m = (l + r) / 2;
                if (Greater(nums, m))
                    r = m;
                else
                    l = m + 1;
            }

            return l == nums.Length ? 0 : l;
        }

        public bool Greater(int[] nums, int index)
        {
            var left = new int[index];
            Array.Copy(nums, left, index);
            var right = new int[nums.Length - index];
            Array.Copy(nums, index, right, 0, right.Length);
            return left.Length != 0 && right.Length != 0 && left.Max() < right.Min();
        }
    }
}
