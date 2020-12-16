using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet2020.Google
{
    public static class CourseSchedule
    {
        public static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            // init
            var graph = new List<List<int>>();
            var levels = new int[numCourses];
            var removedEdges = 0;
            var queue = new Queue<int>();
            for (var i = 0; i < numCourses; i++)
                graph.Add(new List<int>());

            // build graph
            foreach (var p in prerequisites)
            {
                var from = p[1];
                var to = p[0];
                graph[from].Add(to);
                levels[to]++;
            }

            // find root
            var root = levels.Select((s, i) => new { i, s }).Where(l => l.s == 0).Select(l => l.i).ToList();
            foreach (var r in root)
                queue.Enqueue(r);

            // Topology sort
            while (queue.Count != 0)
            {
                var top = queue.Dequeue();
                removedEdges++;
                foreach (var e in graph[top])
                {
                    levels[e]--;
                    if (levels[e] == 0)
                        queue.Enqueue(e);
                }
            }

            return removedEdges == numCourses;
        }
    }
}
