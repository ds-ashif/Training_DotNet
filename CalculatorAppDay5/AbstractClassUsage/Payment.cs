using System;

namespace AbstractClassUsage
{
    /// <summary>
    /// Abstract base class representing a generic payment.
    /// Defines common properties and behavior for all payment types.
    /// </summary>
    public abstract class Payment
    {
        #region Properties

        /// <summary>
        /// Gets the payment amount.
        /// </summary>
        public decimal Amount { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes the payment with the specified amount.
        /// </summary>
        /// <param name="amount">The payment amount.</param>
        protected Payment(decimal amount)
        {
            Amount = amount;
        }

        #endregion

        #region Concrete Methods

        /// <summary>
        /// Prints a basic payment receipt.
        /// This method is shared across all payment types.
        /// </summary>
        public void PrintReceipt()
        {
            Console.WriteLine($"Receipt: Amount = {Amount}");
        }

        #endregion

        #region Abstract Methods

        /// <summary>
        /// Executes the payment using a specific payment method.
        /// Must be implemented by derived classes.
        /// </summary>
        public abstract void Pay();

        #endregion
    }

    /// <summary>
    /// Represents a UPI-based payment implementation.
    /// </summary>
    public class UpiPayment : Payment
    {
        #region Properties

        /// <summary>
        /// Gets the UPI ID used for the payment.
        /// </summary>
        public string UpiId { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new UPI payment.
        /// </summary>
        /// <param name="amount">The payment amount.</param>
        /// <param name="upiId">The UPI ID.</param>
        public UpiPayment(decimal amount, string upiId):base(amount)
        {
            UpiId = upiId;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Processes the payment using UPI.
        /// </summary>
        public override void Pay()
        {
            Console.WriteLine($"Paid {Amount} via UPI ({UpiId}).");
        }

        #endregion
    }


    /// <summary>
    /// Represents a Card-based payment implementation.
    /// </summary>
    /// 

    public class CardPayment : Payment
    {
        #region Properties
        /// <summary>
        /// Gets the card number used for the payment.
        /// </summary>
        /// 

        public string CardNumber { get; }
        #endregion

        #region Constructor

        ///<summary>
        ///Initializes a new Card payment.
        /// </summary>
        /// <param name="amount">The payment amount.</param>
        /// <param name="cardNumber">The UPI ID.</param>
        /// 

        public CardPayment(decimal amount, string cardNumber): base(amount)
        {
            CardNumber = cardNumber;
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Processes the payment using Card.
        /// </summary>

        public override void Pay()
        {
            Console.WriteLine($"Paid {Amount} via Card ({CardNumber}).");
        }
        #endregion



    }
}
