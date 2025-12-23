using System;

namespace Day4Constructor
{
    /// <summary>
    /// Represents a base class that defines common behavior for all family members.
    /// </summary>
    public class Father
    {
        #region Public Methods

         /// <summary>
        /// Returns the interest or hobby of the Father.This method is marked virtual to allow derived classes to provide their own implementation.
        /// </summary>
        


        /// <returns>
        /// A string describing the Father's interest.
        /// </returns>
        
        public virtual string InterestOn()
        {
            return "Father like to play cricket.";
        }
        #endregion
    }

    /// <summary>
    /// Represents a child class that inherits from Father and overrides its behavior.
    /// </summary>
    
    
  
        
    /// <returns>
    /// A string describing the Son's interest.
    /// </returns>

    public class Son : Father
    {
        #region Public Methods

        /// <summary>
        /// Overrides the InterestOn method to provide the Son's specific interest.
        /// </summary>
        
        /// <returns>
        /// A string describing the Son's interest.
        /// </returns>


        public override string InterestOn()
        {
            return "Child like to play Football";
        }
        #endregion

    }
}