using System;

namespace Questions
{
    /// <summary>Search using goto.</summary>
    public class SearchWithGoto
    {
        public static void Main()
        {
            try
            {
                int target = Convert.ToInt32(Console.ReadLine());

                for (int i = 1; i <= 2; i++)
                {
                    for (int j = 1; j <= 2; j++)
                    {
                        if (i * j == target)
                            goto Found;
                    }
                }

                Console.WriteLine("Not Found");
                return;

            Found:
                Console.WriteLine("Found");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }
    }
}
