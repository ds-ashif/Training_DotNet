namespace StudentBookManagementWithIndexer
{
    /// <summary>
    /// Provides the entry point for the application.
    /// Purpose: To demonstrate the use of indexers with a Student class managing books.
    /// Learning Outcome: Understand how indexers work with List collections and validation.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            // Create a new Student instance
            Student student1 = new Student();
            student1.RollNo = 107;
            student1.Name = "Ashif";
            student1.Address = "Phagwara Punjab";

            // Add books using indexer
            student1[0] = "Mathematics";
            student1[1] = "Physics";
            student1[2] = "Chemistry";

            // Display student information
            Console.WriteLine("Student's Roll No: " + student1.RollNo);
            Console.WriteLine("Student Name: " + student1.Name);
            Console.WriteLine("Student Address: " + student1.Address);
            Console.WriteLine("Book 1: " + student1[0]);
            Console.WriteLine("Book 2: " + student1[1]);
            Console.WriteLine("Book 3: " + student1[2]);
        }
    }
}
