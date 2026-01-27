using System;
namespace BankAccount
{
    /// <summary>
    /// Represents a bank account with deposit and withdrawal functionalities.
    /// </summary>

    class Account
    {
        /// <summary>
        /// Gets or sets the current balance of the account.
        /// </summary>
        public decimal balance { get; set; }

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the Account class with a specified initial balance.
        /// </summary>
        /// <param name="initialBalance"></param>
        public Account(decimal initialBalance)
        {
            balance = initialBalance;
        }
        #endregion

        #region Account Methods

        /// <summary>
        /// Deposits a specified amount into the account.
        /// </summary>
        /// <param name="amount"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void deposit(decimal amount)
        {
            if (balance < 0)
            {
                throw new InvalidOperationException("Cannot deposit to an account with negative balance.");
            }
            balance += amount;
        }

        /// <summary>
        /// Withdraws a specified amount from the account if sufficient funds are available.
        /// </summary>
        /// <param name="amount"></param>
        public void withdraw(decimal amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
            }

        }

        /// <summary>
        /// Gets the current balance of the account.
        /// </summary>
        /// <returns></returns>

        public decimal getBalance()
        {
            return balance;
        }

        #endregion

    }
}