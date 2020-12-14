using System.Collections.Generic;
using System.Linq;

namespace DotNet2020.Yamaxun
{
    public static class PrimeAirRoute
    {
        public static List<List<int>> GetOptimizedUtilize(int maxTravelDist, List<PairInt> forwardRouteList,
            List<PairInt> returnRouteList)
        {
            var forward = forwardRouteList.OrderBy(f => f.Second).ToList();
            var back = returnRouteList.OrderByDescending(r => r.Second).ToList();
            var i = 0;
            var j = 0;
            var optimal = 0;
            var result = new List<List<int>>();
            while (i < forward.Count && j < back.Count)
            {
                var sum = forward[i].Second + back[j].Second;
                if (sum > maxTravelDist)
                    j++;
                else
                {
                    if (optimal < sum)
                    {
                        optimal = sum;
                        result = new List<List<int>> {new List<int> { forward[i].First, back[j].First }};
                    } else if (optimal == sum)
                        result.Add(new List<int> { forward[i].First, back[j].First });
                    i++;
                }
            }

            return result;
        }
    }

    public class PairInt
    {
        public int First;
        public int Second;
        public PairInt(int first, int second)
        {
            First = first;
            Second = second;
        }
    }
}
