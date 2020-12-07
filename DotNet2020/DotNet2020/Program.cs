using System;
using System.Collections.Generic;
using System.Linq;
using DotNet2020.Yamaxun;

namespace DotNet2020
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Five star
            //            var result = FiveStar(new[] { new[] { 4, 4 }, new[] { 1, 2 }, new[] { 3, 6 } }, 77);
            //            System.Console.WriteLine(result);
            // Turstile
            //            var time = new[] { 0, 0, 0, 1, 5 };
            //            var directions = new[] { 0, 1, 0, 1, 0 };
            //            var time = new[] { 1, 1 };
            //            var directions = new[] { 1, 1 };
            //            var time = new[] { 1, 2, 4 };
            //            var directions = new[] { 0, 1, 1 };
            // Connected Components
            var itemAssociation1 = new List<PairString>
            {
                new PairString("item1", "item2"),
                new PairString("item3", "item4"),
                new PairString("item4", "item5")
            };
            var itemAssociation2 = new List<PairString>
            {
                new PairString("item1", "item2"),
                new PairString("item6", "item7"),
                new PairString("item6", "item8"),
                new PairString("item3", "item4"),
                new PairString("item4", "item5"),
            };
            var itemAssociation3 = new List<PairString>
            {
                new PairString("item1", "item2"),
                new PairString("item4", "item5"),
                new PairString("item3", "item4"),
                new PairString("item1", "item4")
            };
            var result = LargestItemAssociation.Execute(itemAssociation2);
        }
    }
}
