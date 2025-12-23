using System;

namespace Questions
{
    /// <summary>Finds roots of quadratic equation.</summary>
    public class QuadraticEquation
    {
        public static void Main()
        {
            Console.WriteLine("Enter coefficients a, b and c: ");
            double a=Convert.ToDouble(Console.ReadLine());
            double b=Convert.ToDouble(Console.ReadLine());
            double c=Convert.ToDouble(Console.ReadLine());

            if(a==0){
                Console.WriteLine("Coefficient 'a' cannot be zero in a quadratic equation.");
                return;
            }

            double discriminant=b*b-4*a*c;

            if(discriminant>0){
                double root1=(-b+Math.Sqrt(discriminant))/(2*a);
                double roo2=(-b-Math.Sqrt(discriminant))/(2*a);
                Console.WriteLine($"Roots are real and different. Root1: {root1}, Root2: {roo2}");
            }
            else if(discriminant==0){
                double root=-b/2*a;
                Console.WriteLine($"Roots are real and same. Root: {root}");
            }
            else {
                Console.WriteLine("Roots are complex and different.");
            }
        }
    }
}
