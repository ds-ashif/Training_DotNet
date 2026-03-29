using Microsoft.AspNetCore.Mvc;
using ECommerce.IdentityService.Data;
using ECommerce.IdentityService.Models;
using ECommerce.IdentityService.DTOs;
using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerce.IdentityService.Controllers
{
    /// <summary>
    /// Handles authentication-related operations such as user registration and login.
    /// Provides JWT token generation for authenticated users.
    /// </summary>
    
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Private Fields

        /// <summary>
        /// Database context for accessing user data.
        /// </summary>
        private readonly AppDbContext _context;

        /// <summary>
        /// Configuration instance for accessing JWT settings.
        /// </summary>
        private readonly IConfiguration _config;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="context">Database context instance</param>
        /// <param name="config">Application configuration</param>
        public AuthController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        #endregion

        #region Public API Methods

        /// <summary>
        /// Registers a new user in the system.
        /// </summary>
        /// <param name="dto">User registration data transfer object</param>
        /// <returns>
        /// Returns BadRequest if email already exists,
        /// otherwise returns success message.
        /// </returns>
        [HttpPost("signup")]
        public IActionResult Register(RegisterDto dto)
        {
            // Check if a user with the given email already exists
            if (_context.Users.Any(u => u.Email == dto.Email))
                return BadRequest("Email already exists");

            // Create a new user entity and hash the password
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = dto.Role
            };

            // Save the user to the database
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("User registered successfully");
        }

        /// <summary>
        /// Authenticates a user and returns a JWT token if credentials are valid.
        /// </summary>
        /// <param name="dto">User login data transfer object</param>
        /// <returns>
        /// Returns Unauthorized if credentials are invalid,
        /// otherwise returns JWT token.
        /// </returns>
        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            // Retrieve user by email
            var user = _context.Users.FirstOrDefault(u => u.Email == dto.Email);

            // Validate user existence and password
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return Unauthorized("Invalid credentials");

            // Generate JWT token for authenticated user
            var token = GenerateJwtToken(user);

            return Ok(new { token });
        }

        #endregion

        #region Private Helper Methods

        /// <summary>
        /// Generates a JWT token for the authenticated user.
        /// </summary>
        /// <param name="user">Authenticated user</param>
        /// <returns>Signed JWT token string</returns>
        private string GenerateJwtToken(User user)
        {
            // Create security key using secret key from configuration
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            // Define claims to include in the token
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            // Create JWT token
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            // Return serialized token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion
    }
}