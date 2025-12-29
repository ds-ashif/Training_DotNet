using System;

namespace Day7_MultipleInheritance
{
    /// <summary>
    /// Defines basic bird behaviors such as flying and eating.
    /// </summary>
    public interface IBird1
    {
        /// <summary>
        /// Allows the bird to fly.
        /// </summary>
        void Fly();

        /// <summary>
        /// Allows the bird to eat.
        /// </summary>
        void Eat();
    }
}
