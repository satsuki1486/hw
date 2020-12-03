using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace DotNet2020.Yamaxun
{
    [TestFixture]
    public class FiveStarSellers
    {
        [Test]
        static void test()
        {
            var result = FiveStar(new[] {new[] {4, 4}, new[] {1, 2}, new[] {3, 6}}, 3);
            System.Console.WriteLine(result);
        }

        public static int FiveStar(int[][] ratings, int target)
        {
            var curr = Avg(ratings, -1);
            var result = 0;
            while (curr < (decimal)target / 100)
            {
                result++;
                (int Product, decimal Diff) bestChange = (0, 0);
                for (var i = 0; i < ratings.Length; i++)
                {
                    var tempAvg = Avg(ratings, i);
                    var diff = tempAvg - curr;
                    if (diff > bestChange.Diff)
                    {
                        bestChange.Product = i;
                        bestChange.Diff = diff;
                    }
                }

                ratings[bestChange.Product][0]++;
                ratings[bestChange.Product][1]++;
                curr += bestChange.Diff;
            }

            return result;
        }

        private static decimal Avg(int[][] ratings, int index)
        {
            decimal result = 0;
            for (var i = 0; i < ratings.Length; i++)
            {
                if (i == index)
                    result += ((decimal)ratings[i][0] + 1) / ((decimal)ratings[i][1] + 1);
                else
                    result += (decimal)ratings[i][0] / (decimal)ratings[i][1];
            }

            return result / ratings.Length;
        }
    }
}
