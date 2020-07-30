using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructAndAlgorithmsProject1.Binary_Tree_Data_structure.Binary_Heap
{
    public class HeapNode
    {
        public int Value { get; set; }
        public HeapNode Parent { get; set; }
        public HeapNode Left { get; set; }
        public HeapNode Right { get; set; }

        public HeapNode(int value, HeapNode left, HeapNode right, HeapNode parent)
        {
            this.Left = left;
            this.Right = right;
            this.Parent = parent;
            this.Value = value;
        }

        public HeapNode(int value) => this.Value = value;

        public HeapNode()
        {
        }
    }
}
