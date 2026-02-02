using System;
using System.Collections.Generic;
namespace Students
{
    public class AverageCalculator<T> where T :IMarks
    {
        /// <summary>
        /// Calculates the average marks of the given item.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public double CalculateAverage(T item)
        {
            return (item.MathsMarks + item.ScienceMarks + item.EnglishMarks) / 3.0;
        }

        /// <summary>
        /// Calculates the class average for a list of items.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public double CalculateClassAverage(List<T> items)
        {
            double total = 0;
            foreach (var item in items)
            {
                total += CalculateAverage(item);
            }
            return total / items.Count;
        }
    }
}