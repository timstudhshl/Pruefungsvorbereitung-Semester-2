using System;
using Code.Liste;

namespace Code
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var tree = new BinaryTree();
            tree.Add(6);
            tree.Add(3);
            tree.Add(10);
            tree.Add(1);
            tree.Add(5);
            tree.Add(7);
            tree.Add(12);
            tree.Print();

            Console.WriteLine(tree.Contains(12));

            Console.ReadLine();
        }
    }
}
