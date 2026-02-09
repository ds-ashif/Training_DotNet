using System;

/**
An e-commerce app applies different discount policies.
Requirements:
•	Create abstract class DiscountPolicy with abstract method GetFinalAmount(double amount).
•	FestivalDiscount: 10% off if amount >= 5000 else 5%.
•	MemberDiscount: flat 300 off if amount >= 2000 else no discount.
Task: Choose policy based on user input and print the final payable amount.
**/

namespace ECommerceDiscount
{
    /// <summary>
    /// Abstract class representing discount policy.
    /// Forces derived classes to implement discount logic.
    /// </summary>
    abstract class DiscountPolicy
    {
        // Abstract method for final amount calculation
        public abstract double GetFinalAmount(double amount);
    }

    /// <summary>
    /// Festival discount policy.
    /// 10% discount if amount >= 5000, else 5%.
    /// </summary>
    class FestivalDiscount : DiscountPolicy
    {
        public override double GetFinalAmount(double amount)
        {
            if (amount >= 5000)
            {
                return amount * 0.90; //10% off
            }
            else
            {
                return amount * 0.95;  // 5% off
            }
        }
    }

    /// <summary>
    /// Member discount policy.
    /// Flat 300 discount if amount >= 2000.
    /// </summary>
    class MemberDiscount: DiscountPolicy
    {
        public override double GetFinalAmount(double amount)
        {
            if(amount>=2000) return amount-300;  //flat 300 rupees off for shopping above 2000

            return amount;
        }   
    }
}