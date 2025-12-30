using System;

namespace Questions
{
    /// <summary>Performs basic arithmetic.</summary>
    public class SimpleCalculator
    {
        public static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            char op = char.Parse(Console.ReadLine());

            switch (op)
            {
                case '+': Console.WriteLine(a + b); break;
                case '-': Console.WriteLine(a - b); break;
                case '*': Console.WriteLine(a * b); break;
                case '/': Console.WriteLine(a / b); break;
            }
        }
    }
}
