using System;

namespace Questions
{
    /// <summary>Rock Paper Scissors game.</summary>
    public class RockPaperScissors
    {
        public static void Main()
        {
            string p1 = Console.ReadLine();
            string p2 = Console.ReadLine();

            if (p1 == p2)
                Console.WriteLine("Draw");
            else if ((p1 == "Rock" && p2 == "Scissors") ||
                     (p1 == "Scissors" && p2 == "Paper") ||
                     (p1 == "Paper" && p2 == "Rock"))
                Console.WriteLine("Player 1 Wins");
            else
                Console.WriteLine("Player 2 Wins");
        }
    }
}
