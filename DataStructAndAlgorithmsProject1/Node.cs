using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructAndAlgorithmsProject1
{
    public class Node<T>
    {
        public T Value;
        public Node<T> NextNode;

        public Node(T value) => Value = value;
        public Node() { }
    }
}
