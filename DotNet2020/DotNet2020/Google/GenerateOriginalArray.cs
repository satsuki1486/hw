using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet2020.DataStructure;

namespace DotNet2020.Google
{
    public static class GenerateOriginalArray
    {
        /*
         * Given an integer array q = {3,5,1,4,2}
            P contains deleted index
            Delete 1 {3,5,4,2} | p={3}
            Delete 2 {3,5,4} | p={3,4}
            Delete 3 {5,4} | p={3,4,1}
            Delete 4 {5} | p={3,4,1,2}
            Delete 5 {} | p={3,4,1,2,1}

            Now given p as input, generate the original array q.Please provide optimized solution.
         */
        public static int[] Gen(int[] q)
        {
            // do a presum on frequency of items in original array
            var tree = new FenwickTree(q.Length + 1);
            var ordered = new List<(int pos, int item)>();
            for (var i = 0; i < q.Length; i++)
            {
                var smaller = tree.Query(q[i]); // total items smaller than index q[i]/ how many index <= ids[i] have we seen
                tree.Update(q[i], 1);
                ordered.Add((q[i] + smaller, i + 1));
            }

            ordered = ordered.OrderBy(o => o.pos).ToList();
            return ordered.Select(o => o.item).ToArray();
        }
    }
}
