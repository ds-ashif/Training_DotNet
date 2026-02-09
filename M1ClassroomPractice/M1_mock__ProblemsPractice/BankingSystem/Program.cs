using System;

/**
Q2. Banking - Encapsulation + Deposit/Withdraw Rules
A bank wants a safe account class that protects balance from invalid updates.
Requirements:
• Create class BankAccount with private field balance.
• Create methods Deposit(double amount) and Withdraw(double amount).
• Deposit should work only if amount > 0.
• Withdraw should work only if amount > 0 AND amount <= balance.
Task: Read 5 transactions (D/W + amount) and display final balance.
**/

namespace BankingSystem
{
    /// <summary>
    /// Entry point of the Banking System application.
    /// Provides a console menu to deposit, withdraw,
    /// check balance, or exit the program.
    /// </summary>
    class Program
    {
         /// <summary>
        /// Main method where program execution begins.
        /// </summary>
        static void Main()
        {
            // Display application header

            Console.WriteLine("----------------------Banking System------------------------");

            // Create bank account with initial balance
            BankAccount bankAccount = new BankAccount(10000);

            // Display menu options
            Console.WriteLine("Choose between 1 to 4");
            Console.WriteLine("1. Deposit Amount");
            Console.WriteLine("2. Withdraw Amount");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Exit");

            // Read user's initial menu choice
            int choice = int.Parse(Console.ReadLine());

            // Infinite loop to keep menu running until exit
            while (true)
            {
                // Execute action based on user choice
                switch (choice)
                {
                    case 1:
                        // Deposit operation
                        Console.WriteLine("Enter Amount to deposit");
                        double Depositamount = Double.Parse(Console.ReadLine());
                        bankAccount.Deposit(Depositamount);
                        break;

                    case 2:
                        // Withdrawal operation
                        Console.WriteLine("Enter amount to withdraw: ");
                        double WithdrawAmount = Double.Parse(Console.ReadLine());
                        bankAccount.Withdraw(WithdrawAmount);
                        break;

                    case 3:
                        // Display current account balance
                        Console.WriteLine($"Current Balance: {bankAccount.Display()}");
                        break;

                    case 4:
                        // Exit program immediately
                        Console.WriteLine("Exiting... Thank you!");
                        return; // Ends program immediately

                    default:
                        // Handle invalid menu choice
                        Console.WriteLine("Invalid Choice ...");
                        break;
                }
                // Ask user again for next operation
                Console.WriteLine("\nChoose between 1 to 4");
                choice = int.Parse(Console.ReadLine());
            }
        }
    }
}
