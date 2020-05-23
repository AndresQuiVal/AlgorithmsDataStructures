using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataStructAndAlgorithmsProject1.Stack_Data_structure
{
    public class CStack<T> : IEnumerable
    {
        private T[] stackArray;
        private int currentIndex;

        public T Peek => stackArray[stackArray.Length - 1];

        public CStack()
        {
            currentIndex = 0;
            stackArray = new T[10];
        }

        public void Push(T value)
        {
            if (currentIndex == stackArray.Length)
                ExpandArraySize();

            stackArray[currentIndex++] = value;
        }

        public void Pop()
        {
            if (currentIndex == 0)
                throw new Exception("No element is on the stack", new ArgumentException());
            --currentIndex;
        }

        private void ExpandArraySize() // O(n) time, O(n) space
        {
            var stackArray2 = new T[stackArray.Length * 2];
            for (int i = 0; i < stackArray.Length; i++)
                stackArray2[i] = stackArray[i];
            stackArray = stackArray2;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return stackArray.Take(currentIndex).ToArray().GetEnumerator();
        }
    }
}
