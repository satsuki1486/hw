using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet2020.Yamaxun
{
    public static class TreasureIsland
    {
        /*
         You have a map that marks the location of a treasure island. Some of the map area has jagged rocks and dangerous reefs. 
         Other areas are safe to sail in. There are other explorers trying to find the treasure. 
         So you must figure out a shortest route to the treasure island.
         Assume the map area is a two dimensional grid, represented by a matrix of characters. 
         You must start from the top-left corner of the map and can move one block up, down, left or right at a time. 
         The treasure island is marked as X in a block of the matrix. X will not be at the top-left corner. 
         Any block with dangerous rocks or reefs will be marked as D. You must not enter dangerous blocks. 
         You cannot leave the map area. Other areas O are safe to sail in. The top-left corner is always safe. 
         Output the minimum number of steps to get to the treasure.
         Example:
         Input:
         [['O', 'O', 'O', 'O'],
          ['D', 'O', 'D', 'O'],
          ['O', 'O', 'O', 'O'],
          ['X', 'D', 'D', 'O']]
         Output: 5
         Explanation: Route is (0, 0), (0, 1), (1, 1), (2, 1), (2, 0), (3, 0) The minimum route takes 5 steps. 
        */

        public static int Distance(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return -1;
            var visited = new bool[grid.Length, grid[0].Length];
            var queue = new Queue<(int column, int row, int distance)>();
            queue.Enqueue((0, 0, 0));
            visited[0, 0] = true;
            var directions = new[] { new[] {1, 0}, new[] {-1, 0}, new[] {0, 1}, new[] {0, -1}};
            var result = 0;
            while (queue.Count > 0)
            {
                var top = queue.Dequeue();
                var dis = top.distance + 1;
                foreach (var d in directions)
                {
                    var c = top.column + d[0];
                    var r = top.row + d[1];                   
                    if (c < 0 || c >= grid.Length || r < 0 || r >= grid[0].Length || visited[c, r] || grid[c][r] == 'D')
                        continue;
                    if (grid[c][r] == 'X')
                        return dis;
                    visited[c, r] = true;
                    queue.Enqueue((c, r, dis));
                }
            }

            return result;
        }
    }
}
