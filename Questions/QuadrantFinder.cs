using System;

namespace Questions
{
    /// <summary>Finds coordinate quadrant.</summary>
    public class QuadrantFinder
    {
        public static void Main()
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            if (x > 0 && y > 0) Console.WriteLine("Quadrant I");
            else if (x < 0 && y > 0) Console.WriteLine("Quadrant II");
            else if (x < 0 && y < 0) Console.WriteLine("Quadrant III");
            else if (x > 0 && y < 0) Console.WriteLine("Quadrant IV");
            else Console.WriteLine("On Axis");
        }
    }
}
