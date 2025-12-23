using System;

namespace HelloWorldApp
{
    public class Tasks
    {
        // Task1 starts: Height Category
        public void HeightCategory()
        {
            Console.Write("Enter height in centimeters: ");
            int height = Convert.ToInt32(Console.ReadLine());

            switch (height)
            {
                case < 150:
                    Console.WriteLine($"{height} is Dwarf");
                    break;

                case >= 150 and <= 165:
                    Console.WriteLine($"{height} is Average");
                    break;

                case >= 166 and <= 190:
                    Console.WriteLine($"{height} is Tall");
                    break;

                default:
                    Console.WriteLine($"{height} is Abnormal");
                    break;
            }
        }

        //Task1 ends here


        // Task2 starts: Largest of three numbers
        public void LargestOfThree()
        {
            Console.WriteLine("Enter num1: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter num2: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter num3: ");
            int num3 = Convert.ToInt32(Console.ReadLine());

            if (num1 >= num2)
            {
                if (num1 >= num3)
                    Console.WriteLine($"{num1} is largest");
                else
                    Console.WriteLine($"{num3} is largest");
            }
            else
            {
                if (num2 >= num3)
                    Console.WriteLine($"{num2} is largest");
                else
                    Console.WriteLine($"{num3} is largest");
            }
        }

        //Task2 ends here


        //Task3 starts:  Leap year checker

        public void LeapYearChecker(){
            Console.Write("Enter a year: ");
            int year=Convert.ToInt32(Console.ReadLine());
            if(year%400==0 || (year%4==0 && year%100!=0)){
                Console.WriteLine($"{year} is a leap year.");
            }
            else{
                Console.WriteLine($"{year} is not a leap year.");
            }
        }

        //Task3 ends here

        //Task4 starts: Quadratic Equation:


        public void QuadraticEquation(){
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

        //Task4 ends here

        //Task5 starts: Admission Eligibility

        public void AdmissionEligibilty(){
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
        //Task5 ends here


        //TASK15 STARTS HERE: Fibonacci Series
        public void FibonacciSeries(){
            try{
                Console.WriteLine("Enter nth number to get first nth terms of series: ");
                int num=Convert.ToInt32(Console.ReadLine());

                int prev2=0;
                int prev1=1;
                Console.Write($"{prev2} {prev1} ");
                int cur=0;

                for(int i=2;i<=num;i++){
                    cur=prev2+prev1;
                    Console.Write($"{cur} ");
                    prev2=prev1;
                    prev1=cur;
                }
            }
            catch(Exception e){
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }

        //TASK15 ENDS HERE

        //Task16 starts: Prime Number Checker

        

        



        
        


    }
}
