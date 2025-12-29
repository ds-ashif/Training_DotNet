using System;

namespace Day7_MultipleInheritance
{
    /// <summary>
    /// Defines bird movement behaviors such as swimming and walking.
    /// </summary>
    public interface IBird2
    {
        /// <summary>
        /// Allows the bird to swim.
        /// </summary>
        void Swim();

        /// <summary>
        /// Allows the bird to walk.
        /// </summary>
        void Walk();
    }
}
