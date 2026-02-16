using System;
using System.Collections.Generic;

class Program
{
    // Q1) Reverse Words in a Sentence
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Enter sentence to reverse:");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Exiting...");
                break;
            }
        

            string[] parts = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(parts);
            var ans = string.Join(" ",parts);
            Console.WriteLine(ans);


        }
    }
}