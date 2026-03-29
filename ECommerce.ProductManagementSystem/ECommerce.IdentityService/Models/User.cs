using System.ComponentModel.DataAnnotations;

namespace ECommerce.IdentityService.Models
{
    /// <summary>
    /// Represents an application user within the Identity/Auth microservice.
    /// This entity is used for authentication, authorization, and role-based access control.
    /// </summary>
    public class User
    {
        #region Properties

        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// Primary key in the database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the full name of the user.
        /// Required for identification in admin and operational interfaces.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the user's email address.
        /// Acts as a unique login identifier for authentication.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the hashed password of the user.
        /// Passwords are securely stored using BCrypt hashing.
        /// </summary>
        [Required]
        public string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the role assigned to the user.
        /// Used for role-based authorization across microservices (e.g., Admin, ProductManager, ContentExecutive).
        /// </summary>
        [Required]
        public string Role { get; set; }  // Admin, ProductManager, ContentExecutive

        /// <summary>
        /// Gets or sets a value indicating whether the user account is active.
        /// Inactive users are typically restricted from authentication and API access.
        /// </summary>
        public bool IsActive { get; set; } = true;

        #endregion
    }
}