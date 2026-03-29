namespace ECommerce.IdentityService.DTOs
{
    /// <summary>
    /// Data Transfer Object used for user registration.
    /// Contains all required information to create a new user account.
    /// </summary>
    public class RegisterDto
    {
        #region Properties

        /// <summary>
        /// Gets or sets the full name of the user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the user's email address.
        /// This will be used as a unique identifier.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the user's password.
        /// This will be hashed before storing in the database.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the role assigned to the user (e.g., Admin, Customer).
        /// </summary>
        public string Role { get; set; }

        #endregion
    }
}