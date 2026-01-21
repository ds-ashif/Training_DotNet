using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace StudentsListFormatting
{
    /// <summary>
    /// Represents a student with name and score.
    /// </summary>
    /// <param name="Name">Student name</param>
    /// <param name="Score">Student score</param>
    public record Student(string Name, int Score);

    /// <summary>
    /// Provides functionality to parse student data,
    /// filter by score, sort, and serialize to JSON.
    /// </summary>
    public class StudentScoreList
    {
        #region Core Logic

        /// <summary>
        /// Converts student string data into a filtered and sorted JSON array.
        /// </summary>
        /// <param name="data">Array of strings in format "Name:Score"</param>
        /// <param name="minScore">Minimum score for filtering</param>
        /// <returns>JSON string of filtered students</returns>
        public static string StudentsDataToJson(string[] data, int minScore)
        {
            if(data==null || data.Length==0) return "[]";
            List<Student> students = new();

            foreach (string item in data)
            {
                string[] parts = item.Split(':');
                if (parts.Length != 2) continue;

                string name = parts[0];
                int score = int.Parse(parts[1]);

                students.Add(new Student(name, score));
            }

            var result = students
                .Where(s => s.Score >= minScore)
                .OrderByDescending(s => s.Score)
                .ThenBy(s => s.Name)
                .ToList();

            return JsonSerializer.Serialize(result);
        }

        #endregion

        #region Program Entry Point

        /// <summary>
        /// Program entry point to demonstrate student list formatting.
        /// </summary>
        public static void Main()
        {
            string[] data =
            {
                "Ashif:85",
                "Arshil:99",
                "Asad:99",
                "Zubair:50",
                "Sajid:100",
                "Kamal:65",
                "Junaid:45"
            };

            Console.Write("Enter minScore: ");
            int minScore = int.Parse(Console.ReadLine()!);

            string jsonResult = StudentsDataToJson(data, minScore);
            Console.WriteLine(jsonResult);
        }

        #endregion
    }
}
