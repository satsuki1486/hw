using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet2020.Google
{
    public static class MaximizeSum
    {
        /*
         * You are given one more array of size K. This array is called a multiplier array.
         * First element will get multiplied with the first number chosen. Your task is to maximise the sum of the numbers.
         * Everytime you can choose either the left most item or the right most item

            A : [2,13,7,15]
            B : [2,3]

            You can choose :
            1- 2 * 2 + 13 * 3 or
            2- 2 * 2+ 15 * 3 or
            3- 15 * 2 + 2 * 3 or
            4- 15 * 2 + 7 * 3

            Another example :
            A: [-2,8,1,15,-6]
            B: [3,2,5]

            1: -2 * 3 + 8 * 2 + 1 * 5 or
            2: -2 * 3 + -6 * 2 + 15 *5
            [...]

            (In short you've to choose from Left or Right on the array A the amount of number of elements for 
            B.length which multiplied for elements in A will maximize the sum )
         */
        public static int MaxSum(int[] A, int[] B, int k, int i, int j)
        {
            if (k == B.Length)
                return 0;
            var leftSum = A[i] * B[k] + MaxSum(A, B, k + 1, i + 1, j);
            var rightSum = A[j] * B[k] + MaxSum(A, B, k + 1, i, j - 1);
            return Math.Max(leftSum, rightSum);
        }
    }
}
