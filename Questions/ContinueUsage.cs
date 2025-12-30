using System;

namespace Questions
{
    /// <summary>Skips multiples of 3.</summary>
    public class ContinueUsage
    {
        public static void Main()
        {
            try
            {
                for (int i = 1; i <= 50; i++)
                {
                    if (i % 3 == 0)
                        continue;

                    Console.Write(i + " ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }
    }
}
