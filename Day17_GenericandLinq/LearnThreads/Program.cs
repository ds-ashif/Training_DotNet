using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace LearnThreads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("for loop for even started");
            //for(int i=0;i<=100;i+=2)
            //{
            //   Thread.Sleep(100);
            //    Console.Write(i+" ");
            //}

            Thread t1 = new Thread(Task1);
            Thread t2 = new Thread(Task2);
            t1.Start();
            t2.Start();
            Console.ReadLine();

            //Console.WriteLine("\nfor loop to start odd");
            //for(int i = 1; i <= 100; i+=2)
            //{
            //    Thread.Sleep(100);
            //    Console.Write(i+" ");
            //}
        }

        private static void Task1()
        {
            Console.WriteLine("for loop for even started");
            for (int i = 0; i <= 100; i += 2)
            {
                Thread.Sleep(200);
                Console.Write(i + " ");
            }
        }

        private static void Task2()
        {
            Console.WriteLine("\nfor loop to start odd");
            for (int i = 1; i <= 100; i += 2)
            {
                Thread.Sleep(200);
                Console.Write(i + " ");
            }
        }

    }

}
