using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet2020.Google
{
    public static class ArithmeticKElements
    {
        /**
         * Given an array i.e. [1, 2, 3, 5, 6, 7, 8] and a value k i.e. 3.
         * If there is a subarray with length of 2k satisfies a sequence
         * [a, a + 1, a + 2 ... a + k - 1, b, b + 1, b + 2... b + k - 1].
         * Return the beginning index of this subarray.
         * So with given array [1, 2, 3, 5, 6, 7, 8] and k = 3,
         * it can return 0 as [1, 2, 3, 5, 6, 7] satisfies the sequence requirement.
         * If with given array [1, 3, 5, 6, 7, 8] and k = 3, it return -1 as there is no such subarray exsits.
         */

        public static int Execute(int[] input, int k)
        {
            if (input.Length < 2 * k)
                return -1;
            if (k == 0)
                return 0;
            var i = 0;
            var j = 1;
            var count = 1;
            while (j < input.Length && count < 2 * k)
            {
                // invalid case, start over from new position
                if (input[j] - input[j - 1] != 1 && count != k)
                {
                    i = j;
                    j++;
                    count = 0;
                } else if (input[j] - input[j - 1] == 1 && count != k || count == k)
                {
                    j++;
                    count++;
                }
            }
            return j - i == 2 * k ? i : -1;
        }
    }
}
