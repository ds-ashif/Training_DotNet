using System;

namespace BankingWithdrawelValidation
{
    #region custom exception classes

    /// <summary>
    /// custom exception class invalid amount
    /// </summary>
    class InvalidAmountException : Exception
    {
        public InvalidAmountException(string message) : base(message) { }
    }

    /// <summary>
    /// Custom exception class for insufficient balance
    /// </summary>
    class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }
    #endregion


    public class BankAccount
    {
        //entry point
        public static void Main()
        {
            int balance = 1000;

            try
            {
                Console.WriteLine("Enter withdrawal amount:");
                int amount = int.Parse(Console.ReadLine());

                if (amount <= 0)
                    throw new InvalidAmountException("Withdrawal amount must be greater than 0.");

                if (amount > balance)
                    throw new InsufficientBalanceException("Withdrawal amount must be less or equal to balance.");

                balance -= amount;
                Console.WriteLine("Withdrawal successful.");
                Console.WriteLine("Remaining balance: " + balance);
            }
            catch (InvalidAmountException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
            finally
            {
                Console.WriteLine("Transaction attempt logged.");
            }
        }
    }
}
