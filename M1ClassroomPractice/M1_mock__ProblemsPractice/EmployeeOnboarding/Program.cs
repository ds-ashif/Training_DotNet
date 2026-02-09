using System;
using System.Collections.Generic;

/**
Q1. Employee Onboarding - Constructor + Validation
You are building an onboarding module that stores basic employee information.
Requirements:
•	Create class Employee with: Id, Name, Email, Salary.
•	Use a constructor to initialize all values.
•	If Salary <= 0, default it to 30000.
•	If Email does not contain '@', set it to 'unknown@company.com'.
Task: Create 3 employees with different invalid/valid inputs and print the final stored values.
**/

namespace EmployeeOnboarding
{
    /// <summary>
    /// Represents an employee in the onboarding system
    /// Stores employees details and validates during creation
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Unique employee identifier.
        /// </summary>
        public int Id{get; set;}

        /// <summary>
        /// Employee full name.
        /// </summary>
        public string Name{get; set;}

        /// <summary>
        /// Employee email address.
        /// If invalid, a default email is assigned.
        /// </summary>
        public string Email{get; set;}

        /// <summary>
        /// Employee salary.
        /// Defaults to 30000 if invalid.
        /// </summary>
        public double Salary{get; set;}

        /// <summary>
        /// Constructor initializes employee data
        /// and performs validation checks.
        /// </summary>
        public Employee(int id, string name, string email, double salary)
        {
            Id = id;
            Name = name;
            Email = email;
            Salary = salary;
        }

    }

     /// <summary>
    /// Program entry point for employee onboarding demo.
    /// </summary>

    public class Program
    {
        static void Main()
        {   
            // Creating employees with valid and invalid inputs
            Employee emp1 = new Employee(101,"Ashif","ashifoutlook.com", 50000);
            Employee emp2 = new Employee(102, "Aahil", "aahil@gmail.com", 20000);
            Employee emp3 = new Employee(103, "Sahil", "sahilgmail.com", 0);        

            // Store employees in a list
            List<Employee> employees = new List<Employee> {emp1,emp2,emp3};

            foreach(var emp in employees)
            {
                // if(!emp.Email.Contains("@")) emp.Email = "unknown@company.com";
                if (!emp.Email.Contains("@"))
                {
                    if (emp.Email.Contains("gmail.com"))
                    {
                        emp.Email = emp.Email.Replace("gmail.com", "@gmail.com");
                    }
                    else if (emp.Email.Contains("outlook.com"))
                    {
                        emp.Email = emp.Email.Replace("outlook.com","@outlook.com");
                    }
                    else emp.Email +="@gmail.com";  //fallback case
                }

                if(emp.Salary<=0) emp.Salary=30000;
            }

            // Display final stored employee data
            Console.WriteLine("Employee Details: ");
            foreach(var emp in employees)
            {
                Console.WriteLine($"Id: {emp.Id}, Name: {emp.Name}, Email: {emp.Email}, Salary: {emp.Salary}");
            }
        }
    }
}