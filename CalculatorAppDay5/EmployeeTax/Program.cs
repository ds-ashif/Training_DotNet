namespace EmployeeTax
{
    /// <summary>
    /// Entry point of the EmployeeTax application.
    /// Demonstrates polymorphic tax calculation for employees
    /// from different countries using a common base type.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application execution starts here.
        /// Creates employee tax objects and prints calculated tax.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments (not used in this application).
        /// </param>



        static void Main(string[] args)
        {
            CalTax indianEmpTax = new IndianEmpTax { Name = "Rahul", Salary = 900000 };
            CalTax usEmpTax = new USEmpTax { Name = "Allen", Salary = 80000 };

            Console.WriteLine($"Indian Employee Tax: {indianEmpTax.CalculateTax()}");
            Console.WriteLine($"US Employee Tax: {usEmpTax.CalculateTax()}");
        }
    }
}
