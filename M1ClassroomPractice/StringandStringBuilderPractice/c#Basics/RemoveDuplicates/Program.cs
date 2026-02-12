using System;

class Program
{
    static List<int> removeDuplicates(List<int> list)
    {
        HashSet<int> unique = new HashSet<int>(list);

        return unique.ToList();

    }
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nEnter size of list: ");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                break;
            }
            int size = int.Parse(input);
            List<int> list = new List<int>();

            Console.WriteLine($"Enter {size} elements");
            for(int i = 0; i < size; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }
            
            List<int> ans = removeDuplicates(list);

            foreach(var i in ans)
            {
                Console.Write($"{i}, ");
            }
        }
    }
}