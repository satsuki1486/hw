using System.Collections.Generic;
using System.Linq;

namespace DotNet2020.Google
{
    public static class CardsInASet
    {
        private const int threeXor = 0 ^ 1 ^ 2;
        /*
         * First describe a situation you missed a deadline and what you have learnt from it.
         * Then coding question: Card has 4 attributes (color, count, shading, shape),
         * each attribute can have value 0, 1 or 2. 3 cards are considered as a set if for each attribute,
         * 3 cards either have the same value or have different value from each other. For example:
         * card1 (2, 0, 1, 2), card2 (1, 0, 0, 1) and card3(0, 0, 2, 0) are 1 set.
         * card1(2, 0, 1, 2), card2 (1, 1, 0, 1) and card3(0, 1, 2, 0) are not 1 set.
         * write a boolean function with 3 cards as input. This function returns true if they are 1 set, otherwise returns false.
         * Now given a collection of cards, return true if there is a set of cards exsits, otherwise return false.
         * The interviewer wants O(n^2) solution.
         */
        /*
         * The idea is to use XOR property . (A^B^C) ^ (A^B) =C
         * To check if three cards make a set, for each attribute, we take apir wise xor for each attribute and xor with the third
         * Below two scenarios arise: if A,B,C are three values of attribute 0
         * A==B==C then A^B ==0. and C should be equal to A
         * A,B,C=(1,2,3) then (A^B)^ (A^B^C) = C.
         * Thus we can easily deduce the value of C
         * We use the above property to calculate pair wise of xors with O(N^2) and check for the third attribute in an unorrdered_map with O(1).
         */
        public static bool AreCardingInOneSet(Card[] cards)
        {
            var cardSet = new HashSet<Card>();
            for (var i = 0; i < cards.Length; i++)
            {
                for (var j = i + 1; j < cards.Length; j++)
                {
                    var pair = PairXor(cards[i], cards[j]);
                    cardSet.Add(pair);
                    var newCard = new Card
                    {
                        Color = pair.Color == 0 ? cards[i].Color : threeXor ^ pair.Color,
                        Count = pair.Count == 0 ? cards[i].Count : threeXor ^ pair.Count,
                        Shape = pair.Shape == 0 ? cards[i].Shape : threeXor ^ pair.Shape,
                        Shading = pair.Shading == 0 ? cards[i].Shading : threeXor ^ pair.Shading,
                    };

                    if (cardSet.Any(c => c.Equals(newCard)))
                        return true;
                }
            }

            return false;
        }

        private static Card PairXor(Card c1, Card c2)
            => new Card
            {
                Color = c1.Color ^ c2.Color,
                Count = c1.Count ^ c2.Count,
                Shape = c1.Shape ^ c2.Shape,
                Shading = c1.Shading ^ c2.Shading
            };

        // 3 cards at a time
        public static (bool, Card) IsSet(Card[] cards)
        {           
            var xorCard = PairXor(cards[0], cards[1]);

            if (xorCard.Color == 0 && cards[0].Color != cards[2].Color ||
                (xorCard.Count == 0 && cards[0].Count != cards[2].Count) ||
                (xorCard.Shape == 0 && cards[0].Shape != cards[2].Shape) ||
                (xorCard.Shading == 0 && cards[0].Shading != cards[2].Shading ))
                return (false, xorCard);

            if (xorCard.Color != 0 && cards[2].Color != (xorCard.Color ^ threeXor) ||
                xorCard.Count != 0 && cards[2].Count != (xorCard.Count ^ threeXor) ||
                xorCard.Shape != 0 && cards[2].Shape != (xorCard.Shape ^ threeXor) ||
                xorCard.Shading != 0 && cards[2].Shading != (xorCard.Shading ^ threeXor))
                return (false, xorCard);

            return (true, xorCard);
        }
    }

    public class Card
    {
        public int Color { get; set; }
        public int Count { get; set; }
        public int Shape { get; set; }
        public int Shading { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Card c)
            {
                return c.Color == Color && c.Count == Count && c.Shape == Shape && c.Shading == Shading;
            }

            return false;
        }
    }
}
