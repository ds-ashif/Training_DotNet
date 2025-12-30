using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTax
{
    /// <summary>
    /// Abstract base class that defines common properties
    /// and behavior for employee tax calculation.
    /// </summary>
    /// 

    public abstract class CalTax

































































    {
        #region properties

        public string Name {  get; set; }
        public double Salary { get; set; }

        #endregion

        #region Abstract Methods
        /// <summary>
        /// Calculates tax based on country-specific rules.
        /// </summary>
        /// <returns>Calculated tax amount.</returns>

        public abstract double CalculateTax();

        #endregion

    }
}
