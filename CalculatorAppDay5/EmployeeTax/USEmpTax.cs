using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTax
{
    /// <summary>
    /// Tax calculation logic for Indian employees.
    /// </summary>
    public class USEmpTax:CalTax
    {
        public override double CalculateTax()
        {
            // Let's say US have 25% tax
            return Salary * 0.25;
        }
    }
}
