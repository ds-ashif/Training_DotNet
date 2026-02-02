namespace ActionPredicateFunUse
{
    /// <summary>
    /// Represents an employee with basic details such as Id, Name, Salary, and Experience.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the unique identifier for the employee.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the salary of the employee.
        /// </summary>
        public double Salary { get; set; }

        /// <summary>
        /// Gets or sets the years of experience of the employee.
        /// </summary>
        public int Experience { get; set; }

        /// <summary>
        /// Initializes a new instance of the Employee class with specified details.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="salary"></param>
        /// <param name="experience"></param>
        public Employee(int id, string name, double salary, int experience)
        {
            Id = id;
            Name = name;
            Salary = salary;
            Experience = experience;
        }
    }
}