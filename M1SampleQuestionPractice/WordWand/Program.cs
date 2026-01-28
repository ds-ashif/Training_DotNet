using System;

namespace WordWand
{
    /// <summary>
    /// The main program class responsible for processing words in a sentence.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Counts the number of words in a sentence and determines if it's even or odd.
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public static int WordCount(string sentence)
        {
            int totalWords=sentence.Trim().Split(" ").Length;
            if(totalWords%2==0) return 1;
            return 0;
            
        }
        /// <summary>
        /// Processes the words in the sentence based on the word count.
        /// If the word count is odd, reverses each word individually.
        /// If the word count is even, reverses the order of the words.
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public static string ProcessWords(string sentence)
        {
            foreach(char c in sentence)
            {
                if(!char.IsLetter(c) && c!=' ')
                {
                    return "Invalid Sentence";
                }
            }

            string[] words=sentence.Trim().Split(" ");
            if(WordCount(sentence)==1)
            {
                Array.Reverse(words);
                return string.Join(" ", words);
            }
            else
            {
                for (int i = 0; i < words.Length; i++)
                {
                    char[] chars = words[i].ToCharArray();
                    Array.Reverse(chars);
                    words[i] = new string(chars);
                }
                return string.Join(" ", words);
            }
        }

        /// <summary>
        /// The entry point of the application.
        /// Reads user input, processes the words
        /// </summary>
        public static void Main()
        {
            //taking input
            Console.WriteLine("Enter the sentence");
            string input = Console.ReadLine();

            //total word count
            int count = input.Trim().Split(' ').Length;
            Console.WriteLine("Word Count: " + count);

            //processing words
            string result = ProcessWords(input);
            Console.WriteLine(result);
        }
    }
}