using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Applicant
{
    public string? ApplicantId{get; set;}
    public string? ApplicantName{get; set;}
    public string? CurrentLocation{get; set;}
    public string? PreferredjobLocation{get; set;}
    public string? Competency{get; set;}
    public int? PassingYear{get; set;}
}
public class Program
{
    static string filePath = "applicants.json";
    static List<Applicant> _applicants = new List<Applicant>();

    static void Main()
    {
        LoadData();
        while (true)
        {
            Console.WriteLine("\n===== CampusHire Menu =====");
            Console.WriteLine("1. Add Applicant");
            Console.WriteLine("2. Display All");
            Console.WriteLine("3. Search Applicant");
            Console.WriteLine("4. Update Applicant");
            Console.WriteLine("5. Delete Applicant");
            Console.WriteLine("6. Exit");
            Console.Write("Choice: ");

            switch (Console.ReadLine())
            {
                case "1": AddApplicant(); break;
                case "2": DisplayAll(); break;
                case "3": SearchApplicant(); break;
                case "4": UpdateApplicant(); break;
                case "5": DeleteApplicant(); break;
                case "6": SaveData(); return;
                default: Console.WriteLine("Invalid choice"); break;   
            }
        }
    }


    // --------------------Add ----------------------------

    static void AddApplicant()
    {
        var app = new Applicant();
        app.ApplicantId = ReadApplicantId();
        app.ApplicantName = ReadName();
        app.CurrentLocation = ReadLocation("Current Location(Mumbai/Pune/Chennai)", new[]{"Mumbai","Pune","Chennai"});
        app.PreferredjobLocation = ReadLocation("Preferred Location (Mumbai/Pune/Chennai/Delhi/Kolkata/Bangalore): ",new[]{"Mumbai", "Pune", "Chennai", "Delhi", "Kolkata", "Bangalore" });
        app.Competency = ReadLocation( "Competency (.NET/JAVA/ORACLE/Testing): ", new[] { ".NET", "JAVA", "ORACLE", "Testing" });
        app.PassingYear = ReadPassingYear();

        _applicants.Add(app);
        SaveData();
        Console.WriteLine("Applicant Added Successfully");
    }

    //-------------------Display-----------------

    static void DisplayAll()
    {
        if (_applicants.Count == 0)
        {
            Console.WriteLine("No applicants found.");
            return;
        }
        foreach (var a in _applicants)
        {
            Console.WriteLine($"\nID: {a.ApplicantId}");
            Console.WriteLine($"Name: {a.ApplicantName}");
            Console.WriteLine($"Current Location: {a.CurrentLocation}");
            Console.WriteLine($"Preferred Location: {a.PreferredjobLocation}");
            Console.WriteLine($"Competency: {a.Competency}");
            Console.WriteLine($"Passing Year: {a.PassingYear}");
        }
    }

    // ---------------- SEARCH ----------------
    static void SearchApplicant()
    {
        Console.Write("Enter Applicant ID: ");
        string id = Console.ReadLine();

        var a = _applicants.Find(x=>x.ApplicantId==id);
        if (a == null)
        {
            Console.WriteLine("Applicant not found.");
        }
        else
        {
            Console.WriteLine($"Found: {a.ApplicantName}, {a.Competency}");
        }
    }

    // ---------------- UPDATE ----------------
    static void UpdateApplicant()
    {
        Console.Write("Enter Applicant ID: ");
        string id = Console.ReadLine();

        var app = _applicants.Find(a => a.ApplicantId == id);

        if (app == null)
        {
            Console.WriteLine("Applicant not found.");
            return;
        }

        Console.WriteLine("Updating details...");
        app.ApplicantName = ReadName();
        app.PassingYear = ReadPassingYear();

        SaveData();
        Console.WriteLine("Updated successfully.");
    }

    
    // ---------------- DELETE ----------------
    static void DeleteApplicant()
    {
        Console.Write("Enter Applicant ID: ");
        string id = Console.ReadLine();

        _applicants.RemoveAll(a => a.ApplicantId == id);
        SaveData();

        Console.WriteLine("Deleted successfully.");
    }

    // ---------------- VALIDATIONS ----------------
    static string ReadApplicantId()
    {
        while (true)
        {
            Console.Write("Applicant ID (CH123456): ");
            string id = Console.ReadLine();

            if(!string.IsNullOrWhiteSpace(id) && id.Length==8 && id.StartsWith("CH")) return id;

            Console.WriteLine("Invalid ID format.");
        }
    }
    static string ReadName()
    {
        while (true)
        {
            Console.Write("Name (4-15 chars): ");
            string name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name) && name.Length >= 4 && name.Length <= 15) return name;

            Console.WriteLine("Invalid name.");
        }
    }

    static string ReadLocation(string msg, string[] allowed)
    {
        while (true)
        {
            Console.Write(msg);
            string val = Console.ReadLine();

            foreach (var item in allowed)
            {
                if(item.Equals(val,StringComparison.OrdinalIgnoreCase)) return item;
            }

            Console.WriteLine("Invalid option.");
        }
    }

    static int ReadPassingYear()
    {
        while (true)
        {
            Console.Write("Passing Year: ");

            if(int.TryParse(Console.ReadLine(),out int year) && year<=DateTime.Now.Year) return year;

            Console.WriteLine("Invalid year.");
        }
    }







    //-----------------------Storage----------------------------------
    static void SaveData()
    {
        File.WriteAllText(filePath, JsonSerializer.Serialize(_applicants));
    }
    static void LoadData()
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            _applicants = JsonSerializer.Deserialize<List<Applicant>>(json)?? new List<Applicant>();
        }
    }

}
