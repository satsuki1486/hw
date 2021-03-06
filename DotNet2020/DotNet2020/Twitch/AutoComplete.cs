using System.Collections.Generic;

namespace DotNet2020.Twitch
{
    public class AutoComplete
    {
        /*
         * Given input "nin", return "ninja" or "nintendo", etc based on prefix match.
         * Input should accept a string prefix, as well as an array of the streamers you will have to auto complete,
         * As the output, return a sorted list of steamers that match given prefix.
         *
         * Constraints:
         * 1. Streamer names only contain alpha numeric chars
         * 2. Streamer names are unique
         * 3. Design this so that multiple prefix queries can by run against same set of streamers
         * 4. Streamers are pre sorted
         * 5. Optimize for computation at scale not memory
         * 6. Streamer list won't change
         * 7. Case sensitive
         * 8. Empty prefix will return no matches
         * 9. No matches should return "noMatches"
         */
        private readonly Trie _root;
        public AutoComplete(IEnumerable<string> streamers)
        {
            _root = new Trie();
            foreach (var streamer in streamers)
            {
                var curr = _root;
                foreach (var c in streamer)
                {
                    int index;
                    if (char.IsUpper(c))
                        index = c - 'A';
                    else
                        index = c - 'a' + 26;
                    if (curr.Children[index] == null)
                        curr.Children[index] = new Trie();
                    curr = curr.Children[index];
                }
                curr.Word = streamer;
            }
        }

        public List<string> Match(string prefix)
        {
            if (string.IsNullOrWhiteSpace(prefix))
                return new List<string> {"noMatches"};
            var res = new List<string>();
            var curr = _root;
            foreach (var c in prefix)
            {
                int index;
                if (char.IsUpper(c))
                    index = c - 'A';
                else
                    index = c - 'a' + 26;
                if (curr.Children[index] == null)
                    break;
                curr = curr.Children[index];                   
            }
            if (curr != _root)
                Dfs(curr, res);
            return res.Count == 0 ? new List<string>{ "noMatches" } : res;
        }

        private static void Dfs(Trie node, ICollection<string> result)
        {
            if (node == null) return;
            if (!string.IsNullOrWhiteSpace(node.Word))
                result.Add(node.Word);
            foreach (var child in node.Children)
            {
                Dfs(child, result);
            }
        }



        public class Trie
        {
            public string Word { get; set; }
            public Trie[] Children { get; set; }

            public Trie()
            {
                Children = new Trie[51];
            }
        }
    }
}
