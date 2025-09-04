using System;

namespace LinkedListHadasim;

    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            Console.WriteLine("=== Testing Prepend and Append ===");
            list.Prepend(10); // [10]
            list.Append(20);  // [10, 20]
            list.Append(30);  // [10, 20, 30]
            list.Prepend(5);  // [5, 10, 20, 30]

            Console.WriteLine("List after Prepend + Append:");
            foreach (int val in list.ToList())
                Console.Write(val + " ");
            Console.WriteLine();

            Console.WriteLine("\n=== Testing GetMaxNode and GetMinNode ===");
            Console.WriteLine("Max: " + list.GetMaxNode().Value);
            Console.WriteLine("Min: " + list.GetMinNode().Value);

            Console.WriteLine("\n=== Testing Pop (remove last) ===");
            int popped = list.Pop(); // removes 30
            Console.WriteLine("Popped: " + popped);
            foreach (int val in list.ToList())
                Console.Write(val + " ");
            Console.WriteLine();

            Console.WriteLine("\n=== Testing Unqueue (remove first) ===");
            int unqueued = list.Unqueue(); // removes 5
            Console.WriteLine("Unqueued: " + unqueued);
            foreach (int val in list.ToList())
                Console.Write(val + " ");
            Console.WriteLine();

            Console.WriteLine("\n=== Testing Sort ===");
            list.Append(15);
            list.Append(25);
            list.Append(1);
            Console.WriteLine("Before sort:");
            foreach (int val in list.ToList())
                Console.Write(val + " ");
            Console.WriteLine();

            list.Sort();
            Console.WriteLine("After sort:");
            foreach (int val in list.ToList())
                Console.Write(val + " ");
            Console.WriteLine();

            Console.WriteLine("\n=== Testing IsCircular ===");
            Console.WriteLine("IsCircular: " + list.IsCircular());

            list.GetMaxNode().Next = list.GetMinNode();
            Console.WriteLine("IsCircular after manual link: " + list.IsCircular());

            Console.WriteLine("\nAll tests finished.");
        }
    }


