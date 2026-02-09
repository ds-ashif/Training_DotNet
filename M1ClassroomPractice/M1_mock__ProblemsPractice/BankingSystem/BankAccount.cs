using System;

/**
Q2. Banking - Encapsulation + Deposit/Withdraw Rules
A bank wants a safe account class that protects balance from invalid updates.
Requirements:
•	Create class BankAccount with private field balance.
•	Create methods Deposit(double amount) and Withdraw(double amount).
•	Deposit should work only if amount > 0.
•	Withdraw should work only if amount > 0 AND amount <= balance.
Task: Read 5 transactions (D/W + amount) and display final balance.
**/

namespace BankingSystem
{
    /// <summary>
    /// Represents a bank account that safely manages balance.
    /// Encapsulation is used so balance cannot be directly modified.
    /// </summary>
    class BankAccount
    {
        /// <summary>
        /// Private balance property.
        /// Only accessible inside this class.
        /// </summary>
        private double Balance{get; set;}

        // <summary>
        /// Constructor initializes account with starting balance.
        /// </summary>
        /// <param name="balance">Initial account balance</param>
        public BankAccount(double balance)
        {
            Balance = balance;
        }

        /// <summary>
        /// Deposits money into account.
        /// Deposit is allowed only if amount is non-negative.
        /// </summary>
        /// <param name="amount">Amount to deposit</param>
        public void Deposit(double amount)
        {
            // Check for valid deposit amount
            if(amount>=0) {
                Balance+=amount;
                Console.WriteLine($"Rs.{amount} is added to current balance.");
            }
        }

        /// <summary>
        /// Withdraws money from account.
        /// Withdrawal allowed only if amount is positive
        /// and available in balance.
        /// </summary>
        /// <param name="amount">Amount to withdraw</param>
        public void Withdraw(double amount)
        {
            // Check if withdrawal exceeds balance
            if(amount > Balance) Console.WriteLine("Insufficient Balance, can't withdraw");
            // Check invalid amount
            else if(amount<=0) Console.WriteLine("Can't withdraw. Enter valid Amount to withdraw.");
            // Perform withdrawal
            else
            {
                Balance -= amount;
                Console.WriteLine($"Rs.{amount} is deducted from current balance.");
            }
            
        }

        /// <summary>
        /// Returns current balance.
        /// </summary>
        /// <returns>Current account balance</returns>
        public double Display()
        {
            return Balance;
        }
        

    }
}