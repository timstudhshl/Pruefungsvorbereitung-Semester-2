using System;

namespace Code.Liste
{
    internal class BinaryTree
    {
        private TreeNode _root = null;

        public void Add(int n)
        {
            if (_root == null)
            {
                var node = new TreeNode
                {
                    Value = n
                };
                _root = node;
            }
            else
            {
                AddRecursive(_root, n);
            }
        }

        public bool Contains(int value)
        {
            return ContainsRecursive(_root, value);
        }

        public void Print()
        {
            PrintRecursive(_root);
        }

        private void AddRecursive(TreeNode parent, int value)
        {
            if (value <= parent.Value)
            {
                // links
                if (parent.Left == null)
                {
                    // neuen Knoten erstellen
                    var node = new TreeNode
                    {
                        Value = value
                    };
                    parent.Left = node;
                }
                else
                {
                    AddRecursive(parent.Left, value);
                }
            }
            else
            {
                // rechts
                if (parent.Right == null)
                {
                    var node = new TreeNode
                    {
                        Value = value
                    };
                    parent.Right = node;
                }
                else
                {
                    AddRecursive(parent.Right, value);
                }
            }
        }

        private bool ContainsRecursive(TreeNode node, int value)
        {
            if (node == null)
                return false;
            if (node.Value == value)
                return true;
            if (value < node.Value)
                return ContainsRecursive(node.Left, value);
            else
                return ContainsRecursive(node.Right, value);
        }

        private void PrintRecursive(TreeNode node)
        {
            if (node == null)
                return;

            Console.WriteLine(node.Value);

            PrintRecursive(node.Left);
            PrintRecursive(node.Right);
        }
    }
}
