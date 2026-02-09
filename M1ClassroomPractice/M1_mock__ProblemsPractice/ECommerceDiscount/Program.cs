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
    class Program
    {
         /// <summary>
        /// Entry point of discount calculation program.
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Enter total purchase amount:");
            double amount = double.Parse(Console.ReadLine());

            Console.WriteLine("Choose discount policy (festival/member):");
            string choice = Console.ReadLine().ToLower();

            DiscountPolicy policy;

            // Select discount policy at runtime
            if (choice == "festival")
            {
                policy = new FestivalDiscount();
            }
            else
            {
                policy = new MemberDiscount();
            }

            double finalAmount = policy.GetFinalAmount(amount);
            Console.WriteLine($"Final Payable Amount: Rs. {finalAmount}");
        }
    }
}