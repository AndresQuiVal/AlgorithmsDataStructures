using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructAndAlgorithmsProject1
{
    public class DoubleNode<T> : BaseNode<T>
    {
        public DoubleNode<T> PreviousNode { get; set; }

        //public DoubleNode<T> NextNode { get; set; }

        public DoubleNode(T value) : base(value)
        {}
        public DoubleNode()
        {}
    }
}
