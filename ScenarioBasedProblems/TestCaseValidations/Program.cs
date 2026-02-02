using System;
using NUnit.Framework;

namespace TestCaseValidations
{
    /// <summary>
    /// Represents a bank account and supports deposit
    /// and withdrawal operations.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Gets or sets the current account balance.
        /// </summary>
        public decimal Balance { get; private set; }

        /// <summary>
        /// Initializes the account with initial balance.
        /// </summary>
        /// <param name="initialBalance">
        /// Starting balance of the account.
        /// </param>
        public Program(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        /// <summary>
        /// Deposits money into the account.
        /// Throws exception if amount is negative.
        /// </summary>
        public void Deposit(decimal amount)
        {
            if (amount < 0)
                throw new Exception("Deposit amount cannot be negative");

            Balance += amount;
        }

        /// <summary>
        /// Withdraws money from the account.
        /// Throws exception if funds are insufficient.
        /// </summary>
        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
                throw new Exception("Insufficient funds.");

            Balance -= amount;
        }
    }

    /// <summary>
    /// NUnit test class validating deposit and withdrawal logic.
    /// </summary>
    [TestFixture]
    public class UnitTest
    {
        /// <summary>
        /// Tests successful deposit operation.
        /// </summary>
        [Test]
        public void Test_Deposit_ValidAmount()
        {
            Program account = new Program(100);
            account.Deposit(50);

            NUnit.Framework.Assert.AreEqual(150, account.Balance);
        }

        /// <summary>
        /// Tests deposit with negative amount.
        /// </summary>
        [Test]
        public void Test_Deposit_NegativeAmount()
        {
            Program account = new Program(100);

            var ex = Assert.Throws<Exception>(() => account.Deposit(-10));

            NUnit.Framework.Assert.AreEqual("Deposit amount cannot be negative", ex.Message);
        }

        /// <summary>
        /// Tests successful withdrawal operation.
        /// </summary>
        [Test]
        public void Test_Withdraw_ValidAmount()
        {
            Program account = new Program(100);
            account.Withdraw(40);

            NUnit.Framework.Assert.AreEqual(60, account.Balance);
        }

        /// <summary>
        /// Tests withdrawal exceeding account balance.
        /// </summary>
        [Test]
        public void Test_Withdraw_InsufficientFunds()
        {
            Program account = new Program(100);

            var ex = Assert.Throws<Exception>(() => account.Withdraw(200));

            NUnit.Framework.Assert.AreEqual("Insufficient funds.", ex.Message);
        }
    }
}
