using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet2020.DataStructure
{
    public class Trie
    {
        public bool IsEnd { get; set; }
        public Trie[] Children { get; set; }

        public Trie()
        {
            Children = new Trie[2];
        }
    }
}
