using System;

namespace MultiplicationTable
{
    class Table{

    public static void Main()
    {
        Console.WriteLine("Enter a number to generate its multiplication table:");
        int n=int.Parse(Console.ReadLine());
        Console.WriteLine($"Enter a number upto which multiplication table of {n} is to be generated");
        int upTo=int.Parse(Console.ReadLine());

        int[] Table=new int[upTo];

        for(int i = 1; i <= upTo; i++)
        {
            Table[i-1]=n*i;
        }

        Console.Write($"Multiplication table of {n} upto {upTo} is:");
        for(int i = 0; i < upTo; i++)
        {
            Console.Write($"  {Table[i]} ");
        }
    }
    }
}