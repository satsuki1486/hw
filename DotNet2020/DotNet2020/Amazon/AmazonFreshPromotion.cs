using System;

namespace DotNet2020.Amazon
{
    // Sliding window
    // https://leetcode.com/discuss/interview-question/932920/
    public static class AmazonFreshPromotion
    {
        public static bool Execute(string[][] codes, string[] shoppingCart)
        {
            // position of code grp
            var i = 0;
            // position of shopping cart
            var k = 0;
            while (i < codes.Length && k < shoppingCart.Length)
            {
                // position of code in code grp
                var j = 0;
                while (j < codes[i].Length && k < shoppingCart.Length)
                {
                    if (Matches(codes[i][j], shoppingCart[k++]))
                        j++;
                    else
                        break;
                }

                if (j == codes[i].Length)
                    i++;
                else
                    k -= j;
            }

            return i == codes.Length;
        }

        private static bool Matches(string c, string s)
            => c.Equals("anything", StringComparison.OrdinalIgnoreCase) ||
               c.Equals(s, StringComparison.OrdinalIgnoreCase);
    }
}
