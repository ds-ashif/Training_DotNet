using System;
// TODO:
        // 1. Loop through salaries
        // 2. Divide bonus by salary
        // 3. Handle DivideByZeroException
        // 4. Continue processing remaining employees

namespace EmployeeBonusProcessing
{
    // class DivideByZeroException : Exception
    // {
    //     public DivideByZeroException(string message) : base(message){ }
    // }
    public class BonusCalculator{
        
        public static void Main()
        {
            int[] salaries = {5000, 0, 7000};
            int bonusAmount = 10000;

            //1. looping through salaries
            for(int i = 0; i < salaries.Length; i++)
            {
                try
                {
                    Console.WriteLine($"Processig Employee {i+1}");


                    int bonusRatio = bonusAmount/salaries[i];

                    Console.WriteLine($"Bonus Ratio: {bonusRatio}");
                }
                catch(DivideByZeroException)
                {
                    Console.WriteLine("Salary is zero. Cannot calculate bonus.");
                }
                finally
                {
                    Console.WriteLine($"Processing completed for employee {i+1}.\n");
                }
            }
            
        }
    }
}