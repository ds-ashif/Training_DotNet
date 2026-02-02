using System;
using System.Collections.Generic;

namespace SteamBuzz
{
    
    /// <summary>
    /// Stores engagement data of a creator including
    /// creator name and weekly likes.
    /// </summary>
    public class CreatorStats
    {
        /// <summary>
        /// Name of the content creator.
        /// </summary>
        public string? CreatorName { get; set; }

        /// <summary>
        /// Likes received for four weeks.
        /// </summary>
        public double[] WeeklyLikes { get; set; }
    }


    /// <summary>
    /// Main program class responsible for creator registration,engagement analysis, and displaying statistics.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Stores all creator engagement records.
        /// </summary>
        public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();

        /// <summary>
        /// Registers a creator record into the EngagementBoard.
        /// </summary>
        public void RegisterCreator(CreatorStats record)
        {
            EngagementBoard.Add(record);
        }

        /// <summary>
        /// Counts number of weeks each creator meets or exceeds
        /// the provided like threshold.
        /// </summary>
        
        public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (var creator in records)
            {
                int count = 0;

                foreach (var likes in creator.WeeklyLikes)
                {
                    if (likes >= likeThreshold)
                        count++;
                }

                if (count > 0)
                    result[creator.CreatorName] = count;
            }

            return result;
        }

        /// <summary>
        /// Calculates average weekly likes across all creators.
        /// </summary>
        /// <returns>Average weekly likes value.</returns>
        public double CalculateAverageLikes()
        {
            double totalLikes = 0;
            int totalEntries = 0;

            foreach (var creator in EngagementBoard)
            {
                foreach (var likes in creator.WeeklyLikes)
                {
                    totalLikes += likes;
                    totalEntries++;
                }
            }

            if (totalEntries == 0)
                return 0;

            return totalLikes / totalEntries;
        }

        /// <summary>
        /// Entry point method handling menu-driven interaction.
        /// </summary>
        public static void Main(string[] args)
        {
            Program app = new Program();
            int choice;

            do
            {
                Console.WriteLine("\n1. Register Creator");
                Console.WriteLine("2. Show Top Posts");
                Console.WriteLine("3. Calculate Average Likes");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice:");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Creator Name:");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter weekly likes (Week 1 to 4):");

                        double[] likes = new double[4];
                        for (int i = 0; i < 4; i++)
                        {
                            likes[i] = double.Parse(Console.ReadLine());
                        }

                        CreatorStats record = new CreatorStats
                        {
                            CreatorName = name,
                            WeeklyLikes = likes
                        };

                        app.RegisterCreator(record);
                        Console.WriteLine("Creator registered successfully");
                        break;

                    case 2:
                        Console.WriteLine("Enter like threshold:");
                        double threshold =
                            double.Parse(Console.ReadLine());

                        var results =
                            app.GetTopPostCounts(
                                EngagementBoard,
                                threshold);

                        if (results.Count == 0)
                        {
                            Console.WriteLine(
                                "No top-performing posts this week");
                        }
                        else
                        {
                            foreach (var entry in results)
                            {
                                Console.WriteLine(
                                    $"{entry.Key} - {entry.Value}");
                            }
                        }
                        break;

                    case 3:
                        double average =
                            app.CalculateAverageLikes();

                        Console.WriteLine(
                            $"Overall average weekly likes: {average}");
                        break;

                    case 4:
                        Console.WriteLine(
                            "Logging off - Keep Creating with StreamBuzz!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again...Enter 1 to 4 only");
                        break;
                }

            } while (choice != 4);
        }
    }
}


