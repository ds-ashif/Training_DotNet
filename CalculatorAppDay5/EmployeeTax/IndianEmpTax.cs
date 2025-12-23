using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTax
{
    /// <summary>
    /// Tax calculation logic for Indian employees.
    /// </summary>
    public class IndianEmpTax:CalTax
    {
        public override double CalculateTax()
        {
            // Let's say 10% tax for salary up to 10L, else 20%
            if (Salary <= 1000000)
                return Salary * 0.10;

            return Salary * 0.20;
        }
    }
}
