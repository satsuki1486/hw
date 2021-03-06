using System.Linq;

namespace DotNet2020.Amazon
{
    public static class KClosestPointToOrigin
    {
        //https://youtu.be/G9VcMTSZ1Lo
        public static int[][] KClosest(int[][] points, int K)
        {
            var start = 0;
            var end = points.Length - 1;
            while (start < end && K >= 0)
            {
                var pivot = Partition(points, start, end);
                if (pivot == K)
                    break;
                if (pivot > K)
                    end = pivot - 1;
                else
                {
                    start = pivot + 1;
                    K -= pivot - start + 1;
                }
            }
            return points.Skip(0).Take(K).ToArray();
        }

        private static int Partition(int[][] points, int start, int end)
        {
            // left and right are pointers starting from left of the array
            // try to keep everything left to l smaller and in between l and r bigger ones
            // use the last element as pivot p
            /* while (r != p)
             * {
             *  if a[r] > a[p]
             *    r++
             *  else
             *    l++
             *    swap(l, r)
             *    r++
             * }
             * swap(l + 1, p)
             * return l + 1 as pivot index
             *
             */
            var left = start - 1;
            var right = start;
            while (right != end)
            {
                if (Distance(points[right], points[end]) <= 0)
                {
                    left++;
                    Swap(points, left, right);
                }
                right++;
            }
            Swap(points, left + 1, end);
            return left + 1;
        }

        private static void Swap(int[][] points, int a, int b)
        {
            var temp = points[a];
            points[a] = points[b];
            points[b] = temp;
        }

        private static int Distance(int[] p1, int[] p2)
            => p1[0] * p1[0] - p2[0] * p2[0] + p1[1] * p1[1] - p2[1] * p2[1];
    }
}
