﻿using System;
using System.Collections.Generic;
using System.Linq;
using DotNet2020.Amazon;
using DotNet2020.FB;
using DotNet2020.Google;
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
            //            var itemAssociation1 = new List<PairString>
            //            {
            //                new PairString("item1", "item2"),
            //                new PairString("item3", "item4"),
            //                new PairString("item4", "item5")
            //            };
            //            var itemAssociation2 = new List<PairString>
            //            {
            //                new PairString("item1", "item2"),
            //                new PairString("item6", "item7"),
            //                new PairString("item6", "item8"),
            //                new PairString("item3", "item4"),
            //                new PairString("item4", "item5"),
            //            };
            //            var itemAssociation3 = new List<PairString>
            //            {
            //                new PairString("item1", "item2"),
            //                new PairString("item4", "item5"),
            //                new PairString("item3", "item4"),
            //                new PairString("item1", "item4")
            //            };
            //            var result = LargestItemAssociation.Execute(itemAssociation2);
            // Items in containers
            //            var str = "|**|*|*";
            //            var start = new[] { 1, 1 };
            //            var end = new[] {5, 6};
            // // Output is [2, 3]
            //            var str = "*|*";
            //            var start = new[] { 1 };
            //            var end = new[] { 3 };
            // // Output is [0]
            //            var str = "****|*|";
            //            var start = new[] { 1, 4, 2 };
            //            var end = new[] { 3, 7, 7 };
            //            // Output is [0, 1, 1]
            //            var str = "*******";
            //            var start = new[] { 1, 4, 2 };
            //            var end = new[] { 3, 7, 7 };
            //            // Output is [0, 0, 0]
            //            var str = "||||||||||";
            //            var start = new[] { 1, 4, 2 };
            //            var end = new[] { 3, 7, 7 };
            //            // Output is [0, 0, 0]
            //            var result = ItemsInContainers.GetItemsInContainer(str, start, end);
            //            // Amazon Fresh Promo
            //            var codeList1 = new[] { new []{ "apple", "apple" }, new[] { "banana", "anything", "banana" } };
            //            var shoppingCart1 = new[] { "orange", "apple", "apple", "banana", "orange", "banana" };
            //            var codeList2 = new[] { new[] { "apple", "apple" }, new[] { "banana", "anything", "banana" } };
            //            var shoppingCart2 = new[] { "banana", "orange", "banana", "apple", "apple" };
            //            var codeList3 = new[] { new[] { "apple", "apple" }, new[] { "banana", "anything", "banana" } };
            //            var shoppingCart3 = new[] { "apple", "banana", "apple", "banana", "orange", "banana" };
            //            var codeList4 = new[] { new[] { "apple", "apple" }, new[] { "apple", "apple", "banana" } };
            //            var shoppingCart4 = new[] { "apple", "apple", "apple", "banana" };
            //            var codeList5 = new[] { new[] { "apple", "apple" }, new[] { "banana", "anything", "banana" } };
            //            var shoppingCart5 = new[] { "orange", "apple", "apple", "banana", "orange", "banana" };
            //            var codeList6 = new[] { new[] { "apple", "apple" }, new[] { "banana", "anything", "banana" } };
            //            var shoppingCart6 = new[] { "apple", "apple", "orange", "orange", "banana", "apple", "banana", "banana" };
            //            var codeList7 = new[] { new[] { "anything", "apple" }, new[] { "banana", "anything", "banana" } };
            //            var shoppingCart7 = new[] { "orange", "grapes", "apple", "orange", "orange", "banana", "apple", "banana", "banana" };
            //            var codeList8 = new[] { new[] { "apple", "orange" }, new[] { "orange", "banana", "orange" } };
            //            var shoppingCart8 = new[] { "apple", "orange", "banana", "orange", "orange", "banana", "orange", "grape" };
            //            var codeList9 = new[] { new[] { "anything", "anything", "anything", "apple" }, new[] { "banana", "anything", "banana" } };
            //            var shoppingCart9 = new[] { "orange", "apple", "banana", "orange", "apple", "orange", "orange", "banana", "apple", "banana" };
            //            var codeList10 = new[] { new[] { "anything", "apple" }, new[] { "banana", "anything", "banana" } };
            //            var shoppingCart10 = new[] { "orange", "grapes", "apple", "orange", "orange", "banana", "apple", "banana", "banana" };
            //            var result1 = AmazonFreshPromotion.Execute(codeList1, shoppingCart1);
            //            var result2 = AmazonFreshPromotion.Execute(codeList2, shoppingCart2);
            //            var result3 = AmazonFreshPromotion.Execute(codeList3, shoppingCart3);
            //            var result4 = AmazonFreshPromotion.Execute(codeList4, shoppingCart4);
            //            var result5 = AmazonFreshPromotion.Execute(codeList5, shoppingCart5);
            //            var result6 = AmazonFreshPromotion.Execute(codeList6, shoppingCart6);
            //            var result7 = AmazonFreshPromotion.Execute(codeList7, shoppingCart7);
            //            var result8 = AmazonFreshPromotion.Execute(codeList8, shoppingCart8);
            //            var result9 = AmazonFreshPromotion.Execute(codeList9, shoppingCart9);
            //            var result10 = AmazonFreshPromotion.Execute(codeList10, shoppingCart10);
            // Prime Air Routes
            //            var max = 7000;
            //            var forward = new List<PairInt>
            //            {
            //                new PairInt(1, 2000),
            //                new PairInt(2, 4000),
            //                new PairInt(3, 6000),
            //            };
            //            var back = new List<PairInt>
            //            {
            //                new PairInt(1, 2000),
            //            };
            //            var max = 10000;
            //            var forward = new List<PairInt>
            //            {
            //                new PairInt(1, 3000),
            //                new PairInt(2, 5000),
            //                new PairInt(3, 7000),
            //                new PairInt(4, 10000),
            //            };
            //            var back = new List<PairInt>
            //            {
            //                new PairInt(1, 2000),
            //                new PairInt(2, 3000),
            //                new PairInt(3, 4000),
            //                new PairInt(4, 5000),
            //            };
            //            var max = 10000;
            //            var forward = new List<PairInt>
            //            {
            //                new PairInt(1, 3000),
            //                new PairInt(2, 5000),
            //                new PairInt(3, 7000),
            //                new PairInt(4, 10000),
            //            };
            //            var back = new List<PairInt>
            //            {
            //                new PairInt(1, 2000),
            //                new PairInt(2, 3000),
            //                new PairInt(3, 4000),
            //                new PairInt(4, 5000),
            //            };
            // Shopping Pattern
            //            var fromProduct = new List<int>{ 1, 2, 2, 3, 4, 5 };
            //            var toProduct = new List<int> { 2, 4, 5, 5, 5, 6 };
            //            var fromProduct = new List<int> { 1, 1, 2, 2, 3, 4 };
            //            var toProduct = new List<int> { 2, 3, 3, 4, 4, 5 };
            //            var result = ShoppingPatterns.MinProductSum(6, fromProduct, toProduct);
            // Distance between nodes
            //            var arr = new int[] {2, 1, 3};
            //            var result = DistanceBetweenNodesInBST.BSTDistance(arr, 1, 4);
            //            var arr = new int[] { 4, 6, 9, 11, 1, 2, 5, 7 };
            //            var result = DistanceBetweenNodesInBST.BSTDistance(arr, 1, 7);
            //            var arr = new int[] { 24, 6, 2, 22, 30, 25, 20, 15, 7, 8, 10, 9, 1 };
            //            var result = DistanceBetweenNodesInBST.BSTDistance(arr, 1, 9);
            // Treasure Island
            //            var arr = new[]
            //            {
            //                new [] {'O', 'O', 'O', 'O'},
            //                new [] {'D', 'O', 'D', 'O'},
            //                new [] {'O', 'O', 'O', 'O'},
            //                new [] {'X', 'D', 'D', 'O'},
            //            };
            //            var result = TreasureIsland.Distance(arr);
            // TreeWithMultipleParents
            //            var input = new List<int[]>
            //            {
            //                new int[] {1, 2},
            //                new int[] {1, 3},
            //                new int[] {2, 4},
            //                new int[] {2, 5},
            //                new int[] {3, 6},
            //                new int[] {5, 6},
            //            };
            //            var input1 = new List<int[]>
            //            {
            //                new int[] {1, 2},
            //                new int[] {2, 3},
            //                new int[] {3, 4},
            //            };
            //
            //            var input2 = new List<int[]>
            //            {
            //                new int[] {1, 2},
            //                new int[] {3, 4},
            //            };
            //
            //            var result = TreeWithMultipleParents.FindZeroAndOneParent(input2);
            //            // 1
            //            var result1 = TreeWithMultipleParents.FindLCA(input, 4, 3);
            //            // 1
            //            var result2 = TreeWithMultipleParents.FindLCA(input, 2, 6);
            //            // 1
            //            var result3 = TreeWithMultipleParents.FindLCA(input, 1, 6);
            //            // -1
            //            var result4 = TreeWithMultipleParents.FindLCA(input, 10, 6);
            //            // 5
            //            var result5 = TreeWithMultipleParents.FindLCA(input, 5, 6);
            //            // -1
            //            var result6 = TreeWithMultipleParents.FindLCA(input2, 2, 4);
            // ComputerCoreAndTasks
            //            var c1 = new int[] { 5, 6 };
            //            var t1 = new int[] { 3, 3, 5 };
            //            var c2 = new int[] { 2, 4 };
            //            var t2 = new int[] { 1, 1, 4 };
            //            var c3 = new int[] { 8, 10 };
            //            var t3 = new int[] { 2, 3, 3, 3, 7 };
            //            var c4 = new int[] { 1, 3 };
            //            var t4 = new int[] { 2, 2 };
            //            var c5 = new int[] { 10, 15 };
            //            var t5 = new int[] { 8, 7, 6, 5 };
            //            var result = ComputerCoreAndTasks.CanExecute(c1, t1, 0);
            // Houses and heaters
            //            var houses = new int[] { 1, 5 };
            //            var heaters = new int[] { 2 };
            //            var result = HousesAndHeaters.FindRadius(houses, heaters);
            // Maximize Sum
            //            var A = new int[] { -2, 8, 1, 15, -6 };
            //            var B = new int[] { 3, 2, 5 };
            //            var A = new int[] { 2, 13, 7, 15 };
            //            var B = new int[] { 2, 3 };
            //            var result = MaximizeSum.MaxSum(A, B, 0, 0, B.Length - 1);
            // Course Schedule
            //            var input = new int [][]
            //            {
            //                new int[] {1, 0},
            //                new int[] {2, 0},
            //                new int[] {3, 2},
            //                new int[] {2, 4},
            //                new int[] {4, 3},
            //            };
            //            var result = CourseSchedule.CanFinish(5, input);
            // Max Distance
            //            var str = new[] { "1011000", "1011110", "1011111" };
            //            var result = MaxDistance.Execute(str);
            // Rover move
            //            var result = RoverControl.RoverMove(4, new[] {"RIGHT", "DOWN", "LEFT", "LEFT", "DOWN"});
            // GenerateOriginalArray
            // {3, 4, 5, 1, 2}
            // var result = GenerateOriginalArray.Gen(new[] {4, 4, 1, 1, 1});
            // {3,5,1,4,2}
//            var result = GenerateOriginalArray.Gen(new[] { 3, 4, 1, 2, 1 });
            var result = Standups.NumberOfWays(9);
        }
    }
}
