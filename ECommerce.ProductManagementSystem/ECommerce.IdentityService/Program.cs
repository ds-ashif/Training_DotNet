using ECommerce.IdentityService.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

/// <summary>
/// Entry point of the Identity/Auth microservice.
/// Responsible for configuring services, middleware pipeline,
/// JWT authentication, database connection, and API endpoints.
/// </summary>
var builder = WebApplication.CreateBuilder(args);

#region Service Configuration

// DATABASE CONFIG
// Configure Entity Framework Core with SQL Server using connection string from appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// JWT CONFIG
// Configure JWT-based authentication for securing API endpoints
var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);

builder.Services.AddAuthentication(options =>
{
    // Set default authentication and challenge schemes to JWT Bearer
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    // Disable HTTPS metadata requirement (should be true in production)
    options.RequireHttpsMetadata = false;

    // Save token in authentication properties
    options.SaveToken = true;

    // Define token validation parameters
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // Validate the issuer (who generated the token)
        ValidateIssuer = true,

        // Audience validation is disabled for simplicity (can be enabled in production)
        ValidateAudience = false,

        // Valid issuer from configuration
        ValidIssuer = builder.Configuration["Jwt:Issuer"],

        // Validate token signature using symmetric key
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});


// CONTROLLERS
// Register controller services to handle HTTP requests
builder.Services.AddControllers();


// SWAGGER CONFIG (UPDATED)
// Enable API documentation and testing UI (useful during development and testing)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion


#region Application Pipeline Configuration

var app = builder.Build();

// MIDDLEWARE ORDER (IMPORTANT)
// Middleware execution order affects request handling and security behavior

// Swagger middleware - exposes API documentation endpoints
app.UseSwagger();
app.UseSwaggerUI();

// Authentication middleware - validates JWT tokens
app.UseAuthentication();

// Authorization middleware - enforces role-based access control
app.UseAuthorization();

// Map controller routes to endpoints
app.MapControllers();

// Start the application
app.Run();

#endregion