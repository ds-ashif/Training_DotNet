using System;
using MathsLib;
namespace CalculatorAppDay5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var normalMaths = new NormalMaths { Num1 = 12, Num2 = 3 };


            Console.WriteLine(normalMaths.Add());       
            Console.WriteLine(normalMaths.Subtract());  
            Console.WriteLine(normalMaths.Multiply());  
            Console.WriteLine(normalMaths.Divide());

            SecurityCheck securityCheck = new SecurityCheck();


            securityCheck.CheckLogin("admin", "1234");
            securityCheck.CheckLogout();

        }
    }
}

