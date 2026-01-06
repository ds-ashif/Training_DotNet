namespace StaticClassesAndMemebers
{
    /// <summary>
    /// Provides the entry point for the application.
    /// Purpose: To demonstrate static classes and members in C#.
    /// Learning Outcome: Understand how static classes work and when to use them.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Static Class Demo ===");
            Console.WriteLine();

            // First call to static class - triggers static constructor
            int rollNo1 = StaticLearning.GetRollNo();
            Console.WriteLine("First call - Roll No: " + rollNo1);

            // Second call to static class - constructor NOT called again
            int rollNo2 = StaticLearning.GetRollNo();
            Console.WriteLine("Second call - Roll No: " + rollNo2);

            Console.WriteLine();

            // Using static utility method
            string name = "Hello World";
            int count = StaticLearning.WordCount(name);
            Console.WriteLine("String: " + name);
            Console.WriteLine("Number of characters in the string: " + count);
        }
    }
}
