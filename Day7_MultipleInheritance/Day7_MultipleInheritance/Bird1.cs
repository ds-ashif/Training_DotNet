using System;

namespace Day7_MultipleInheritance
{
    /// <summary>
    /// Represents a bird that demonstrates multiple inheritance
    /// using interfaces.
    /// </summary>
    public class Bird1 : IBird1, IBird2
    {
        /// <summary>
        /// Allows the bird to fly.
        /// </summary>
        public void Fly()
        {
            Console.WriteLine("Bird can fly");
        }

        /// <summary>
        /// Allows the bird to eat.
        /// </summary>
        public void Eat()
        {
            Console.WriteLine("Bird can eat");
        }

        /// <summary>
        /// Allows the bird to swim.
        /// </summary>
        public void Swim()
        {
            Console.WriteLine("Bird can swim");
        }

        /// <summary>
        /// Allows the bird to walk.
        /// </summary>
        public void Walk()
        {
            Console.WriteLine("Bird can walk");
        }

        /// <summary>
        /// Additional behavior specific to Bird1.
        /// </summary>
        public void Chirp()
        {
            Console.WriteLine("Bird can chirp");
        }
    }
}
