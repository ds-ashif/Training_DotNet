using System;

namespace Questions
{
    /// <summary>Guessing game.</summary>
    public class GuessingGame
    {
        public static void Main()
        {
            try
            {
                int secret = 7;
                int guess;

                do
                {
                    guess = Convert.ToInt32(Console.ReadLine());
                }
                while (guess != secret);

                Console.WriteLine("Correct");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }
    }
}
