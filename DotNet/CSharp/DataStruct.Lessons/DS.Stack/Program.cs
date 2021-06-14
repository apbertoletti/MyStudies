using System;
using System.Collections;
using System.Collections.Generic;

namespace DS.Stacks
{
    class Program
    {
        static void Main(string[] args)
        {            
            SimpleStack();
            
            GenericStack();
        }

        private static void GenericStack()
        {
            Console.WriteLine();
            Console.WriteLine("==================================");
            Console.WriteLine("2) An example of Generic Stack");
            Console.WriteLine("==================================");

            Stack<string> numbers = new Stack<string>();
            numbers.Push("one");
            numbers.Push("two");
            numbers.Push("three");
            numbers.Push("four");
            numbers.Push("five");

            // A stack can be enumerated without disturbing its contents.
            foreach (string number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\nPopping '{0}'", numbers.Pop());
            Console.WriteLine("Peek at next item to destack: {0}", numbers.Peek());
            Console.WriteLine("Popping '{0}'", numbers.Pop());

            // Create a copy of the stack, using the ToArray method and the
            // constructor that accepts an IEnumerable<T>.
            Stack<string> stack2 = new Stack<string>(numbers.ToArray());

            Console.WriteLine("\nContents of the first copy:");
            foreach (string number in stack2)
            {
                Console.WriteLine(number);
            }

            // Create an array twice the size of the stack and copy the
            // elements of the stack, starting at the middle of the
            // array.
            string[] array2 = new string[numbers.Count * 2];
            numbers.CopyTo(array2, numbers.Count);

            // Create a second stack, using the constructor that accepts an
            // IEnumerable(Of T).
            Stack<string> stack3 = new Stack<string>(array2);

            Console.WriteLine("\nContents of the second copy, with duplicates and nulls:");
            foreach (string number in stack3)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\nstack2.Contains(\"four\") = {0}", stack2.Contains("four"));

            Console.WriteLine("\nstack2.Clear()");
            stack2.Clear();
            Console.WriteLine("\nstack2.Count = {0}", stack2.Count);
        }

        private static void SimpleStack()
        {
            Console.WriteLine();
            Console.WriteLine("==================================");
            Console.WriteLine("1) An example of Simple Stack");
            Console.WriteLine("==================================");

            // Creates and initializes a new Stack.
            Stack myStack = new Stack();
            myStack.Push("Hello");
            myStack.Push("World");
            myStack.Push("!");

            // Displays the properties and values of the Stack.
            Console.WriteLine("myStack");
            Console.WriteLine("\tCount:    {0}", myStack.Count);
            Console.Write("\tValues:");

            foreach (Object obj in myStack)
                Console.Write("    {0}", obj);
         
            Console.WriteLine();
        }
    }
}
