using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsAndGenerics
{
    internal class Program
    {
        #region Non-Generic Collections

        /// <summary>
        /// Demonstrates non-generic collections such as
        /// ArrayList, Stack, and Queue.
        /// </summary>
        public void Sample()
        {
            // -------- ArrayList Example --------
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add("string");
            arrayList.Add(2.5);

            Console.WriteLine("ArrayList elements:");
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            // -------- Stack Example --------
            Stack mystack = new Stack();
            mystack.Push(10);
            mystack.Push("hello");
            mystack.Push(3.5);

            Console.WriteLine("\nStack pop operation:");
            if (mystack.Count > 0)
            {
                object value = mystack.Pop();   // pop only ONCE
                Console.WriteLine($"Popped value is {value}");
            }

            // -------- Queue Example --------
            Queue queue = new Queue();
            queue.Enqueue(100);
            queue.Enqueue("world");
            queue.Enqueue(5.5);

            Console.WriteLine("\nQueue elements:");
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }

        #endregion

        #region Generic Collections

        /// <summary>
        /// Demonstrates generic collections using List&lt;T&gt;.
        /// </summary>
        public void SampleGeneric()
        {
            List<string> names = new List<string>();
            names.Add("Arush");
            names.Add("Vishal");
            names.Add("Bala");

            names.Sort();

            Console.WriteLine("\nGeneric List elements:");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        #endregion

        #region Main Method

        /// <summary>
        /// Application entry point.
        /// </summary>
        static void Main(string[] args)
        {
            Program program = new Program();

            program.Sample();
            program.SampleGeneric();
        }

        #endregion
    }
}
