using System;

namespace Questions
{
    /// <summary>Prints grade description.</summary>
    public class GradeDescription
    {
        public static void Main()
        {
            char grade = char.Parse(Console.ReadLine().ToUpper());

            switch (grade)
            {
                case 'E': Console.WriteLine("Excellent"); break;
                case 'V': Console.WriteLine("Very Good"); break;
                case 'G': Console.WriteLine("Good"); break;
                case 'A': Console.WriteLine("Average"); break;
                case 'F': Console.WriteLine("Fail"); break;
            }
        }
    }
}
