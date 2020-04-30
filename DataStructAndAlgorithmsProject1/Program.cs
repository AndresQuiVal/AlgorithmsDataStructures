using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace DataStructAndAlgorithmsProject1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(node.ToString());
            //Console.WriteLine(node.GetHashCode());

            //Node<string> node2 = new Node<string>();
            //node2.Value = "holaMundo";
            //node2.Value2 = "holaMundo2";
            //Console.WriteLine(node2.ToString());
            //Console.WriteLine(node2.GetHashCode());

            //Console.WriteLine(node == node2);

            //

            //Node<string> node1 = node;
            //node1.Value = "Andres";
            //Console.WriteLine(node1.FullValues);

            //Console.WriteLine(node.Value);

            //List<int> output = new List<int>();
            //int[] input = new int[] { 6, 2, 4, 1, 3 };
            //QuickSort(output, input, 0, 4);

            //foreach (var item in input)
            //    Console.WriteLine(item);

            LinkedList<int> ll = new LinkedList<int>();
            ll.AddNode(5);
            ll.AddNode(3);
            ll.AddNode(7);
            foreach(var item in ll.ReadValues())
                Console.WriteLine(item);

            Console.WriteLine();
            Console.WriteLine();

            ll.DeleteNode0thIndex(1);
            foreach (var item in ll.ReadValues())
                Console.WriteLine(item);

            ll.InsertNodeAtIndex(5, 3);
            foreach (var item in ll.ReadValues())
                Console.WriteLine(item);
            //ll.ReverseLinkedListMyCodeSchool();
            //foreach (var item in ll.ReadValues())
            //    Console.WriteLine(item);
            //ll.PrintReverse();
            //ll.PrintReverse(ll.HeadNode);
        }

        //public static ref node<string> modvalues(ref node<string> node)
        //{
        //    ref node<string> nodestring = ref node;
        //    nodestring.value = "andres";
        //    nodestring.value2 = "quiroz valdovinos";
        //    return ref nodestring;
        //}

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
    }
}
