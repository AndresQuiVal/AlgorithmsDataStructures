using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructAndAlgorithmsProject1.Binary_Tree_Data_structure
{
    public class BinarySearchTree
    {
        public BSTNode<int> Root { get; set; }

        #region Add nodes in BST
        public void AddNode(int x) // iterative solution
        {
            if(Root == null)
            {
                Root = new BSTNode<int>(x);
                return;
            }
            var refNode = Root;
            while (true)
            {
                if(x <= refNode.Value)
                {
                    if (refNode.LeftRoot == null)
                    {
                        refNode.LeftRoot = new BSTNode<int>(x);
                        return;
                    }
                    refNode = refNode.LeftRoot;
                }
                else
                {
                    if(refNode.RightRoot == null)
                    {
                        refNode.RightRoot = new BSTNode<int>(x);
                        return;
                    }
                    refNode = refNode.RightRoot;
                }
            }
        }

        public void AddNodeRecursive(int x)
        {
            var refNode = Root;
            Root = AddNode(x, refNode);
        }

        private BSTNode<int> AddNode(int x, BSTNode<int> refNode) // Recursive method
        {
            if(refNode == null) return new BSTNode<int>(x);

            if (x > refNode.Value)
                refNode.RightRoot = AddNode(x, refNode.RightRoot);
            else refNode.LeftRoot = AddNode(x, refNode.LeftRoot);
            return refNode;
        }
        #endregion

        #region Search node 
        //O(log(n))

        public bool ExistNodeRecursive(int x) // recursive approach
        {
            var refNode = Root;
            return ExistNode(x, refNode);
        }

        private bool ExistNode(int x, BSTNode<int> refNode)
        {
            if (refNode == null) return false;
            else if (x == refNode.Value) return true;

            bool result;
            if (x > refNode.Value) result = ExistNode(x, refNode.RightRoot);
            else result = ExistNode(x, refNode.LeftRoot);
            return result;
        }

        public bool ExistNode(int x)
        {
            if (Root == null) return false;
            var refNode = Root;
            while (true)
            {
                if (x <= refNode.Value) refNode = refNode.LeftRoot; 
                else refNode = refNode.RightRoot;

                if (refNode == null) return false;
                else if (x == refNode.Value) return true;
            }
        }
        #endregion

        #region Max() and Min() in BST
        public int Max(BSTNode<int> node) // recursive
        {
            if (node.RightRoot == null) return node.Value;
            return Max(node.RightRoot);
        }

        public int Min(BSTNode<int> node) // recursive
        {
            if (node.LeftRoot == null) return node.Value;
            return Min(node.LeftRoot);
        }

        public int Max() // iterative
        {
            BSTNode<int> refNode = Root;
            while (refNode.RightRoot != null) refNode = refNode.RightRoot;
            return refNode.Value;
        }

        public int Min() // iterative
        {
            BSTNode<int> refNode = Root;
            while (refNode.LeftRoot != null) refNode = refNode.LeftRoot;
            return refNode.Value;
        }
        #endregion

        #region Find Height of BST
        public int GetHeight(BSTNode<int> node) // recursive
        {
            if (node.RightRoot == null && node.LeftRoot == null) return 0;
            return Math.Max(GetHeight(node.LeftRoot), GetHeight(node.RightRoot)) + 1; // +1 FOR THE INCOMING EDGE POINTING TO THE CURRENT NODE
        }
        #endregion

        #region Traverse BST using BFS and DFS
        public void TraverseBFS(List<int> nums)
        {
            Queue<BSTNode<int>> bfs = new Queue<BSTNode<int>>();
            var refNode = Root;
            bfs.Enqueue(refNode);
            while (bfs.Count != 0)
            {
                refNode = bfs.Dequeue();
                nums.Add(refNode.Value);
                var possibleNeighborNodes = GetPossibleNodes(refNode);
                foreach (var node in possibleNeighborNodes)
                    bfs.Enqueue(node);
            }
        }

        private ICollection<BSTNode<int>> GetPossibleNodes(BSTNode<int> node)
        {
            List<BSTNode<int>> pos = new List<BSTNode<int>>();
            if (node.RightRoot != null)
                pos.Add(node.RightRoot);
            if (node.LeftRoot != null)
                pos.Add(node.LeftRoot);
            return pos;
        }

        public void TraverseDFSPreorderIterative(List<int> nums)
        {
            Stack<BSTNode<int>> dfs = new Stack<BSTNode<int>>();
            dfs.Push(Root);
            while(dfs.Count != 0)
            {
                var node = dfs.Pop();
                nums.Add(node.Value);
                foreach (var item in GetPossibleNodes(node)) dfs.Push(item);
            }
        }

        public void TraverseDFSInorderIterative(List<int> nums)
        {
            Stack<BSTNode<int>> dfs = new Stack<BSTNode<int>>();
            dfs.Push(Root);
            while (dfs.Count != 0)
            {
                var node = dfs.Pop();
                nums.Add(node.Value);
                foreach (var item in GetPossibleNodes(node)) dfs.Push(item);
            }
        }



        public void TraverseDFSPreorder(List<int> nums, BSTNode<int> node) // preorder DFS
        {
            if (node == null)
                return;
            nums.Add(node.Value);
            TraverseDFSPreorder(nums, node.LeftRoot);
            TraverseDFSPreorder(nums, node.RightRoot);
        }

        public void TraverseDFSInorder(List<int> nums, BSTNode<int> node) // inorder DFS
        {
            if (node == null)
                return;
            TraverseDFSInorder(nums, node.LeftRoot);
            nums.Add(node.Value);
            TraverseDFSInorder(nums, node.RightRoot);
        }

        public void TraverseDFSPostorder(List<int> nums, BSTNode<int> node) // postorder DFS
        {
            if (node == null)
                return;
            TraverseDFSPostorder(nums, node.LeftRoot);
            TraverseDFSPostorder(nums, node.RightRoot);
            nums.Add(node.Value);
        }
        #endregion

        #region Sum of all depths of all nodes
        public int SumDepths() => DepthOf(Root, 0);

        private int DepthOf(BSTNode<int> node, int depth)
        {
            if (node == null) return 0;
            else if (node.LeftRoot == null && node.RightRoot == null)
                return depth;
            return DepthOf(node.LeftRoot, depth + 1) + DepthOf(node.RightRoot, depth + 1) + depth;
        }
        #endregion

        #region Find if Binary Tree is BST
        public bool IsBinarySearchTree(BSTNode<int> root)
        {
            int _value = int.MinValue;
            return IsBST(root, ref _value);
        }

        private bool IsBST(BSTNode<int> root, ref int _value) // InOrder solution
        {
            if (root == null) return true;

            bool output = true;
            if (root.LeftRoot != null)
                output = IsBST(root.LeftRoot, ref _value);

            if (_value < root.Value && output)
                _value = root.Value;
            else output = false;

            if (root.RightRoot != null && output)
                output = IsBST(root.RightRoot, ref _value);

            return output;
        }

        //My Code School solution
        public bool IsBST(BSTNode<int> root) => 
            IsBSTUtil(root, int.MinValue, int.MaxValue);

        private bool IsBSTUtil(BSTNode<int> root, int min, int max)
        {
            if (root == null) return true;

            return root.Value <= max && root.Value > min
                && IsBSTUtil(root.LeftRoot, min, root.Value)
                && IsBSTUtil(root.RightRoot, root.Value, max);
        }
        #endregion

        #region Succesor of node (inorder traversal)
        
        public BSTNode<int> GetSuccesor(int value)
        {
            if (Root == null) return null;

            var refNode = Root;
            BSTNode<int> succesor = null;

            while (refNode != null)
            {
                if (refNode.Value == value)
                    break;
                else if (value > refNode.Value)
                    refNode = refNode.RightRoot;
                else
                    refNode = refNode.LeftRoot;
            }
            BSTNode<int> sRefNode;

            if (refNode.RightRoot != null)
            {
                sRefNode = refNode.RightRoot;
                while (sRefNode.LeftRoot != null)
                    sRefNode = sRefNode.LeftRoot;
                return sRefNode;
            }

            else
            {
                sRefNode = Root;
                while(sRefNode != refNode)
                {
                    if (value > sRefNode.Value)
                        sRefNode = sRefNode.RightRoot;
                    else
                    {
                        succesor = sRefNode;
                        sRefNode = sRefNode.LeftRoot;
                    }
                }
            }
            return succesor;
        }
        #endregion

        #region Predecessor of node (inorder traversal)

        public BSTNode<int> GetPredecessor(int value)
        {
            if (Root == null) return null;

            var refNode = Root;
            BSTNode<int> predecessor = null;

            while (refNode != null)
            {
                if (refNode.Value == value)
                    break;
                else if (value > refNode.Value)
                    refNode = refNode.RightRoot;
                else
                    refNode = refNode.LeftRoot;
            }
            BSTNode<int> sRefNode;

            if (refNode.LeftRoot != null)
            {
                sRefNode = refNode.LeftRoot;
                while (sRefNode.RightRoot != null)
                    sRefNode = sRefNode.RightRoot;
                return sRefNode;
            }

            else
            {
                sRefNode = Root;
                while (sRefNode != refNode)
                {
                    if (value > sRefNode.Value)
                    {
                        predecessor = sRefNode;
                        sRefNode = sRefNode.RightRoot;
                    }
                    else sRefNode = sRefNode.LeftRoot;
                }
            }
            return predecessor;
        }
        #endregion
    }
}
