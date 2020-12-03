using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DotNet2020.Yamaxun
{
    class TopKFrequent
    {
//        public List<int> topKFrequent(string[] words, int k)
//        {
//            var count = new Dictionary<string, int>();
//            foreach (var word in words)
//            {
//                count[word] = count.ContainsKey(word) ? count[word] + 1 : 1;
//            }
//            PriorityQueue<string> heap = new PriorityQueue<string>(
//                (w1, w2)->count.get(w1).equals(count.get(w2)) ?
//                    w2.compareTo(w1) : count.get(w1) - count.get(w2));
//
//            foreach (var word in count.Keys)
//            {
//                heap.offer(word);
//                if (heap.size() > k) heap.poll();
//            }
//
//            var ans = new List<int>();
//            while (!heap.isEmpty()) ans.Add(heap.poll());
//            ans.Reverse();
//            return ans;
//        }
    }
}
