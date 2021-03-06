using System;
using NUnit.Framework;

namespace DotNet2020.Amazon
{
    [TestFixture]
    public class AutoScalePolicy
    {
        [Test]
        static void test()
        {
            System.Console.WriteLine(AutoScale(2.0, new[] { 25, 23, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 76, 80 }));
            System.Console.WriteLine(AutoScale(1.0, new[] { 1, 3, 5, 10, 80 }));
        }

        //https://leetcode.com/playground/WRHa7Aan
        private static int AutoScale(double instances, int[] averageUtil)
        {
            var i = 0;
            while (i < averageUtil.Length)
            {
                if (averageUtil[i] > 60 && instances * 2 < 2 * Math.Pow(10.0, 8.0))
                {
                    instances *= 2.0;
                    i += 10;
                }
                else if (averageUtil[i] < 25 && instances > 1.0)
                {
                    instances = Math.Ceiling(instances / 2.0);
                    i += 10;
                }
                else
                {
                    i++;
                }
            }
            return (int)instances;
        }
    }
}
