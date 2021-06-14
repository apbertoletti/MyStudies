using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.BinaryTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTreeArray();
            BinaryTreeExample();
        }

        private static void BinaryTreeExample()
        {
            Console.WriteLine();
            Console.WriteLine("==================================");
            Console.WriteLine("2) Binary Tree (exemple from this video: https://www.youtube.com/watch?v=pN1RWeX47tg)");
            Console.WriteLine("==================================");

            Tree tree = new Tree();

            tree.Insert(10);
            tree.Insert(12);
            tree.Insert(5);
            tree.Insert(53);
            tree.Insert(13);
            tree.Insert(43);
            tree.Insert(15);
            tree.Insert(1);

            Console.WriteLine();
            Console.WriteLine("In Order Traversal (Left->Root->Right)");
            tree.ShowInOrderTraversal();

            Console.WriteLine();
            Console.WriteLine("In Order Traversal (Left->Root->Right)");
            tree.ShowInOrderTraversal();

            Console.WriteLine();
            Console.WriteLine("Find Recursively 53");
            Node nodeR = tree.Find(53);
            Console.WriteLine(nodeR.Data);
        }

        private static void BinarySearchTreeArray()
        {
            Console.WriteLine();
            Console.WriteLine("==================================");
            Console.WriteLine("1) Binary Search in sorted array ");
            Console.WriteLine("==================================");

            // Create an array of 10 elements    
            int[] IntArray = new int[10] { 1, 17, 5, 7, 2, 13, 8, 19, 23, 31 };
            // Value to search for    
            int target = 17;
            Array.Sort(IntArray);
            int pos = Array.BinarySearch(IntArray, target);
            if (pos >= 0)
                Console.WriteLine($"Item {IntArray[pos].ToString()} found at position {pos + 1}.");
            else
                Console.WriteLine("Item not found");
        }
    }
}
