using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Enter string to trim extra spaces (exit to stop)");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("");
                return;
            }
            if(input.ToLower() == "exit") break;

            input = input.Trim();
            
            StringBuilder newString = new StringBuilder();

            bool isPrevSpace = false;
            foreach(char ch in input)
            {

                if(ch==' ')
                {
                    if (!isPrevSpace)
                    {
                        newString.Append(' ');
                        isPrevSpace = true;
                    }
                }
                else{
                newString.Append(ch);
                isPrevSpace = false;
                }
            }

            Console.WriteLine(newString.ToString());
        }
    }
}