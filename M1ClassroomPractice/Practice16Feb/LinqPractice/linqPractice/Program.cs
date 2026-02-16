using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Marks { get; set; }


}
public class Program
{
    static void Main()
    {
        List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        List<string> names = new() { "Ravi", "Amit", "Anil", "Ravi", "Suresh" };

        List<Student> students = new()
        {
            new Student { Id = 1, Name = "Ravi", Age = 22, Marks = 85 },
            new Student { Id = 2, Name = "Amit", Age = 21, Marks = 75 },
            new Student { Id = 3, Name = "Anil", Age = 23, Marks = 90 },
            new Student { Id = 4, Name = "Suresh", Age = 20, Marks = 65 }
        };

        //where : Filters data based on condition.
        var even = numbers.Where(n => n%2 == 0);
        foreach( var num in even)
        {
            Console.Write($"{num} ");
        }

        //ofType<T>: Filters elements of a specific type.
        ArrayList list = new() { 1, "Ravi", 2, "Amit" };
        var strings = list.ofType<string>();
        

        //select: Transforms each element.
        var squares = numbers.Select(n => n * n);




    }
}