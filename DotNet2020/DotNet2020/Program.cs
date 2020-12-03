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
            var time = new[] { 1, 2, 4 };
            var directions = new[] { 0, 1, 1 };
            var result = Turstile.Turn(time, directions);

        }
    }
}
