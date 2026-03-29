namespace ECommerce.IdentityService.DTOs
{
    /// <summary>
    /// Data Transfer Object used for user login requests.
    /// Contains credentials required for authentication.
    /// </summary>
    public class LoginDto
    {
        #region Properties

        /// <summary>
        /// Gets or sets the user's email address.
        /// Used as the unique identifier for authentication.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the user's password.
        /// This will be validated against the stored password hash.
        /// </summary>
        public string Password { get; set; }

        #endregion
    }
}