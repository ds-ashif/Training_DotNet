namespace PropertiesAndConstructors
{
    /// <summary>
    /// Provides the entry point for the application.
    /// Purpose: To demonstrate properties with private setters and constructor overloading.
    /// Learning Outcome: Understand property access control and constructor usage.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            // Using default constructor
            YoungProfessional yp1 = new YoungProfessional();
            yp1.Name = "John Doe";
            yp1.RNo = 501;
            yp1.SetPersonalId(12345);
            yp1.SetDateOfBirth("1995-05-15");

            Console.WriteLine("=== Young Professional 1 ===");
            Console.WriteLine("Name: " + yp1.Name);
            Console.WriteLine("Registration No: " + yp1.RNo);
            Console.WriteLine("Personal ID: " + yp1.PersonalId);
            Console.WriteLine("Date of Birth: " + yp1.DateOfBirth);

            Console.WriteLine(); // Empty line

            // Using parameterized constructor
            YoungProfessional yp2 = new YoungProfessional("1998-08-20");
            yp2.Name = "Jane Smith";
            yp2.RNo = 502;
            yp2.SetPersonalId(67890);

            Console.WriteLine("=== Young Professional 2 ===");
            Console.WriteLine("Name: " + yp2.Name);
            Console.WriteLine("Registration No: " + yp2.RNo);
            Console.WriteLine("Personal ID: " + yp2.PersonalId);
            Console.WriteLine("Date of Birth: " + yp2.DateOfBirth);
        }
    }
}
