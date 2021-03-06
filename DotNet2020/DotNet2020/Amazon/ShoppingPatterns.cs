using System;
using System.Collections.Generic;

namespace DotNet2020.Amazon
{
    public static class ShoppingPatterns
    {
        public static int MinProductSum(int numberOfProducts, List<int> fromProduct, List<int> toProduct)
        {
            var graph = new Dictionary<int, List<int>>();
            for (var i = 0; i < fromProduct.Count; i++)
            {
                if (!graph.ContainsKey(fromProduct[i]))
                    graph[fromProduct[i]] = new List<int>();
                if (!graph.ContainsKey(toProduct[i]))
                    graph[toProduct[i]] = new List<int>();
                graph[fromProduct[i]].Add(toProduct[i]);
                graph[toProduct[i]].Add(fromProduct[i]);
            }

            var result = int.MaxValue;
            for (var i = 1; i <= numberOfProducts; i++)
            {
                for (var j = i + 1; j <= numberOfProducts; j++)
                {
                    for (var k = j + 1; k <= numberOfProducts; k++) {
                        if (!graph[i].Contains(j) || !graph[j].Contains(k) || !graph[k].Contains(i)) continue;
                        var curr = graph[i].Count + graph[j].Count + graph[k].Count - 6;
                        result = Math.Min(result, curr);
                    }
                }
            }

            return result == int.MaxValue ? -1 : result;
        }
    }
}
