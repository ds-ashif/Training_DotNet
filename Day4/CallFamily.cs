using System;

namespace Day4Constructor
{
    /// <summary>
    /// Entry point class responsible for demonstrating
    /// runtime polymorphism using Father and Son classes.
    /// </summary>
    
    class CallFamily
    {
        #region Application Entry Point

        /// <summary>
        /// Main method – execution starts here.
        /// Demonstrates method overriding and polymorphism.
        /// </summary>

        public static void Main(String[] args)
        {
            Father f=new Father();
            Console.WriteLine(f.InterestOn());

            Son s=new Son();
            Console.WriteLine(s.InterestOn());

        }

        #endregion
    }
}