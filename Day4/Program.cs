using System;
using System.IO.Pipelines;

namespace Day4Constructor
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Visitor visitor=new Visitor(101,"Ashif","Inquiry about courses");
            // Console.WriteLine($"Id: {visitor.Id}, Name: {visitor.Name}, Requirement: {visitor.Requirement}");

            // Visitor visitor1=new Visitor();
            try
            {
                Visitor visitor1=new Visitor(10,"Ashif","Inquiry about courses");
                Console.WriteLine("---- Log History ----");
                Console.WriteLine(visitor1.LogHistory);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


            // int num1=0,num2=0;
            // Console.WriteLine("Enter first number:");
            // num1=Convert.ToInt32(Console.ReadLine());
            // Console.WriteLine("Enter second number:");
            // num2=Convert.ToInt32(Console.ReadLine());

            // Sum sum=new Sum(num1,num2);

            // Console.WriteLine(sum.Result);

        }
    }
}