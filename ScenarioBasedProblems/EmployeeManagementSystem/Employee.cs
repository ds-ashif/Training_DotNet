using System;
namespace EmployeeManagementSystem
{
     /// <summary>
    /// Represents an employee in the organization.
    /// Stores employee identity, department, salary, and joining date.
    /// </summary>
    class Employee
    {
        /// <summary>
        /// Unique employee identifier
        /// </summary>

        public string EmployeeId{get; set;}

        /// <summary>
        /// Employee full name.
        /// </summary>
        public string Name{get; set;}

        /// <summary>
        /// Department where employee works.
        /// </summary>
        public string Department{get; set;}

        /// <summary>
        /// Employee salary.
        /// </summary>
        public double Salary{get; set;}

         /// <summary>
        /// Date employee joined the company.
        /// </summary>
        public DateTime JoiningDate{get; set;}
    }
}