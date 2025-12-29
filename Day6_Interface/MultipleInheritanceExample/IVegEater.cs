using System;

namespace MultipleInheritanceExample
{
    /// <summary>
    /// Defines behavior for vegetarian eaters.
    /// </summary>
    /// <remarks>
    /// This interface represents entities capable of consuming
    /// vegetarian food and expressing taste preference.
    /// </remarks>
    public interface IVegEater
    {
        /// <summary>
        /// Performs vegetarian eating behavior.
        /// </summary>
        void EatVeg();

        /// <summary>
        /// Displays taste preference for vegetarian food.
        /// </summary>
        void GetTaste();
    }
}
