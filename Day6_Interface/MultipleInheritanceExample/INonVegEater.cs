using System;

namespace MultipleInheritanceExample
{
    /// <summary>
    /// Defines behavior for non-vegetarian eaters.
    /// </summary>
    /// <remarks>
    /// This interface represents entities capable of consuming
    /// non-vegetarian food and expressing taste preference.
    /// </remarks>
    public interface INonVegEater
    {
        /// <summary>
        /// Performs non-vegetarian eating behavior.
        /// </summary>
        void EatNonVeg();

        /// <summary>
        /// Displays taste preference for non-vegetarian food.
        /// </summary>
        void GetTaste();
    }
}
