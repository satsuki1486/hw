using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet2020.Google
{
    public static class Standups
    {
        /*
         * N people are formed in a circle during standup.
         * The first person starts the conversation and then calls on someone non-adjacent to them to go next.
         * This process repeats until everyone has spoken only once.
         * Given N, how many different combinations can standup take place?
         *
         * Example: Given 5, return 2.
         * Explanation: Possible pathes are 1->4->2->5->3 or 1->3->5->2->4 (Shown in diagram)
         *
         * Follow-up: Instead of given N, the input is given as an array where array[i] represents how long the person will be speaking for.
         * This number is multiplied by their order they speak in.
         * 1st person to go speaks for array[i] * 1, array[i] * 2 for second, array[i] * 3 for third, etc..
         * Return the minimum duration of the standup with the conversation starting at array[0].
         * If standup cannot be completed, return -1.
         * Follow-up Notes: Array is guaranteed to have atleast one element for follow-up. All elements in the array are positive integers.
         */
        private static int _ways;
        // result is for follow up, we can calculate min if we keep track of the answers
        private static List<List<int>> _result;
        public static int NumberOfWays(int n)
        {
            var curr = new HashSet<int> { 0 };
            _result = new List<List<int>>();
            _ways = 0;
            BuildCircle(n, curr, 0);
            return _ways;
        }

        public static void BuildCircle(int n, HashSet<int> curr, int baseIndex)
        {
            if (curr.Count == n)
            {
                _ways++;
                _result.Add(curr.ToList());
                return;
            }

            for (var i = 0; i < n; i++) {
                if (i == baseIndex) continue;
                if (baseIndex == 0 && (i == n - 1 || i == baseIndex + 1))
                    continue;
                if (baseIndex == n - 1 && (i == 0 || i == baseIndex - 1))
                    continue;
                if (i == baseIndex - 1 || i == baseIndex + 1)
                    continue;
                if (!curr.Add(i))
                    continue;
                BuildCircle(n, curr, i);
                curr.Remove(i);
            }
        }
    }
}
