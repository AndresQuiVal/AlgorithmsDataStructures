using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructAndAlgorithmsProject1
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        public DoubleNode<T> HeadNode { get; set; }
        
        #region Add nodes
        public void AddNode(T value)
        {
            DoubleNode<T> newNode = new DoubleNode<T>(value);
            if (HeadNode == null)
            {
                HeadNode = newNode;
                return;
            }
            var refNode = HeadNode;
            
            while(refNode.NextNode != null) refNode = (DoubleNode<T>)refNode.NextNode;

            newNode.PreviousNode = refNode;
            refNode.NextNode = newNode;
        }
        #endregion

        #region Read node values
        public IEnumerable<T> ReadNodeValues() 
        {
            if (HeadNode == null)
                return Enumerable.Empty<T>();

            var list = new List<T>();
            var refNode = HeadNode;
            while (refNode != null)
            {
                list.Add(refNode.Value);
                refNode = refNode.NextNode as DoubleNode<T>;
            }

            return list;
        }
        #endregion

        #region Delete node
        public void DeleteAt(int index) // 0th index
        {
            if(index == 0)
            {
                (HeadNode.NextNode as DoubleNode<T>).PreviousNode = null;
                HeadNode = (DoubleNode<T>) HeadNode.NextNode;
                return;
            }

            var refNode = HeadNode;
            for (int i = 0; i < index - 1; i++)
                refNode = refNode.NextNode as DoubleNode<T>;

            refNode.NextNode = refNode.NextNode.NextNode;
            (refNode.NextNode as DoubleNode<T>).PreviousNode = refNode;
        }
        #endregion
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ReadNodeValues().GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ReadNodeValues().GetEnumerator();
        }
    }
}
