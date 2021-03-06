using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet2020.Twitch
{
    public class BattleShip
    {
        /*
         * Given a battle ship on a N * N board, with rows in A-Z and columns in 1 - 26,
         * the battleship can take up to 4 cells, (1 * 1, 1 * 2, 1 * 3 or 2 * 2),
         * we will be given the top left and bottom right position as ship's head and tail.
         * When we provide a list of hit positions, return the number of sunken ships (all cells are hit) and the number of hit ships
         *
         * For example,
         * Given ships with [A1, B2], [A1, A3], [B2, B5] and hits with C3, C2, A1, B3, return sunken ships count and hit ships count
         */
        public (int killed, int injured) Attack(int N, string S, string T)
        {
            // Validation
            // Remove Spaces

            // parse ships
            var ships = S.Split(",").Select(s => s.Split(" "))
                .Select(coordinates => new Ship(new Position(coordinates[0]), new Position(coordinates[1]))).ToList();

            // parse hits
            var hits = T.Split(" ").Select(s => new Position(s)).ToList();
            var killed = 0;
            var injured = 0;
            foreach (var ship in ships)
            {
                var count = ship.HitCount(hits);
                if (count <= 0) continue;
                if (count == ship.Area())
                    killed++;
                else
                    injured++;
            }
            return (killed, injured);
        }

        public class Ship
        {
            // Top left
            public Position Head { get; private set; }
            // Bottom right
            public Position Tail { get; private set; }

            public Ship(Position head, Position tail)
            {
                Head = head;
                Tail = tail;
            }

            public int Area() 
                => (Math.Abs(Tail.Row - Head.Row) + 1) * (Math.Abs(Tail.Col - Head.Col) + 1);

            public int HitCount(IEnumerable<Position> hits)
            {
//                var res = 0;
//                foreach (var h in hits)
//                {
//                    if (Head.CompareTo(h) == -1 && Tail.CompareTo(h) == 1)
//                        res++;
//                }
//
//                return res;
                return hits.Count(h => Head.CompareTo(h) == -1 && Tail.CompareTo(h) == 1);
            }
        }

        public class Position
        {
            public int Row { get; private set; }
            public int Col { get; private set; }

            public Position(string pos)
            {
                Row = pos.ToUpper()[1] - 'A';
                Col = pos.ToUpper()[0] - '0';
            }

            public int CompareTo(Position other)
            {
                if (Row > other.Row && Col > other.Col)
                    return 1;
                if (Row < other.Row && Col < other.Col)
                    return -1;
                if (Row == other.Row && Col == other.Col)
                    return 0;
                // Not implemented
                return int.MinValue;
            }

            public override string ToString()
                => $"({Row},{Col})";
            
        }
    }
}
