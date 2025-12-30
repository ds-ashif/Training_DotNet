using System;

namespace Questions
{
    /// <summary>Calculates profit or loss percentage.</summary>
    public class ProfitLoss
    {
        public static void Main()
        {
            double cost = double.Parse(Console.ReadLine());
            double sell = double.Parse(Console.ReadLine());

            if (sell > cost)
                Console.WriteLine(((sell - cost) / cost) * 100);
            else
                Console.WriteLine(((cost - sell) / cost) * 100);
        }
    }
}
