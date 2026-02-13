using System;
using System.Linq;

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
        var num2
    }
}