using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructAndAlgorithmsProject1
{

    public class LinkedList<T> : IEnumerable
    {
        public Node<T> HeadNode;

        #region Add nodes
        public void AddNode(T elem)
        {
            if (HeadNode == null)
            {
                Node<T> newNode = new Node<T>();
                newNode.Value = elem;
                HeadNode = newNode;
                return;
            }

            Node<T> referenceNode = HeadNode;
            while (true)
            {
                if (referenceNode.NextNode == null)
                {
                    var newNode = new Node<T>(elem);
                    referenceNode.NextNode = newNode;
                    break;
                }
                referenceNode = (Node<T>)referenceNode.NextNode;
            }
        }

        public void InsertNodeAtIndex(int index, T value)
        {
            if (index < 0) return;
            else if (index  == 0)
            {
                var node = new Node<T>(value);
                node.NextNode = HeadNode;
                HeadNode = node;
                return;
            }

            var refNewNode = HeadNode;
            for(int i = 0; i < index - 1; i++)
                refNewNode = (Node<T>)refNewNode.NextNode;

            var newNode = new Node<T>(value);
            newNode.NextNode = refNewNode.NextNode;
            refNewNode.NextNode = newNode;
        }
        #endregion

        #region Delete nodes
        public void DeleteNode0thIndex(int index)
        {
            if (index == 0)
            {
                HeadNode = (Node<T>)HeadNode.NextNode;
                return;
            }
            var refNode = HeadNode;
            for (int i = 1; i < index; i++)
            {
                refNode = (Node<T>)refNode.NextNode;
            }
            refNode.NextNode = refNode.NextNode.NextNode;
        }

        public void DeleteNode1thIndex(int index)
        {
            if (index == 1)
            {
                HeadNode = (Node<T>)HeadNode.NextNode;
                return;
            }
            var refNode = HeadNode;
            for (int i = 0; i < index - 2; i++)
            {
                refNode = (Node<T>)refNode.NextNode;
            }
            refNode.NextNode = refNode.NextNode.NextNode;
        }
        #endregion

        #region Read nodes in LinkedList
        public IEnumerable<T> ReadValues()
        {
            List<T> values = new List<T>();
            Node<T> node = HeadNode; // referenceNode
            while (true)
            {
                if (node == null)
                    break;
                values.Add(node.Value);
                node = (Node<T>)node.NextNode;
            }
            return values;
        }
        #endregion

        #region Reverse of linked lists
        public void ReverseIterativeLinkedList()
        {
            Node<T> currentNode = HeadNode, previousNode = null, nextNode = HeadNode;
            while (currentNode != null)
            {
                nextNode = (Node<T>)nextNode.NextNode;
                currentNode.NextNode = previousNode;
                previousNode = currentNode;
                currentNode = nextNode;
            }
            HeadNode = previousNode;
        }

        public void ReverseRecursiveLinkedList()
        {
            Node<T> currentNode = HeadNode, previousNode = null, nextNode = (Node<T>)HeadNode.NextNode;
            ReverseNodes(previousNode, currentNode, nextNode);
        }

        private void ReverseNodes(
            BaseNode<T> previousNode, BaseNode<T> currentNode, BaseNode<T> nextNode)
        {
            currentNode.NextNode = previousNode;
            if (nextNode == null) // nextNode represents nextNode, not currenNode
            {
                HeadNode = (Node<T>)currentNode;
                return;
            }
            ReverseNodes(currentNode, nextNode, nextNode.NextNode);
            //in other words, the recursive call means, previousNode = currentNode,
            //currentNode = nextNode, nextNode = nextNode.Next
        }

        public void ReverseLinkedListMyCodeSchool()
        {
            ReverseNodesMyCodeSchool(HeadNode);
        }

        private void ReverseNodesMyCodeSchool(BaseNode<T> node)
        {
            if (node.NextNode == null)
            {
                HeadNode = (Node<T>)node;
                return;
            }
            ReverseNodesMyCodeSchool(node.NextNode);
            node.NextNode.NextNode = node; // var nextNode = node.NextNode, nextNode.Next = node
            node.NextNode = null;
        }
        #endregion

        #region Print linked list
        public void PrintReverse(BaseNode<T> node) // recursive aproach
        {
            if (node == null)
                return;
            PrintReverse(node.NextNode);
            Console.WriteLine(node.Value);
        }

        public void PrintReverse() // not eve aproach
        {
            var referenceNode = HeadNode;
            var reverseStack = new Stack<T>();
            while (referenceNode != null)
            {
                reverseStack.Push(referenceNode.Value);
                referenceNode = (Node<T>)referenceNode.NextNode;
            }
            foreach (var item in reverseStack)
                Console.WriteLine(item);
        }
        #endregion

        #region Change nodes
        public void ChangeNodes()
        {
            if (HeadNode.NextNode == null) return;
            Node<T> refCurrent = HeadNode, refPointer = HeadNode,  refNodebyNode = HeadNode;
            for (int i = 1; refCurrent != null && refCurrent.NextNode != null; i++)
            {
                refPointer = (Node<T>)refPointer.NextNode.NextNode;
                refCurrent.NextNode.NextNode = refCurrent;

                if (i == 1) HeadNode = (Node<T>)refCurrent.NextNode;
                else refNodebyNode.NextNode = refCurrent.NextNode;
                
                refCurrent.NextNode = refPointer;
                
                refCurrent = refPointer;

                if (i != 1) refNodebyNode = (Node<T>)refNodebyNode.NextNode.NextNode;
            }
        }

        public IEnumerator GetEnumerator() => this.ReadValues().GetEnumerator();
        #endregion

        #region Coding problems
        public static int FindIntesectingNode( // aproach 1 SUPER BAD APPROACH
            LinkedList<int> l1, LinkedList<int> l2)
        {
            var elem = FindIntersectForLast(l1, l2);
            if (elem != -1) return elem;

            var refNode = l1.HeadNode;
            int intersectingNodeValue1 = -1, intersectingNodeValue2 = -1;
            while (refNode.NextNode != null)
            {
                if(FindForSecondLinkedList(refNode, refNode.NextNode as Node<int>, l2) && intersectingNodeValue1 == -1)
                    intersectingNodeValue1 = refNode.Value;
                refNode = refNode.NextNode as Node<int>;
            }

            refNode = l2.HeadNode;
            while (refNode.NextNode != null)
            {
                if (FindForSecondLinkedList(refNode, refNode.NextNode as Node<int>, l1) && intersectingNodeValue2 == -1)
                    intersectingNodeValue2 = refNode.Value;
                refNode = refNode.NextNode as Node<int>;
            }

            return intersectingNodeValue1 == intersectingNodeValue2 ?
                intersectingNodeValue1 : -1;
        }

        private static bool FindForSecondLinkedList(
            Node<int> node1, Node<int> node2, LinkedList<int> l2)
        {
            var refNode = l2.HeadNode;
            while(refNode.NextNode != null)
            {
                if (refNode.Value == node1.Value && refNode.NextNode.Value == node2.Value)
                    return true;
                refNode = refNode.NextNode as Node<int>;
            }
            return false;
        }

        private static int FindIntersectForLast(LinkedList<int> l1, LinkedList<int> l2)
        {
            var last = l1.ReadValues().ElementAt(l1.ReadValues().Count() - 1);
            return l2.ReadValues().ElementAt(l2.ReadValues().Count() - 1) == last ?
                last : -1;
        }

        public void GetNthReverseNode(int reverseIndex)
        {
            var refPointer = HeadNode;
            int counter = 0;
            ReverseLinkedListToNthNode(refPointer as Node<int>, ref counter, reverseIndex);
        }

        private void ReverseLinkedListToNthNode(
            Node<int> refPointer, ref int counter, int elementAt) // counter = 0 initial value
        {
            if (refPointer == null)
                return;
            
            ReverseLinkedListToNthNode(refPointer.NextNode as Node<int>, ref counter, elementAt);
            
            counter++;
            if (elementAt == (counter - 1))
                refPointer.NextNode = refPointer.NextNode.NextNode;
        }
        #endregion
    }
}
