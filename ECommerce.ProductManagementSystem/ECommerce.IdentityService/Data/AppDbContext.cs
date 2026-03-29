using Microsoft.EntityFrameworkCore;
using ECommerce.IdentityService.Models;

namespace ECommerce.IdentityService.Data
{
    /// <summary>
    /// Represents the application's database context.
    /// Handles entity configuration and database access using Entity Framework Core.
    /// </summary>
    public class AppDbContext : DbContext
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options">
        /// The options to be used by the DbContext, typically configured in Startup/Program.
        /// </param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        #endregion

        #region DbSets

        /// <summary>
        /// Represents the Users table in the database.
        /// Provides access to user-related data.
        /// </summary>
        public DbSet<User> Users { get; set; }

        #endregion
    }
}