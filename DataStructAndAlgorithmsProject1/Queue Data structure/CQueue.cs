using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructAndAlgorithmsProject1.Queue_Data_structure
{
    public class CQueue<T> : IEnumerable
    {
        private T[] elems = new T[10];
        private int front = -1, rear = -1;


        public void Enqueue(T elem)
        {
            rear = (rear + 1) % elems.Length;
            elems[rear] = elem;
            if (rear == front)
                return;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                if(front != 0 && rear != -1)
                {
                    front = 0;
                    rear = -1;
                }
                throw new NotImplementedException();
            }
            front = (front + 1) % elems.Length;
            return elems[front];
        }

        public T Peek() => IsEmpty() ? throw new NotImplementedException() : elems[rear];

        public bool IsEmpty() => front > rear;

        private void ExpandArraySize()
        {
            var newArr = new T[elems.Length * 2];
            for (int i = 0; i < elems.Length; i++)
                newArr[i] = elems[i];
            elems = newArr;
        }

        public void PrintElems()
        {
        }

        IEnumerator IEnumerable.GetEnumerator() => elems.Skip(front).Take((rear + 1) - front).ToArray().GetEnumerator();
    }
}
