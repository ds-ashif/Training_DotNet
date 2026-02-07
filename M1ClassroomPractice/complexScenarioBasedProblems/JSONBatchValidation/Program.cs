using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;

#region Models

// Represents a single customer application coming from JSON input
public class CustomerApplication
{
    public string ApplicationId { get; set; } // Unique application id
    public string FullName { get; set; }      // Customer name
    public string Email { get; set; }         // Customer email
    public int? Age { get; set; }             // Nullable to detect missing value
    public string PAN { get; set; }           // PAN number
}

// Stores validation result for one record
public class RecordValidationResult
{
    public int RecordIndex { get; set; }          // Position in batch
    public bool IsValid { get; set; }             // Record valid or not
    public List<string> Errors { get; set; } = new(); // Error list
}

// Final batch report
public class ValidationReport
{
    public int TotalRecords { get; set; }      // Total records processed
    public int ValidRecords { get; set; }      // Valid records count
    public int InvalidRecords { get; set; }    // Invalid records count

    // Individual record results
    public List<RecordValidationResult> Results { get; set; } = new();
}

#endregion

// Handles validation of JSON batch
public class ApplicationBatchValidator
{
    // Simple email format validation
    // Example: user@mail.com
    private static readonly Regex EmailRegex = new(@"^\S+@\S+\.\S+$");

    // PAN format: AAAAA9999A
    private static readonly Regex PanRegex = new(@"^[A-Z]{5}[0-9]{4}[A-Z]$", RegexOptions.IgnoreCase);

    // Main method to validate all payloads
    public ValidationReport ValidateBatch(List<string> payloads)
    {
        var report = new ValidationReport
        {
            TotalRecords = payloads.Count
        };

        // Validate each record
        for (int i = 0; i < payloads.Count; i++)
        {
            var result = ValidateSingle(payloads[i], i);
            report.Results.Add(result);

            // Count valid vs invalid
            if (result.IsValid)
                report.ValidRecords++;
            else
                report.InvalidRecords++;
        }

        return report;
    }

    // Validate one JSON record
    private RecordValidationResult ValidateSingle(string json, int index)
    {
        var result = new RecordValidationResult
        {
            RecordIndex = index
        };

        CustomerApplication app;

        // Attempt JSON parsing
        try
        {
            app = JsonSerializer.Deserialize<CustomerApplication>(json, new JsonSerializerOptions{PropertyNameCaseInsensitive = true});
        }
        catch
        {
            // Invalid JSON structure
            result.Errors.Add("Invalid JSON");
            result.IsValid = false;
            return result;
        }

        // Mandatory field checks
        if (string.IsNullOrWhiteSpace(app.ApplicationId))
            result.Errors.Add("ApplicationId required");

        if (string.IsNullOrWhiteSpace(app.FullName))
            result.Errors.Add("FullName required");

        // Email validation
        if (string.IsNullOrWhiteSpace(app.Email))
            result.Errors.Add("Email required");
        else if (!EmailRegex.IsMatch(app.Email))
            result.Errors.Add("Invalid email");

        // Age validation
        if (!app.Age.HasValue)
            result.Errors.Add("Age required");
        else if (app.Age < 18 || app.Age > 60)
            result.Errors.Add("Age must be 18–60");

        // PAN validation
        if (string.IsNullOrWhiteSpace(app.PAN))
            result.Errors.Add("PAN required");
        else if (!PanRegex.IsMatch(app.PAN))
            result.Errors.Add("Invalid PAN");

        // Record valid if no errors found
        result.IsValid = result.Errors.Count == 0;

        return result;
    }
}

// Program entry point
class Program
{
    static void Main()
    {
        // Sample batch input
        var inputs = new List<string>
        {
            // Valid record
            "{\"ApplicationId\":\"A1\",\"FullName\":\"John\",\"Email\":\"john@mail.com\",\"Age\":30,\"PAN\":\"ABCDE1234F\"}",

            // Invalid record
            "{\"ApplicationId\":\"A2\",\"FullName\":\"Mary\",\"Email\":\"wrong\",\"Age\":15,\"PAN\":\"123\"}"
        };

        var validator = new ApplicationBatchValidator();
        var report = validator.ValidateBatch(inputs);

        // Display summary
        Console.WriteLine($"Valid: {report.ValidRecords}");
        Console.WriteLine($"Invalid: {report.InvalidRecords}");
    }
}
