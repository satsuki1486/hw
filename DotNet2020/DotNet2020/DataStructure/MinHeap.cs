using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet2020.DataStructure
{
    public class MinHeap
    {
        private List<int> _data;
        public MinHeap()
        {
            _data = new List<int>();
        }

        public MinHeap(List<int> data)
        {
            _data = data;
        }

        public void Push(int key)
        {
            _data.Add(key);
            HeapifyUp(_data.Count - 1);
        }

        public void HeapifyUp(int index)
        {
            if (index == 0) return;
            var parent = (index - 1) / 2;
            if (_data[index] >= _data[parent])
                return;
            Swap(index, parent);
            HeapifyUp(parent);
        }

        public void Swap(int i, int j)
        {
            var temp = _data[i];
            _data[i] = _data[j];
            _data[j] = temp;
        }

        public int Pop()
        {
            Swap(_data.Count - 1, 0);
            var min = _data[_data.Count - 1];
            _data.RemoveAt(_data.Count - 1);
            HeapifyDown(0);
            return _data[0];
        }

        public void HeapifyDown(int index)
        {
            var smallest = index;
            var children = new int[] { index * 2 + 1, index * 2 + 2 };
            foreach (var c in children)
            {
                if (c < _data.Count && _data[c] < _data[smallest])
                    smallest = c;
            }

            if (smallest == index) return;
            Swap(index, smallest);
            HeapifyDown(smallest);
        }
    }
}
