using System;
using System.IO;

// TODO:
// 1. Read file content
// 2. Handle FileNotFoundException
// 3. Handle UnauthorizedAccessException
// 4. Ensure resource is closed properly

namespace FileReadingSafety
{
    class FileNotFoundException : Exception
    {
        public FileNotFoundException(string message) : base(message) { }
    }
    class UnauthorizedAccessException : Exception
    {
        public UnauthorizedAccessException(string message) : base(message) { }
    }

    public class FileReader
    {
        static void Main()
        {
            string filePath = "data.txt";
            try
            {
                //using automatically closes the file even if an exception occurs, so no manual closing is needed.
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string content = reader.ReadToEnd();
                    Console.WriteLine("File Content: ");
                    Console.WriteLine(content);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: File not found.");
            }

            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Error: Access denied to the file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("File read operation completed.");
            }
        }
    }
}