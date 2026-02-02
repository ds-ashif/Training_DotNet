using System;
using System.Collections.Generic;

namespace PredicateDelegateUsage
{
    /// <summary>
    /// Class to process data using Predicate delegate.
    /// </summary>
    public class ProcessData
    {
        /// <summary>
        /// Filters data based on the provided predicate condition.
        /// </summary>
        
        public List<T> FilterData<T>(List<T> data, Predicate<T> condition)
        {
            // Filtering data using the predicate condition
            var result= new List<T>();

            // Iterate through each item and apply the condition
            foreach(var item in data)
            {
                if (condition(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

    }
}