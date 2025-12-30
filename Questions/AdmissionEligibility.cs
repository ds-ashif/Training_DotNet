using System;

namespace Questions
{
    /// <summary>Checks admission eligibility.</summary>
    public class AdmissionEligibility
    {
        public static void Main()
        {
            Console.Write("Enter marks in Physics, Chemistry and Mathematics: ");
            int physics=Convert.ToInt32(Console.ReadLine());
            int chemistry=Convert.ToInt32(Console.ReadLine());
            int mathematics=Convert.ToInt32(Console.ReadLine());

            int total=physics+chemistry+mathematics;
            if(mathematics>=65 && physics>=55 && chemistry>=50 && (total>=180 || mathematics+chemistry>=140)){
                Console.WriteLine("The candidate is eligible for admission.");
            }
            else{
                Console.WriteLine("The candidate is not eligible for admission.");
            }
        }
    }
}
