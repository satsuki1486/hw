using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet2020.DataStructure
{
    public class FenwickTree
    {
        private readonly int[] _bit;
        public FenwickTree(int length)
        {
            _bit = new int[length];
        }

        public void Update(int i, int delta)
        {
            while (i < _bit.Length)
            {
                _bit[i] += delta;
                i += LowBit(i);
            }
        }

        public int Query(int i)
        {
            var res = 0;
            while (i > 0)
            {
                res += _bit[i];
                i -= LowBit(i);
            }
            return res;
        }

        private int LowBit(int x)
            => x & (-x);
    }
}
