using System;
using System.Collections.Generic;

namespace Students
{
    /// <summary>
    /// Class to print remarks based on student rank.
    /// </summary>
    public class Remarks
    {
      
        public static void PrintRemark(Student student)
        {
            // Providing remarks based on rank
            if (student.Rank == 1)
            {
                Console.WriteLine($"Rank: {student.Rank}, Remark for {student.Name}: Excellent performance!");
            }

            // Additional remarks for other ranks can be added here
            else if (student.Rank == 2)
            {
                Console.WriteLine($"Rank: {student.Rank}, Remark for {student.Name}: Very good, keep it up!");
            }

            // Example for rank 3
            else if (student.Rank == 3)
            {
                Console.WriteLine($"Rank: {student.Rank}, Remark for {student.Name}: Good effort, strive for better!");
            }
            // Remarks for ranks beyond 3
            else
            {
                Console.WriteLine($"Remark for {student.Name}: Needs improvement, work harder!");
            }
        }
    }
}