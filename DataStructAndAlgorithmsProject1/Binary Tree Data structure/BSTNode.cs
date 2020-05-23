using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructAndAlgorithmsProject1.Binary_Tree_Data_structure
{
    public class BSTNode<T>
    {
        public BSTNode<T> LeftRoot { get; set; }
        public BSTNode<T> RightRoot { get; set; }
        public T Value { get; set; }
        public BSTNode(T _value) => this.Value = _value; 
    }
}
