using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNet2020.Amazon
{
    public static class Turstile
    {
        /*
         * Corner case
         * [1, 1]
         * [1, 1]
         * =======
         * [1, 2, 4]
         * [0, 1, 1]
         * =======
         * Normal case
         * [0, 0, 1, 5]
         * [0, 1, 1, 0]
         */
        public static int[] Turn(int[] time, int[] direction)
        {
            if (time == null || direction == null || time.Length == 0 || direction.Length == 0)
                return null;
            var dict = new List<SortedSet<int>>[Math.Max(time.Length + 1, time.Max() + 1)];
            for (var i = 0; i < dict.Length; i++)
                dict[i] = new List<SortedSet<int>> { new SortedSet<int>(), new SortedSet<int>() };
            for (var i = 0; i < time.Length; i++)
            {
                var t = time[i];
                var d = direction[i];                
                dict[t][d].Add(i);
            }
            var result = new int[time.Length];
            var status = new char[dict.Length];
            for (var i = 0; i < status.Length; i++)
                // U - unused
                // E - enter
                // L - leave
                status[i] = 'U';
            for (var i = 0; i < dict.Length; i++)
            {
                // more than 1 person wants to use the turstile
                if (dict[i][0].Count + dict[i][1].Count > 1)
                {
                    if (i == 0 || status[i - 1] == 'U' || status[i - 1] == 'L')
                    {
                        int curr;
                        if (dict[i][1].Any())
                        {
                            curr = dict[i][1].First();
                            dict[i][1].Remove(curr);
                        }
                        else
                        {
                            curr = dict[i][0].First();
                            dict[i][0].Remove(curr);
                        }
                        result[curr] = i;
                        
                        if (i < dict.Length - 1)
                        {
                            dict[i + 1][0].UnionWith(dict[i][0]);
                            dict[i + 1][1].UnionWith(dict[i][1]);
                        }

                        status[i] = 'L';
                    }
                    else if (status[i - 1] == 'E')
                    {
                        int curr;
                        if (dict[i][0].Any())
                        {
                            curr = dict[i][0].First();
                            dict[i][0].Remove(curr);
                        }
                        else
                        {
                            curr = dict[i][1].First();
                            dict[i][1].Remove(curr);
                        }
                        if (i < dict.Length - 1)
                        {
                            dict[i + 1][0].UnionWith(dict[i][0]);
                            dict[i + 1][1].UnionWith(dict[i][1]);
                        }
                        status[i] = 'E';
                    }
                }
                else if (dict[i][0].Count + dict[i][1].Count == 1)
                {
                    var curr = dict[i].SelectMany(n => n).First();
                    result[curr] = i;
                    status[i] = dict[i][0].Count == 0 ? 'L' : 'E';
                }
            }
            return result;
        }
    }
}
