using System;
using System.Collections.Generic;

class Program
{
    public static List<int> CheckUniqueAttendance(List<int> scans)
    {
        HashSet<int> track = new HashSet<int>();
        foreach(var item in scans)
        {
            track.Add(item);
        }
        return track.ToList();
    }
    static void Main()
    {
        var input = new List<int>{10, 20, 10, 30, 20, 40};
        var result = CheckUniqueAttendance(input);
        Console.WriteLine("First time punch: ");

        foreach(var item in result)
        {
            Console.WriteLine(item);
        }
    }
}