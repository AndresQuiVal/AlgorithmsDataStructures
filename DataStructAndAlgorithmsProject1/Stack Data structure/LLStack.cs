using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructAndAlgorithmsProject1.Stack_Data_structure
{
    public class LLStack<T> : IEnumerable
    {
        private LinkedList<T> linkedList;

        public LLStack() =>
            linkedList = new LinkedList<T>();

        public void Push(T value)
        {
            if (linkedList.HeadNode == null)
            {
                linkedList.HeadNode = new Node<T>(value);
                return;
            }

            var refNode = linkedList.HeadNode;
            while (refNode.NextNode != null)
                refNode = refNode.NextNode as Node<T>;

            refNode.NextNode = new Node<T>(value);
        }

        public T Peek()
        {
            var refNode = linkedList.HeadNode;
            while (refNode.NextNode != null)
                refNode = refNode.NextNode as Node<T>;
            return refNode.Value;
        }

        public void Pop()
        {
            if(linkedList.HeadNode.NextNode == null)
            {
                linkedList.HeadNode = null;
                return;
            }

            var refNode = linkedList.HeadNode;
            while (refNode.NextNode.NextNode != null)
                refNode = refNode.NextNode as Node<T>;
            refNode.NextNode = null;
        }

        IEnumerator IEnumerable.GetEnumerator() => linkedList.GetEnumerator();
    }
}
