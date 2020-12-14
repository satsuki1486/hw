using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet2020.FB
{
    public static class TreeWithMultipleParents
    {
        /*
         * Question 1
        Given a list of pairs in the format [(parent, child)] find the nodes with zero parent and one parent. On probing, the nodes are unique positive integers

        find_zero_and_one_parent(list_of_parent_child_pairs) -> [list, list]

        Question 2
        As an extension to the first question, given a similar list of parent child pairs and two nodes find if a common ancestor exists.

        find_if_common_ancestor_exists(list_of_parent_child_pairs, node_1, node_2) -> bool

        list_of_parent_child_pairs = [(11,7), (11,1), (1,2), (1,4), (3,5)...]
         */
        public static List<int> FindZeroAndOneParent(List<int[]> pairs)
        {            
            var graph = GetAdjList(pairs);
            var zeroParents = graph.SelectMany(g => g.Value).Except(graph.Select(gr => gr.Key)).ToList();
            var oneParent = graph.Where(g => g.Value.Count == 1).Select(g => g.Key).ToList();
            zeroParents.AddRange(oneParent);
            return zeroParents;
        }

        private static Dictionary<int, List<int>> GetAdjList(List<int[]> pairs)
        {
            // <child, parents>
            var graph = new Dictionary<int, List<int>>();
            foreach (var p in pairs)
            {
                if (!graph.ContainsKey(p[1]))
                    graph[p[1]] = new List<int>();
                graph[p[1]].Add(p[0]);
            }

            return graph;
        }

        public static int FindLCA(List<int[]> pairs, int a, int b)
        {
            var graph = GetAdjList(pairs);
            var q1 = new Queue<int>();
            var q2 = new Queue<int>();
            var parents1 = new List<int>();
            var parents2 = new List<int>();
            q1.Enqueue(a);
            q2.Enqueue(b);
            while (q1.Count != 0 || q2.Count != 0)
            {
                var top1 = q1.Count != 0 ? q1.Dequeue() : -1;
                var top2 = q2.Count != 0 ? q2.Dequeue() : -1;
                if (top1 != -1)
                    parents1.Add(top1);
                if (top2 != -1)
                    parents2.Add(top2);
                if (parents2.Any(p => parents1.Contains(p)))
                    return parents2.Intersect(parents1).First();
                if (graph.ContainsKey(top1))
                {
                    foreach (var c in graph[top1])
                    {
                        q1.Enqueue(c);
                    }
                }
                if (graph.ContainsKey(top2))
                {
                    foreach (var c in graph[top2])
                    {
                        q2.Enqueue(c);
                    }
                }
            }

            return -1;
        }
    }
}
