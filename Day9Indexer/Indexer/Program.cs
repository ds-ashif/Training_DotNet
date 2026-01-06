using System;


namespace Indexer
{
    /// <summary>
    /// Provides the entry point for the application.
    /// Purpose: To demonstrate the use of indexers in C#.
    /// Learning Outcome: Understand how to implement and use indexers in a class.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            MyData myData = new MyData(); // Creating an instance of Mydata class
            myData[0] = "C";  // Using indexer to set values
            myData[1] = "C++";
            myData[2] = "C#";

            Console.WriteLine("First Value is: " + myData[0]); // Using indexer to get values
            Console.WriteLine("Second Value is: " + myData[1]);
            Console.WriteLine("Third Value is: " + myData[2]);
        }
    }
}
