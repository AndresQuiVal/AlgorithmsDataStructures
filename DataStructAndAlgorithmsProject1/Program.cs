using DataStructAndAlgorithmsProject1.Binary_Tree_Data_structure;
using DataStructAndAlgorithmsProject1.Queue_Data_structure;
using DataStructAndAlgorithmsProject1.Stack_Data_structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Threading;

namespace DataStructAndAlgorithmsProject1
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> ll = new LinkedList<int>();
            TimerPerformance tp = new TimerPerformance();

            tp.StartTiming();
            ll.AddNode(1);
            Console.WriteLine($"Time for adding \"1\": {tp.StopTiming()}");
            ll.AddNode(2);
            ll.AddNode(3);
            ll.AddNode(4);
            ll.AddNode(5);
            ll.AddNode(6);
            ll.AddNode(7);
            ll.AddNode(8);
            tp.StartTiming();
            ll.AddNode(9);
            Console.WriteLine($"Time for adding \"9\": {tp.StopTiming()}");
            ll.AddNode(10);
            ll.AddNode(11);
            ll.AddNode(12);
            ll.AddNode(13);
            ll.AddNode(14);
            ll.AddNode(15);
            ll.AddNode(16);
            ll.AddNode(17);
            tp.StartTiming();
            ll.AddNode(18);
            Console.WriteLine($"Time for adding \"18\": {tp.StopTiming()}");

            Console.WriteLine("-------------------------DOUBLY LINKED LISTS-------------");

            var doubleLL = new DoublyLinkedList<int>();
            doubleLL.AddNode(1);
            doubleLL.AddNode(2);
            doubleLL.AddNode(3);
            doubleLL.AddNode(4);
            doubleLL.AddNode(5);
            doubleLL.AddNode(6);
            doubleLL.AddNode(7);
            doubleLL.AddNode(8);
            doubleLL.AddNode(9);
            doubleLL.AddNode(10);
            doubleLL.AddNode(11);
            doubleLL.AddNode(12);
            doubleLL.AddNode(13);
            doubleLL.AddNode(14);
            doubleLL.AddNode(15);
            doubleLL.AddNode(16);
            doubleLL.AddNode(17);
            doubleLL.AddNode(18);
            foreach (var item in doubleLL)
                Console.WriteLine(item);

            Console.WriteLine();

            Console.WriteLine("-----------Previous value of node with value \"3\"------------");
            Console.WriteLine(((DoubleNode<int>)doubleLL.HeadNode.NextNode.NextNode).PreviousNode.Value);

            Console.WriteLine($"\nDeleteAt(3)");
            doubleLL.DeleteAt(3);

            //foreach(var item in doubleLL)
            //    Console.WriteLine(item);

            foreach (var item in doubleLL)
                Console.WriteLine(item);

            Console.WriteLine("\nPrevious node of element at 3rd index: ");
            Console.Write((doubleLL.HeadNode.NextNode.NextNode.NextNode as DoubleNode<int>).PreviousNode.Value);

            Console.WriteLine();
            Console.WriteLine("Merge nodes and multiply values for singly linked list -----------------");
            Console.WriteLine();

            MergeNodesAndMultValues(ll.HeadNode);

            foreach (var item in ll.ReadValues())
                Console.WriteLine(item);

            //Console.WriteLine($"\nValue of the previous node in singly linked list: {ll.HeadNode.NextNode.NextNode.Value}");

            Console.WriteLine("STACK DATA STRUCTURE ----------------------");

            CStack<int> stack = new CStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Push(7);
            stack.Push(8);
            stack.Push(9);
            stack.Push(10);
            stack.Push(11);
            stack.Push(12);

            Console.WriteLine("\ncontinuous .Pop() calls");
            Console.WriteLine();

            foreach (var item in stack)
                Console.WriteLine(item);
            Console.WriteLine();
            stack.Pop();
            foreach (var item in stack)
                Console.WriteLine(item);
            Console.WriteLine();
            stack.Pop();
            foreach (var item in stack)
                Console.WriteLine(item);
            Console.WriteLine();
            stack.Pop();
            foreach (var item in stack)
                Console.WriteLine(item);

            Console.WriteLine("\nSTACK DATA STRUCTURE WITH LINKED LIST ----------------------");

            LLStack<int> llStack = new LLStack<int>();
            llStack.Push(1);
            llStack.Push(2);
            llStack.Push(3);
            llStack.Push(4);
            llStack.Push(5);
            llStack.Push(6);
            llStack.Push(7);
            llStack.Push(8);
            llStack.Push(9);
            llStack.Push(10);

            Console.WriteLine("Read llStack values----------");
            Console.WriteLine();

            foreach (var item in llStack)
                Console.WriteLine(item);

            Console.WriteLine("llStack.Pop()");
            llStack.Pop();

            foreach (var item in llStack)
                Console.WriteLine(item);

            Console.WriteLine("llStack.Pop()");
            llStack.Pop();

            foreach (var item in llStack)
                Console.WriteLine(item);

            Console.WriteLine("llStack.Push(11)");
            llStack.Push(11);

            foreach (var item in llStack)
                Console.WriteLine(item);

            Console.WriteLine();
            Console.WriteLine("Intersecting node------");

            LinkedList<int> l1 = new LinkedList<int>(), l2 = new LinkedList<int>();
            l1.AddNode(1);
            l1.AddNode(2);
            l1.AddNode(3);
            l1.AddNode(4);
            l1.AddNode(7);
            l1.AddNode(8);
            l1.AddNode(9);
            l2.AddNode(2);
            l2.AddNode(4);
            Console.WriteLine(LinkedList<int>.FindIntesectingNode(l1, l2));

            l1.GetNthReverseNode(1);
            foreach (var item in l1)
                Console.WriteLine(item);


            //QUEUE
            //Console.WriteLine("\nQUEUE DATA STRUCTURE USAGE\n");
            //CQueue<int> queue = new CQueue<int>();
            //queue.Enqueue(1);
            //queue.Enqueue(3);
            //queue.Enqueue(2);
            //queue.Enqueue(4);
            //queue.Enqueue(5);
            //queue.Enqueue(6);
            //queue.Enqueue(7);
            //queue.Enqueue(8);
            //queue.Enqueue(7);
            //queue.Dequeue();
            //queue.Dequeue();
            //queue.Enqueue(9);
            //queue.Enqueue(10);
            //queue.Enqueue(11);
            //foreach (var item in queue)
            //    Console.WriteLine(item);

            //Console.WriteLine("queue.Dequeue() * 3");
            //Console.WriteLine($"ITEM REMOVED: {queue.Dequeue()}");
            //Console.WriteLine($"ITEM REMOVED: {queue.Dequeue()}");
            //Console.WriteLine($"ITEM REMOVED: {queue.Dequeue()}");
            //Console.WriteLine($"ITEM REMOVED: {queue.Dequeue()}");
            //Console.WriteLine($"ITEM REMOVED: {queue.Dequeue()}");
            //Console.WriteLine($"ITEM REMOVED: {queue.Dequeue()}");
            //Console.WriteLine($"ITEM REMOVED: {queue.Dequeue()}");
            //Console.WriteLine($"ITEM REMOVED: {queue.Dequeue()}");
            //Console.WriteLine($"ITEM REMOVED: {queue.Dequeue()}");
            //Console.WriteLine($"ITEM REMOVED: {queue.Dequeue()}");
            //Console.WriteLine($"ITEM REMOVED: {queue.Dequeue()}");
            //Console.WriteLine($"ITEM REMOVED: {queue.Dequeue()}");
            //Console.WriteLine($"ITEM REMOVED: {queue.Dequeue()}");

            //Console.WriteLine($"\nqueue.IsEmpty(): {queue.IsEmpty()}");
            //foreach (var item in queue)
            //    Console.WriteLine(item);


            //Console.WriteLine("LLQueue USAGE----------------\n");
            //LLQueue<int> queue2 = new LLQueue<int>();
            //queue2.Enqueue(1);
            //queue2.Enqueue(2);
            //queue2.Enqueue(3);
            //queue2.Enqueue(4);
            //queue2.Enqueue(5);
            //queue2.Enqueue(6);
            //queue2.Enqueue(7);
            //queue2.Enqueue(8);
            //queue2.Enqueue(9);
            //Console.WriteLine();
            //queue2.PrintElems();
            //Console.WriteLine();
            //queue2.Dequeue();
            //queue2.Dequeue();
            //queue2.PrintElems();
            //Console.WriteLine();
            //queue2.Enqueue(10);
            //queue2.PrintElems();

            //BST
            Console.WriteLine("Binary Search Tree in ACTION!----------");
            BinarySearchTree bst = new BinarySearchTree();
            //bst.AddNode(6);
            //bst.AddNode(3);
            //bst.AddNode(9);
            //bst.AddNode(1);
            //bst.AddNode(8);
            //bst.AddNode(4);
            //bst.AddNode(10);    ITERATIVE APROACH, BETTER

            bst.AddNodeRecursive(6);
            bst.AddNodeRecursive(3);
            bst.AddNodeRecursive(9);
            bst.AddNodeRecursive(1);
            bst.AddNodeRecursive(8);
            bst.AddNodeRecursive(4);
            bst.AddNodeRecursive(10);
            bst.AddNodeRecursive(7);

            Console.Write("\nbst.ExistNode(4)? -> ");
            Console.WriteLine(bst.ExistNode(4));

            tp.StartTiming();
            Console.Write("\nbst.ExistNode(11)? -> ");
            Console.WriteLine(bst.ExistNode(11));
            Console.WriteLine($"TIME TAKEN IN ExistNode() OPERATION: {tp.StopTiming()}"); 

            Console.Write("\nbst.ExistNode(10)? -> ");
            Console.WriteLine(bst.ExistNode(10));


            //USE OF BFS AND DFS ALGORITHMS TO TRAVERSE THE TREE
            Console.WriteLine("using BFS and DFS ---------------------------");
            List<int> bfs = new List<int>();
            bst.TraverseDFSPreorder(bfs, bst.Root);
            foreach (var item in bfs)
                Console.WriteLine(item);
            Console.WriteLine();
            bfs.Clear();
            bst.TraverseDFSPreorderIterative(bfs);
            foreach (var item in bfs)
                Console.WriteLine(item);

            Console.WriteLine("\nGiven a BT, return the sum of all the depths for all the nodes in it\nSOLUTION");
            BinarySearchTree bst2 = new BinarySearchTree();
            bst2.AddNode(4);
            bst2.AddNode(2);
            bst2.AddNode(6);
            bst2.AddNode(1);
            bst2.AddNode(3);
            bst2.AddNode(7);
            bst2.AddNode(5);

            Console.WriteLine(bst2.SumDepths());

            BSTNode<int> rootNode = new BSTNode<int>(5);
            rootNode.LeftRoot = new BSTNode<int>(3);
            rootNode.RightRoot = new BSTNode<int>(8);
            rootNode.RightRoot.LeftRoot = new BSTNode<int>(7);
            rootNode.RightRoot.RightRoot = new BSTNode<int>(9);
            rootNode.LeftRoot.RightRoot = new BSTNode<int>(4);
            rootNode.LeftRoot.LeftRoot = new BSTNode<int>(2);

            Console.WriteLine($"\nIs Binary Search Tree the following tree?: {bst2.IsBST(rootNode)}");

            Console.WriteLine($"\nBinarySearchTreee.GetPredecessor(4): {bst2.GetPredecessor(4).Value}");
            Console.WriteLine($"\nBinarySearchTreee.GetSucessor(3): {bst2.GetSuccesor(3).Value}");

            Console.WriteLine("\nBinarySearchTree.DeleteNode(6)");
            bst2.DeleteNode(bst2.Root, 6);

            bst2.AddNode(6);
            Console.WriteLine("\nBinarySearchTree.DeleteNodeMCD(6)");
            bst2.DeleteNodeMCD(bst2.Root, 6);

            bst2.AddNode(6);
        }
        public enum LRSelection { Left, Right };

        public static void QuickSort(List<int> list, int[] input, int _index, int pivot)
        {
            if (list.Count == 1)
            {
                input[_index++] = list[0];
                return;
            }
            else if (list.Count == 2)
            {
                input[_index++] = list[0] < list[1] ? list[0] : list[1];
                list.Remove(input[_index - 1]);
                input[_index++] = list[0];
                return;
            }
            pivot = list.Count > 0 ? list[list.Count / 2] : pivot;
            list = list.Count == 0 ? input.ToList() : list;
            for (int i = 0; i < 2; i++)
            {
                var selection = i == 0 ? LRSelection.Left : LRSelection.Right;
                var listNew = GetLRElems(selection, list, pivot);
                QuickSort(listNew, input, _index, pivot);
            }
        }

        public static List<int> GetLRElems(LRSelection selectionType, List<int> list, int pivot)
        {
            var outputList = new List<int>();
            foreach (var item in list)
                if (CheckCondition(selectionType, item, pivot))
                    outputList.Add(item);
            return outputList;
        }

        public static bool CheckCondition(LRSelection selectionType, int n, int n2)
        {
            return selectionType == LRSelection.Left ? n <= n2 : n > n2;
        }

        public static void MergeNodesAndMultValues(Node<int> HeadNode)
        {
            if (HeadNode?.NextNode == null) return;

            var refNode = HeadNode;

            while (refNode != null && refNode.NextNode != null)
            {
                refNode.Value = Convert.ToInt32(refNode.Value) *
                                    Convert.ToInt32(refNode.NextNode.Value); // [15, x] -> [5, y] -> null 
                refNode.NextNode = refNode.NextNode.NextNode; // [15, x] -> null
                refNode = (Node<int>)refNode.NextNode;
            }

        }
    }
}
