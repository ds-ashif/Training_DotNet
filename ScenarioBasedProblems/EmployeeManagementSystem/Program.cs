using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace EmployeeManagementSystem
{
    /// <summary>
    /// Application entry point demonstrating HRManager usage.
    /// </summary>
    class Program
    {
        static void Main()
        {
            #region Setup HR Manager

            HRManager hr = new HRManager();
            hr.AddEmployee("Alina","HR",50000);
            hr.AddEmployee("Bob", "IT", 70000);
            hr.AddEmployee("Charlie", "HR", 55000);
            #endregion

            #region Display Grouped Employees
            var grouped = hr.GroupEmployeesByDepartment();
            
            Console.WriteLine("Department-wise Employees:");
            foreach(var dept in grouped)
            {
                Console.WriteLine($"\n{dept.Key}: ");
                foreach(var emp in dept.Value)
                {
                    Console.WriteLine($"{emp.EmployeeId} - {emp.Name}");
                }
            }
            #endregion

            #region Salary Calculation

            Console.WriteLine("\nTotal HR Salary: " + hr.CalculateDepartmentSalary("HR"));

            // var recent = hr.GetEmployeesJoinedAfter(DateTime.Now.AddMinutes(-1));    //AddMinutes(-1) → subtracts 1 minute from current time.
            var recent = hr.GetEmployeesJoinedAfter(new DateTime(2026, 1, 1));
            // var recent = hr.GetEmployeesJoinedAfter(DateTime.Today);
            Console.WriteLine("\nRecently joined employees:");
            foreach (var emp in recent){
                Console.WriteLine(emp.Name);
            }
            #endregion
        }
    }
}