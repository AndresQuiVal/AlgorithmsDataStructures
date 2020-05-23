using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructAndAlgorithmsProject1
{
    public abstract class BaseNode<T>
    {
        public T Value { get; set; }
        public /*virtual*/ BaseNode<T> NextNode { get; set; }


        public BaseNode(T value) => this.Value = value;

        public BaseNode()
        {
        }
    }
}
