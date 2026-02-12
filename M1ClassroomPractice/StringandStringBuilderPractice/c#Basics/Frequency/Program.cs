using System;

class Program
{
    static void FindFrequency(List<int> list)
    {
        Dictionary<int,int> freq = new Dictionary<int,int>();

        foreach(var item in list)
        {
            if (freq.ContainsKey(item))
            {
                freq[item]++;
            }
            else
            {
                freq[item]=1;
            }
        }

        foreach(var entry in freq)
        {
            Console.WriteLine($"{entry.Key} - {entry.Value} times");
        }

    }
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nEnter size of list: (press enter to stop)");
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
            
            FindFrequency(list);

        
        }
    }
}