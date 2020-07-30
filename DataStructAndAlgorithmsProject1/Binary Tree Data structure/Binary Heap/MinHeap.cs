using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
using System.Xml.XPath;

namespace DataStructAndAlgorithmsProject1.Binary_Tree_Data_structure.Binary_Heap
{
    public class MinHeap : IEnumerable
    {
        //private HeapNode head, lastInserted;

        private int[] nodes;
        private int size;

        public MinHeap(int len)
        {
            nodes = new int[len];
        }

        private int GetLeftChild(int index) => (2 * index) + 1;
        private int GetRightChild(int index) => (2 * index) + 2;
        private int GetParentIndex(int index) => (index - 1) / 2;
        private bool HasParent(int index) => GetParentIndex(index) >= 0;
        private bool HasLeftChild(int index) => GetLeftChild(index) < size;
        private bool HasRightChild(int index) => GetRightChild(index) < size;


        public int Peek() => nodes[0];

        private void SwapNodeValues(int index1, int index2)
        {
            int temp = nodes[index1];
            nodes[index2] = nodes[index1];
            nodes[index1] = temp;
        } 

        private void ExtendHeapSize()
        {
            int[] temp = new int[nodes.Length * 2];
            for (int i = 0; i < nodes.Length; i++)
                temp[i] = nodes[i];

            nodes = temp;
        }

        public void Insert(int value)
        {
            if (size == nodes.Length)
                ExtendHeapSize();
            nodes[size++] = value;
            HeapifyUp();
        }

        public void Remove()
        {
            if (size == 0) throw new InvalidOperationException();
            nodes[0] = nodes[--size];
            HeapifyDown();
        }

        private void HeapifyUp()
        {
            if (size == 0 || !HasParent(size - 1))
                throw new InvalidOperationException();
            int parent = GetParentIndex(size - 1), index = size - 1;

            while (parent >= 0 && nodes[index] < nodes[parent])
            {
                int temp = nodes[index];
                nodes[index] = nodes[parent];
                nodes[parent] = temp;

                index = parent;
                parent = GetParentIndex(index);
            }
        }

        private void HeapifyDown()
        {
            if (size == 0 || !HasParent(size - 1))
                throw new InvalidOperationException();

            int index = 0, left = GetLeftChild(index);
            while (HasLeftChild(index))
            {
                int smallerIndex = left, rightIndex = GetRightChild(index);
                if (HasRightChild(index) && nodes[rightIndex] < nodes[left])
                    smallerIndex = rightIndex;

                if (nodes[index] < nodes[smallerIndex])
                    break;

                int temp = nodes[smallerIndex];
                nodes[smallerIndex] = nodes[index];
                nodes[index] = temp;

                index = smallerIndex;
                left = GetLeftChild(index);
            }
        }

        public IEnumerator GetEnumerator() =>
            nodes.Take(size).ToArray().GetEnumerator();




        /*public void Insert(int value)
        {
            if (head == null)
            {
                head = new HeapNode(value);
                lastInserted = head;
                return;
            }

            if (lastInserted.Parent == null)
            {
                // is head node
                var node = new HeapNode(value);
                node.Parent = head;
                lastInserted.Left = node;
                lastInserted = node;
                return;
            }

            var refNode = lastInserted;
            while (refNode.Parent != null && refNode == refNode.Parent.Right)
                refNode = refNode.Parent;

            if (refNode.Parent != null)
            {
                refNode = refNode.Parent;
                if (refNode.Right == null)
                {
                    refNode.Right = new HeapNode(value);
                    refNode.Right.Parent = refNode;
                    lastInserted = refNode.Right;
                    return;
                }

                refNode = refNode.Right;
            }

            while (refNode.Left != null)
                refNode = refNode.Left;

            refNode.Left = new HeapNode(value);
            lastInserted = refNode.Left;
            lastInserted.Parent = refNode;
        }*/
    }
}
