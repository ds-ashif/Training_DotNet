/**
Q14. Log Formatter - StringBuilder Performance
You must generate 10,000 log lines and compare performance.
Requirements:
•	Build one big string using '+' concatenation
•	Build the same using StringBuilder
•	Measure time using Stopwatch
Task: Print the time taken by both approaches and explain which is faster in code comments.
**/

using System;
using System.Diagnostics;
using System.Text;
using System.Diagnostics;

namespace LogTimeMeasure
{
    /// <summary>
    /// Demonstrates performance difference between
    /// string concatenation and StringBuilder when
    /// generating many log lines.
    /// </summary>
    class Program
    {
        static void Main()
        {
            const int logCount = 10000;
            //---------------------------------------------
            // Test 1: String concatenation using '+'
            //---------------------------------------------
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();

            string logs1 ="";

            for(int i = 1; i <= logCount; i++)
            {
                 // Each concatenation creates a new string object
                logs1 += $"Log Entry {i} generated at {DateTime.Now}\n";
            }

            sw1.Stop();

            //---------------------------------------------
            // Test 2: Using StringBuilder
            //---------------------------------------------

            Stopwatch sw2 = new Stopwatch();
            sw2.Start();

            StringBuilder logs2 =new StringBuilder();
            for(int i = 1; i <= logCount; i++)
            {
                logs2.AppendLine($"Log Entry {i} generated at {DateTime.Now}\n");
            }
            string finalLog = logs2.ToString();

            sw2.Stop();

            //---------------------------------------------
            // Display execution times
            //---------------------------------------------
            Console.WriteLine($"Time using '+' concatenation: {sw1.ElapsedMilliseconds} ms");
            Console.WriteLine($"Time using StringBuilder: {sw2.ElapsedMilliseconds} ms");

            /*
             Explanation:
             String concatenation is slower because every '+' creates
             a new string object in memory.

             StringBuilder is faster because it modifies an internal
             buffer instead of creating new strings repeatedly.

             Therefore, StringBuilder is recommended when building
             large strings or logs in loops.
            */
        }
    }
}