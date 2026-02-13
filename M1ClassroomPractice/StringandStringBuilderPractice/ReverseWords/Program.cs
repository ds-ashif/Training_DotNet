using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static string Solve(string input)
    {
        if(String.IsNullOrWhiteSpace(input)) return "";

        string[] parts = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
        Array.Reverse(parts);
        return string.Join(" ",parts);
    }
    static void Main()
    {
        string str = Console.ReadLine();
        string result = Solve(str);
        Console.WriteLine(result);

    }
}