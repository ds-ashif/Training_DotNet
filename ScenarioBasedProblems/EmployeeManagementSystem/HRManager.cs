using System;
namespace EmployeeManagementSystem
{
     /// <summary>
    /// HRManager handles employee management operations.
    /// Includes adding employees, grouping by department,
    /// salary calculation, and joining-date filtering.
    /// </summary>
    class HRManager
    {
        #region Fields

        /// <summary>
        /// Stores all employees.
        /// </summary>
        private List<Employee> employees = new List<Employee>();

        /// <summary>
        /// Counter used for auto-generating employee IDs.
        /// </summary>
        private int counter =1;
        #endregion

         #region Employee Operations

         /// <summary>
        /// Adds a new employee with auto-generated ID and current joining date.
        /// </summary>
        /// <param name="name">Employee name</param>
        /// <param name="dept">Department name</param>
        /// <param name="salary">Employee salary</param>
        public void AddEmployee(string name, string dept, double salary)
        {
            string empId = $"E{counter:D3}";
            counter++;

            employees.Add(new Employee{EmployeeId = empId, Name = name, Department = dept, Salary = salary, JoiningDate = DateTime.Now});
        }
        #endregion

        #region Grouping Operations

        /// <summary>
        /// Groups employees by department.
        /// </summary>
        /// <returns>
        /// Sorted dictionary where key is department
        /// and value is list of employees.
        /// </returns>

        public SortedDictionary<string, List<Employee>> GroupEmployeesByDepartment()
        {
            SortedDictionary<string,List<Employee>> groupedbydept=new SortedDictionary<string, List<Employee>>();

            foreach(var employee in employees)
            {
                if (!groupedbydept.ContainsKey(employee.Department))
                {
                    groupedbydept[employee.Department]=new List<Employee>();
                }
                groupedbydept[employee.Department].Add(employee);
            }
            return groupedbydept;
        }
        #endregion

        #region Salary Operations

        /// <summary>
        /// Calculates total salary expense for a department.
        /// </summary>
        /// <param name="department">Department name</param>
        /// <returns>Total salary amount</returns>

        public double CalculateDepartmentSalary(string department)
        {
            double DeptSalary = 0;
            foreach(var emp in employees)
            {
                if(emp.Department == department)
                {
                    DeptSalary += emp.Salary;
                }
            }

            return DeptSalary;
            
        }
        #endregion

        #region Joining Date Filter

        /// <summary>
        /// Returns employees who joined after a given date.
        /// </summary>
        /// <param name="date">Reference joining date</param>
        /// <returns>List of employees joined after the date</returns>

        public List<Employee> GetEmployeesJoinedAfter(DateTime date)
        {
            List<Employee> result = new List<Employee>();

            foreach(var emp in employees)
            {
                if(emp.JoiningDate > date)
                {
                    result.Add(emp);
                }

            }
            return result;
        }
        #endregion
    }
}