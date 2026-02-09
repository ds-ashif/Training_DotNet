/**
Q12. Word Frequency - Split + Count
A text analyzer needs word frequency counts.
Requirements:
•	Split the sentence into words
•	Count each word occurrence
•	Ignore case differences (treat 'Dot' and 'dot' same)
Task: Input a sentence and print word frequency output.
**/

using System;
using System.Collections.Generic;

class Program
{
    /// <summary>
    /// Reads a sentence, splits it into words,
    /// and counts frequency of each word
    /// ignoring case differences.
    /// </summary>
    static void Main()
    {
        // Ask user to input a sentence
        Console.WriteLine("Enter a sentence");
        string sentence = Console.ReadLine();

        // Convert sentence to lowercase and remove trailing spaces if there
        sentence = sentence.Trim().ToLower();

        // Split sentence into words using space as separator
        string[] words=sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // Dictionary to store word counts
        Dictionary<string,int> wordCount = new Dictionary<string, int>();

        // Count occurrences of each word
        foreach(var word in words)
        {
            // If word already exists, increment count
            if (wordCount.ContainsKey(word))
            {
                wordCount[word]++;
            }
            // Otherwise add word with count 1
            else
            {
                wordCount[word] = 1;
            }
        }

        // Display word frequency result
        Console.WriteLine("\nWord Frequency:");

        foreach(var item in wordCount)
        {
            Console.WriteLine($"{item.Key} - {item.Value}");
        }


    }
}