using System;
using Microsoft.VisualBasic;

namespace ActionPredicateFunUse
{
    /// <summary>
    /// Main program class to demonstrate the use of Action, Predicate, and Func delegates.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            
            // Sample employee data
            List<Employee> employees = new List<Employee>
            {
                new Employee(1, "John", 60000, 5),
                new Employee(2, "Jane", 75000, 7),
                new Employee(3, "Mike", 50000, 3),
                new Employee(4, "Emily", 90000, 10)
            };

            EmployeeService service= new EmployeeService();

            // Predicate to filter employees with experience greater than 5 years
            var experiencedEmployees = service.FilterEmployees(employees, e => e.Experience > 5);

            //Action to print employee details

            service.ProcessEmployees(experiencedEmployees, e=>Console.WriteLine($"{e.Name} is experienced"));

            //function to calculate bonus as 10% of salary

            var bonuses = service.CalculateValues(employees, e => e.Salary * 0.1);
            Console.WriteLine("\nBonuses:");
            foreach (var bonus in bonuses)
            {
                Console.WriteLine($"{bonus} is the bonus amunt for {employees.Name}");
            }
        }
    }
}