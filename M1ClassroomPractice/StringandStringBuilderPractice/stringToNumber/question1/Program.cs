using System;

class Program
{
    static void Main()
    {
        //take input string as a integer
        Console.WriteLine("Enter string numbers ");
        string num = Console.ReadLine();
        
        //check type with handelling error risk so use out keyword
        if(int.TryParse(num, out int number))
        {
            Console.WriteLine("string number converted to int.");
            
        }
        else
        {
            Console.WriteLine("Please enter a number in string");
        }
    }
}