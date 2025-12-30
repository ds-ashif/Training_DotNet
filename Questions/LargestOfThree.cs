using System;

namespace Questions
{
    /// <summary>Finds largest of three numbers.</summary>
    public class LargestOfThree
    {
        public static void Main()
        {
            Console.WriteLine("Enter num1: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter num2: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter num3: ");
            int num3 = Convert.ToInt32(Console.ReadLine());

            if (num1 >= num2)
            {
                if (num1 >= num3)
                    Console.WriteLine($"{num1} is largest");
                else
                    Console.WriteLine($"{num3} is largest");
            }
            else
            {
                if (num2 >= num3)
                    Console.WriteLine($"{num2} is largest");
                else
                    Console.WriteLine($"{num3} is largest");
            }
        }
    }
}
