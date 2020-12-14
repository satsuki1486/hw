using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet2020.Yamaxun
{
    public static class ItemsInContainers
    {
        /*
         * start  (count the *s in between) end
         *   !   |-------------------------| !
         * find first | to start's right
         * find first | to end's left
         */
        public static int[] GetItemsInContainer(string s, int[] startIndicies, int[] endIndicies)
        {
            if (string.IsNullOrWhiteSpace(s) || startIndicies == null || endIndicies == null ||
                startIndicies.Length != endIndicies.Length)
                return new int[] { };
            var result = new int[startIndicies.Length];
            // presum
            var countOfStars = new int[s.Length];
            // the closest '|' to position i on the left
            var leftClosestIdx = new int[s.Length];
            // the closest '|' to position i on the right
            var rightClosestIdx = new int[s.Length];

            var curr = -1;
            var sum = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '*')
                    sum++;
                countOfStars[i] = sum;
            }

            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '|')
                    curr = i;
                leftClosestIdx[i] = curr;
            }

            curr = -1;
            for (var i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '|')
                    curr = i;
                rightClosestIdx[i] = curr;
            }

            for (var i = 0; i < startIndicies.Length; i++)
            {
                var start = startIndicies[i] - 1;
                var end = endIndicies[i] - 1;
                if (leftClosestIdx[end] != -1 && rightClosestIdx[start] != -1)
                {
                    result[i] = countOfStars[leftClosestIdx[end]] - countOfStars[rightClosestIdx[start]];
                }
            }

            return result;
        }
    }
}
