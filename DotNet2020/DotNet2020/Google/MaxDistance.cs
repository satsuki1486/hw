using System;
using System.Collections.Generic;
using System.Text;
using DotNet2020.DataStructure;

namespace DotNet2020.Google
{
    public static class MaxDistance
    {
        /*
         * The distance between 2 binary strings is the sum of their lengths after removing the common prefix.
         * For example: the common prefix of 1011000 and 1011110 is 1011 so the distance is len("000") + len("110") = 3 + 3 = 6.
         * Given a list of binary strings, pick a pair that gives you maximum distance among all possible pair and return that distance.
         */
        private static int max = 0;
        public static int Execute(string[] strs)
        {
            var root = new Trie();
            foreach (var s in strs)
            {
                Build(root, s);
            }

            Distance(root);
            return max;
        }

        private static void Build(Trie root, string s)
        {
            var curr = root;
            foreach (var c in s)
            {
                if (curr.Children[c - '0'] == null)
                    curr.Children[c - '0'] = new Trie();
                curr = curr.Children[c - '0'];
            }

            curr.IsEnd = true;
        }

        private static int Distance(Trie root)
        {
            if (root == null)
                return 0;
            var left = Distance(root.Children[0]);
            var right = Distance(root.Children[1]);
            if (left != 0 && right != 0 || root.IsEnd)
                max = Math.Max(max, left + right);
            return 1 + Math.Max(left, right);
        }
    }

}
