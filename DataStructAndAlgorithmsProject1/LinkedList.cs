using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructAndAlgorithmsProject1
{

    public class LinkedList<T>
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
                referenceNode = referenceNode.NextNode;
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
                refNewNode = refNewNode.NextNode;

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
                HeadNode = HeadNode.NextNode;
                return;
            }
            var refNode = HeadNode;
            for (int i = 1; i < index; i++)
            {
                refNode = refNode.NextNode;
            }
            refNode.NextNode = refNode.NextNode.NextNode;
        }

        public void DeleteNode1thIndex(int index)
        {
            if (index == 1)
            {
                HeadNode = HeadNode.NextNode;
                return;
            }
            var refNode = HeadNode;
            for (int i = 0; i < index - 2; i++)
            {
                refNode = refNode.NextNode;
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
                node = node.NextNode;
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
                nextNode = nextNode.NextNode;
                currentNode.NextNode = previousNode;
                previousNode = currentNode;
                currentNode = nextNode;
            }
            HeadNode = previousNode;
        }

        public void ReverseRecursiveLinkedList()
        {
            Node<T> currentNode = HeadNode, previousNode = null, nextNode = HeadNode.NextNode;
            ReverseNodes(previousNode, currentNode, nextNode);
        }

        private void ReverseNodes(
            Node<T> previousNode, Node<T> currentNode, Node<T> nextNode)
        {
            currentNode.NextNode = previousNode;
            if (nextNode == null) // nextNode represents nextNode, not currenNode
            {
                HeadNode = currentNode;
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

        private void ReverseNodesMyCodeSchool(Node<T> node)
        {
            if (node.NextNode == null)
            {
                HeadNode = node;
                return;
            }
            ReverseNodesMyCodeSchool(node.NextNode);
            node.NextNode.NextNode = node; // var nextNode = node.NextNode, nextNode.Next = node
            node.NextNode = null;
        }
        #endregion

        #region Print linked list
        public void PrintReverse(Node<T> node) // recursive aproach
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
                referenceNode = referenceNode.NextNode;
            }
            foreach (var item in reverseStack)
                Console.WriteLine(item);
        } 
        #endregion
    }
}
