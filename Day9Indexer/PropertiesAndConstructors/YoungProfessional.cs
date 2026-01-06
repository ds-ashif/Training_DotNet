using System;
using System.Collections.Generic;
using System.Text;

namespace PropertiesAndConstructors
{
    /// <summary>
    /// Represents a young professional with identifying information and personal details.
    /// </summary>
    public class YoungProfessional
    {
        // Default Constructor
        public YoungProfessional()
        {
        }

        // Parameterized Constructor
        public YoungProfessional(string dob)
        {
            DateOfBirth = dob; // Set DateOfBirth using the parameter
        }

        public int PersonalId { get; private set; } // Private setter - can only be set within the class
        public int RNo { get; set; } // Public getter and setter
        public string DateOfBirth { get; private set; } // Private setter - requires method to change
        public string Name { get; set; } // Public getter and setter

        /// <summary>
        /// Method to set DateOfBirth since the setter is private.
        /// This provides controlled access to the private setter.
        /// </summary>
        public void SetDateOfBirth(string dateOfBirth)
        {
            DateOfBirth = dateOfBirth;
        }

        /// <summary>
        /// Method to set PersonalId since the setter is private.
        /// </summary>
        public void SetPersonalId(int id)
        {
            PersonalId = id;
        }
    }
}
