using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //take input string as a integer
        Console.WriteLine("Enter string as double ");
        string num = Console.ReadLine();

        if(double.TryParse(num,out double number))
        {
            Console.WriteLine("Converted to double");
            number = Math.Round(number,2);
            Console.WriteLine(number);
        }
        else
        {
            Console.WriteLine("Please enter double in string");
        }
    }
}