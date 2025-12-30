using System;

namespace Questions
{
    /// <summary>Classifies height into categories.</summary>
    public class HeightCategory
    {
        public static void Main()
        {
            int heightCm = int.Parse(Console.ReadLine());

            if (heightCm < 150)
                Console.WriteLine("Dwarf");
            else if (heightCm < 165)
                Console.WriteLine("Average");
            else if (heightCm <= 190)
                Console.WriteLine("Tall");
            else
                Console.WriteLine("Abnormal");
        }
    }
}
