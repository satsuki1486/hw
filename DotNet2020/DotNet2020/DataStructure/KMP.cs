using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet2020.DataStructure
{
    public static class KMP
    {
        // Time complexity is O(N) - the inner while loop doesn't take more than time N to run
        //Build the next arr, where next[i] refers to the longest length of prefix which is also suffix for substring(0 to i)
        public static int[] Build(string s)
        {
            var result = new List<int> { 0, 0 };
            var j = 0;
            for (var i = 1; i < s.Length; i++)
            {
                while (j > 0 && s[i] != s[j])
                    j = result[j];
                if (s[i] == s[j])
                    j++;
                result.Add(j);
            }

            return result.ToArray();
        }

        // b is substring of a, return an array of index of the start index of b in a
        public static int[] Match(string a, string b)
        {
            var ans = new List<int>();
            var next = Build(b);
            var j = 0;
            for (var i = 0; i < a.Length; i++)
            {
                while (j > 0 && a[i] != b[j])
                    j = next[j];
                if (a[i] == b[j])
                    j++;
                if (j == b.Length)
                {
                    ans.Add(j);
                    j = next[j];
                }
            }

            return ans.ToArray();
        }
    }
}
