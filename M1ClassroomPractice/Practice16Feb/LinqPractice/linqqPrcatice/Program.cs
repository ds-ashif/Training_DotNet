using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public int Marks { get; set; }
    public int DeptId { get; set; }
}

public class Department
{
    public int Id { get; set; }
    public string DeptName { get; set; } = "";
}

public class Program
{
    static void Main()
    {
        // ---------------- DATA ----------------
        var students = new List<Student>
        {
            new() { Id = 1, Name = "Ravi", Age = 22, Marks = 85, DeptId = 1 },
            new() { Id = 2, Name = "Amit", Age = 21, Marks = 75, DeptId = 2 },
            new() { Id = 3, Name = "Anil", Age = 23, Marks = 90, DeptId = 1 },
            new() { Id = 4, Name = "Suresh", Age = 20, Marks = 65, DeptId = 3 }
        };

        var departments = new List<Department>
        {
            new() { Id = 1, DeptName = "Computer Science" },
            new() { Id = 2, DeptName = "Electronics" },
            new() { Id = 3, DeptName = "Mechanical" }
        };

        // ----------------------------------------------------
        // 1 FILTERING
        // ----------------------------------------------------
        Console.WriteLine("\nStudents scoring above 70:");
        var filtered = students.Where(s => s.Marks > 70);
        foreach (var s in filtered)
            Console.WriteLine(s.Name);

        // ----------------------------------------------------
        // 2 PROJECTION
        // ----------------------------------------------------
        Console.WriteLine("\nStudent Names:");
        var names = students.Select(s => s.Name);
        foreach (var n in names)
            Console.WriteLine(n);

        // ----------------------------------------------------
        // 3 SORTING
        // ----------------------------------------------------
        Console.WriteLine("\nSorted by Marks Desc:");
        var sorted = students.OrderByDescending(s => s.Marks);
        foreach (var s in sorted)
            Console.WriteLine($"{s.Name} - {s.Marks}");

        // ----------------------------------------------------
        // 4 GROUPING
        // ----------------------------------------------------
        Console.WriteLine("\nGrouped by Department:");
        var grouped = students.GroupBy(s => s.DeptId);
        foreach (var group in grouped)
        {
            Console.WriteLine($"Dept {group.Key}:");
            foreach (var s in group)
                Console.WriteLine($"  {s.Name}");
        }

        // ----------------------------------------------------
        // 5 SET OPERATORS
        // ----------------------------------------------------
        var union = new[] { 1, 2 }.Union(new[] { 2, 3 });
        Console.WriteLine("\nUnion Result: " + string.Join(",", union));

        // ----------------------------------------------------
        // 6 QUANTIFIERS
        // ----------------------------------------------------
        Console.WriteLine("\nAny student failed? " +
            students.Any(s => s.Marks < 40));

        Console.WriteLine("All students passed? " +
            students.All(s => s.Marks >= 40));

        // ----------------------------------------------------
        // 7 PARTITIONING
        // ----------------------------------------------------
        Console.WriteLine("\nTop 2 Students:");
        foreach (var s in students.Take(2))
            Console.WriteLine(s.Name);

        // ----------------------------------------------------
        // 8 ELEMENT OPERATORS
        // ----------------------------------------------------
        var first = students.FirstOrDefault();
        Console.WriteLine("\nFirst Student: " + first?.Name);

        // ----------------------------------------------------
        // 9 AGGREGATION
        // ----------------------------------------------------
        Console.WriteLine("\nTotal Students: " + students.Count());
        Console.WriteLine("Average Marks: " +
            students.Average(s => s.Marks));

        // ----------------------------------------------------
        // 10 CONVERSION
        // ----------------------------------------------------
        var dict = students.ToDictionary(s => s.Id);
        Console.WriteLine("\nDictionary created with keys:");
        foreach (var key in dict.Keys)
            Console.WriteLine(key);

        ArrayList arrayList = new() { 1, 2, 3 };
        var casted = arrayList.Cast<int>();
        Console.WriteLine("Cast ArrayList: " +
            string.Join(",", casted));

        // ----------------------------------------------------
        // 11 GENERATION
        // ----------------------------------------------------
        Console.WriteLine("\nRange: " +
            string.Join(",", Enumerable.Range(1, 5)));

        // ----------------------------------------------------
        // 12 JOIN
        // ----------------------------------------------------
        Console.WriteLine("\nStudent with Department:");

        var joined = students.Join(
            departments,
            s => s.DeptId,
            d => d.Id,
            (s, d) => new { s.Name, d.DeptName }
        );

        foreach (var item in joined)
            Console.WriteLine($"{item.Name} - {item.DeptName}");

        // ----------------------------------------------------
        // 13 EQUALITY
        // ----------------------------------------------------
        Console.WriteLine("\nSequences Equal: " +
            new[] { 1, 2 }.SequenceEqual(new[] { 1, 2 }));

        // ----------------------------------------------------
        // 14 MISC
        // ----------------------------------------------------
        var appended = Enumerable.Range(1, 5).Append(6);
        Console.WriteLine("\nAppend Result: " +
            string.Join(",", appended));

        Console.WriteLine("\nLINQ demo executed successfully");
    }
}
