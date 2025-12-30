using System;

namespace Questions
{
    /// <summary>Prints Pascal's triangle.</summary>
    public class PascalsTriangle
    {
        public static void Main()
        {
            try
            {
                int rows = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < rows; i++)
                {
                    int value = 1;
                    for (int j = 0; j <= i; j++)
                    {
                        Console.Write(value + " ");
                        value = value * (i - j) / (j + 1);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }
    }
}
