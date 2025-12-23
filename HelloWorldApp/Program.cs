// using System;

// namespace HelloWorldApp
// {
//     class Program
//     {
//         public static void Main(string[] args)
//         {
//             // CheckEven ce = new CheckEven();
//             // ce.CheckEvenOrOdd();

//             //   Tasks t = new Tasks();
//             //   t.HeightCategory();
//             //   t.LargestOfThree();
//             //   t.LeapYearChecker();
//             //  t.QuadraticEquation();
//              //t.AdmissionEligibilty();
//             //  t.FibonacciSeries();

//             // Student st=new Student();
//             // st.GetDetails();

//             // Student st=new Student();
//             // st.Name="Ashif";
//             // st.GetDetails();

//             // Student st=new Student();
//             // st.Name="Ashif";
//             // st.GetDetails();

//             // Student st=new Student(){Name="Ashif", Department="Btech",}  //if dont eeant input

//             // Employee emp=new Employee();
//             // Compitition cmp=new Compitition();
//             // ResultDetails res=new ResultDetails();

//             // emp.GetEmployeeDetails();
//             // cmp.GetCompitionDetails();
//             // res.Results();


//         }


            



            

//     }
// }


using System;
using System.Collections.Generic;


namespace HelloWorldApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            // fixed size arrays
            Employee[] employees = new Employee[10];
            Compitition[] competitions = new Compitition[10];
            ResultDetails[] results = new ResultDetails[10];

            int empCount = 0;
            int compCount = 0;
            int resCount = 0;

            string? choice;

            do
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Add Competition");
                Console.WriteLine("3. Add Result");
                Console.WriteLine("Press q to finish input");

                choice = Console.ReadLine();

                if (choice == "1")
                {
                    if (empCount < employees.Length)
                    {
                        employees[empCount] = new Employee();
                        empCount++;
                    }
                    else
                    {
                        Console.WriteLine("Employee array is full");
                    }
                }
                else if (choice == "2")
                {
                    if (compCount < competitions.Length)
                    {
                        competitions[compCount] = new Compitition();
                        compCount++;
                    }
                    else
                    {
                        Console.WriteLine("Competition array is full");
                    }
                }
                else if (choice == "3")
                {
                    if (resCount < results.Length)
                    {
                        results[resCount] = new ResultDetails();
                        resCount++;
                    }
                    else
                    {
                        Console.WriteLine("Result array is full");
                    }
                }
                else if (choice == "q" || choice == "Q")
                {
                    Console.WriteLine("\nInput finished. Displaying all details...\n");
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }

            } while (choice != "q" && choice != "Q");

            // 🔹 DISPLAY ALL DETAILS AT ONCE

            Console.WriteLine("===== EMPLOYEE DETAILS =====");
            for (int i = 0; i < empCount; i++)
            {
                employees[i].GetEmployeeDetails();
            }

            Console.WriteLine("\n===== COMPETITION DETAILS =====");
            for (int i = 0; i < compCount; i++)
            {
                competitions[i].GetCompitionDetails();
            }

            Console.WriteLine("\n===== RESULT DETAILS =====");
            for (int i = 0; i < resCount; i++)
            {
                results[i].Results();
            }
        }
    }
}
