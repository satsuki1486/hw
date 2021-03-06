using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNet2020.Amazon
{
    //https://leetcode.com/discuss/interview-question/782606/
    public static class LargestItemAssociation
    {
        private static readonly Dictionary<string, List<string>> Graph = new Dictionary<string, List<string>>();

        public static List<string> Execute(List<PairString> itemAssociation)
        {
            var result = new List<List<string>>();
            foreach (var p in itemAssociation)
            {
                Graph.TryAdd(p.First, new List<string>());
                Graph.TryAdd(p.Second, new List<string>());
                Graph[p.First].Add(p.Second);
                Graph[p.Second].Add(p.First);
            }

            var visited = new HashSet<string>();
            foreach (var g in Graph)
            {
                var curr = new List<string>();
                Dfs(g.Key, visited, curr);
                if (curr.Count > 0)
                    result.Add(curr);
            }

            return result.OrderByDescending(r => r.Count).ThenBy(r => r, new ItemNameComparer()).FirstOrDefault();
        }

        private static void Dfs(string key, HashSet<string> visited, List<string> curr)
        {
            if (!visited.Add(key))
                return;
            curr.Add(key);
            foreach (var c in Graph[key])
            {
                Dfs(c, visited, curr);
            }
        }
    }

    public class ItemNameComparer : IComparer<List<string>>
    {
        public int Compare(List<string> x, List<string> y)
        {
            if (x == null || x.Count == 0)
                return -1;
            if (y == null || y.Count == 0)
                return 1;
            if (x.All(y.Contains))
                return 0;
            return x.Select((t, i) => string.Compare(t, y[i], StringComparison.Ordinal)).FirstOrDefault(compare => compare != 0);
        }
    }

    public class PairString
    {
        public string First;
        public string Second;

        public PairString(string first, string second)
        {
            First = first;
            Second = second;
        }
    }
}
