using System;

namespace Questions
{
    /// <summary>Menu driven program.</summary>
    public class MenuSystem
    {
        public static void Main()
        {
            try
            {
                int choice;
                do
                {
                    Console.WriteLine("1.Add  2.Sub  3.Exit");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1: Console.WriteLine("Add"); break;
                        case 2: Console.WriteLine("Sub"); break;
                    }
                }
                while (choice != 3);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }
    }
}
