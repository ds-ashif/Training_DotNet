/**
Q13. Find Longest Word - String + Loop
A document tool highlights the longest word in a paragraph.
Requirements:
•	Ignore punctuation like . , ! ?
•	If multiple words tie, return the first occurring
Task: Input a paragraph and print the longest word.
**/

using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

class Program
{
    /// <summary>
    /// Finds the longest word in a paragraph.
    /// Punctuation marks are ignored.
    /// If multiple words have same length,
    /// the first occurring word is returned.
    /// </summary>
    static void Main()
    {
        // Ask user to input paragraph
        Console.WriteLine("Enter a paragraph:");
        string paragraph = Console.ReadLine();

        // Remove punctuation marks
        paragraph = paragraph.Replace(".","").Replace(",","").Replace("?","").Replace("!","");

        // Split paragraph into words
        string[] words = paragraph.Split(' ',StringSplitOptions.RemoveEmptyEntries);

        string longestWord ="";
        foreach(var word in words)
        {
            if (word.Length > longestWord.Length)
            {
                longestWord = word;
            }
        }
        Console.WriteLine($"\nLongest word: {longestWord}");
    }
}