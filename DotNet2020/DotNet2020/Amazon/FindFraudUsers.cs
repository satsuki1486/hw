using System.Collections.Generic;
using System.Linq;

namespace DotNet2020.Amazon
{
    public class FindFraudUsers
    {
        public static List<string> Find(string[] input, int threshold)
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
