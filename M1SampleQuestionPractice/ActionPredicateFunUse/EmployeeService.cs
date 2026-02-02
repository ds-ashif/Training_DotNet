using System;
using System.Collections.Generic;


namespace ActionPredicateFunUse
{
    public class EmployeeService
    {
        //predicate condition

        /// <summary>
        /// Filters employees based on the provided predicate condition.
        /// </summary>
        /// <param name="employees"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public List<Employee> FilterEmployees(List<Employee> employees , Predicate<Employee> condition)
        {
            List<Employee> result= new List<Employee>();
            foreach(var emp in employees)
            {
                if (condition(emp))
                {
                    result.Add(emp);
                }
            }

            return result;
        }

        //action delegate

        /// <summary>
        /// Processes each employee using the provided Action delegate.
        /// </summary>
        /// <param name="employees"></param>
        /// <param name="action"></param>

        public void ProcessEmployees(List<Employee> employees, Action<Employee> action)
        {
            foreach(var emp in employees)
            {
                action(emp);
            }
        }

        //function  -> return value
        /// <summary>
        /// Calculates values for each employee using the provided Func delegate.
        /// </summary>
        /// <param name="employees"></param>
        /// <param name="calculator"></param>
        /// <returns></returns>
        public List<double> CalculateValues(List<Employee> employees, Func<Employee, double> calculator)
        {
            List<double> value=new List<double>();
            foreach(var emp in employees)
            {
                value.Add(calculator(emp));
            }
            return value;   
        }

    }

}