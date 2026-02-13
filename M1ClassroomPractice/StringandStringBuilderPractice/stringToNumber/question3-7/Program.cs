using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        //Question 3: Input: "1 2 3 4" – Split by spaces and turn each piece into integers.
        string input1 = "1 2 3 4";
        var nums= input1.Split(' ').Select( x => int.TryParse(x, out int n)?n:0);
        Console.WriteLine(string.Join(", ",nums));

        //Question 4:  Input: "9.5 8.3 7.1" – Break it apart and convert these to a list of doubles.
        string input2 = "9.5 8.3 7.1";
        var num2 = input2.Split(' ').Select(x => double.TryParse(x, out double n)? n:0 );
        Console.WriteLine(string.Join(", ",num2));

        //Question 5:  Input: "Fifty" – Validate that this string is not a number at all.
        String input3 = "Fifty";
        var IsNumber = int.TryParse(input3, out _);  //_ means: I don’t care about the output value, just tell me if parsing succeeded
        Console.WriteLine(IsNumber ? "Valid":"invalid");


        //Question 6: Input: "15.7abc" – Extract just the numeric portion.
        var input4 = "15.7abc";
        string numericPart = new string(input4.TakeWhile(c => char.IsDigit(c) || c=='.').ToArray());
        Console.WriteLine(numericPart);
        
        //Question 7: Input: "999999999" – Convert this large number into a long.
        var input5 = "999999999";
        var num = long.TryParse(input5,out long n)?n:0;
        Console.WriteLine(num);
    }
}