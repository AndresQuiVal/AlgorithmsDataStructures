using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructAndAlgorithmsProject1.Queue_Data_structure
{
    public class LLQueue<T>
    {
        Node<T> head, tail;

        public T Dequeue()
        {
            T _val;
            if (head == null)
                _val = default;
            else if(head.NextNode == null)
            {
                _val = head.Value;
                head = tail = null;
            }
            else
            {
                _val = head.Value;
                head = head.NextNode as Node<T>;
            }
            return _val;
        }

        public void Enqueue(T x)
        {
            if(head == null)
            {
                head = new Node<T>(x);
                tail = head;
                return;
            }
            tail.NextNode = new Node<T>(x);
            tail = tail.NextNode as Node<T>;
        }

        public bool IsEmpty() => tail == null && head == null;

        public T Peek()
        {
            if (head == null)
                return default;
            return head.Value;
        }

        public void PrintElems()
        {
            var refNode = head;
            while(refNode != null)
            {
                Console.WriteLine(refNode.Value);
                refNode = refNode.NextNode as Node<T>;
            }
        }
    }
}
