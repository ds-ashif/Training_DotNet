using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ECommerce.IdentityService.Data
{
    /// <summary>
    /// Factory class used at design-time to create instances of <see cref="AppDbContext"/>.
    /// This is primarily used by Entity Framework Core tools...
    /// </summary>
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        #region Public Methods

        /// <summary>
        /// Creates a new instance of <see cref="AppDbContext"/> for design-time operations.
        /// </summary>
        /// <param name="args">Command-line arguments</param>
        /// <returns>A configured instance of <see cref="AppDbContext"/></returns>
        public AppDbContext CreateDbContext(string[] args)
        {
            // Get the current directory path where the application is running
            var basePath = Directory.GetCurrentDirectory();

            // Build configuration by reading appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            // Create DbContext options builder
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Configure SQL Server using connection string from configuration
            optionsBuilder.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"));

            // Return a new instance of AppDbContext with configured options
            return new AppDbContext(optionsBuilder.Options);
        }

        #endregion
    }
}