using System;

namespace Questions
{
    /// <summary>Simulates ATM withdrawal.</summary>
    public class ATMWithdrawal
    {
        public static void Main()
        {
            bool card = Console.ReadLine() == "1";
            bool pin = Console.ReadLine() == "1";
            bool balance = Console.ReadLine() == "1";

            if (card)
            {
                if (pin)
                {
                    if (balance)
                        Console.WriteLine("Transaction Successful");
                    else
                        Console.WriteLine("Insufficient Balance");
                }
                else
                    Console.WriteLine("Invalid Pin");
            }
            else
                Console.WriteLine("Insert Card");
        }
    }
}
