using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace DotNet2020.Amazon
{
    [TestFixture]
    public class TransactionLogs
    {
        [Test]
        public void test()
        {
            var input = new String[] { "345366 89921 45", "029323 38239 23", "38239 345366 15", "029323 38239 77",
                "345366 38239 23", "029323 345366 13", "38239 38239 23" };
            var result = FindFraudUsers(input, 3);
            foreach (var r in result)
            {
                Console.WriteLine(r);
            }
        }

        public static List<string> FindFraudUsers(string[] input, int threshold)
        {
            var dict = new Dictionary<string, int>();
            foreach (var log in input)
            {
                var transactions = log.Split(" ");
                if (!string.Equals(transactions[0], transactions[1]))
                {
                    dict[transactions[0]] = dict.ContainsKey(transactions[0]) ? dict[transactions[0]] + 1 : 1;
                }
                dict[transactions[1]] = dict.ContainsKey(transactions[1]) ? dict[transactions[1]] + 1 : 1;
            }

            return dict.Where(d => d.Value >= threshold).OrderByDescending(d => int.Parse(d.Key)).Select(d => d.Key).ToList();
        }
    }
}
