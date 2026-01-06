using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Serialization
{
    /// <summary>
    /// Represents a student with identifying information, associated books, and a collection of scores.
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Book { get; set; }
        public List<int> Score { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var s = new Student
            {
                Id = 1,
                Name = "John Doe",
                Book = new string[] { "C# Programming", "ASP.NET Core" },
                Score = new List<int> { 85, 90, 95 }
            };

            // Approach A: serialize to string
            var serializerA = new XmlSerializer(typeof(Student));
            using var writer = new StringWriter();
            serializerA.Serialize(writer, s);
            Console.WriteLine(writer.ToString());

            Console.WriteLine("-------------------------------");

            // Approach B: serialize directly to console
            var serializerB = new XmlSerializer(s.GetType());
            serializerB.Serialize(Console.Out, s);
        }
    }
}
