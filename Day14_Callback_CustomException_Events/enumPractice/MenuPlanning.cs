using System;

namespace enumPractice
{
    #region Menu Planning

    /// <summary>
    /// Demonstrates the use of the built-in DayOfWeek enum
    /// to determine a menu plan for each day.
    /// </summary>
    public class MenuPlanning
    {
        #region Program Entry Point

        /// <summary>
        /// Application entry point.
        /// Displays the menu for a selected day of the week.
        /// </summary>
        public static void Main()
        {
            // Select a day from the DayOfWeek enum
            DayOfWeek day = DayOfWeek.Thursday;

            // Display the menu for the selected day
            Console.WriteLine($"Menu for {day}: {MenuByDay(day)}");
        }

        #endregion

        #region Menu Logic

        /// <summary>
        /// Returns the menu item based on the given day of the week.
        /// </summary>
        /// <param name="day">Day of the week (enum value)</param>
        /// <returns>Menu item for the specified day</returns>
        public static string MenuByDay(DayOfWeek day)
        {
            // Determine the menu using a switch statement on enum values
            switch (day)
            {
                case DayOfWeek.Sunday:
                    return "Roast Chicken";

                case DayOfWeek.Monday:
                    return "Spaghetti Bolognese";

                case DayOfWeek.Tuesday:
                    return "Taco Tuesday";

                case DayOfWeek.Wednesday:
                    return "Grilled Salmon";

                case DayOfWeek.Thursday:
                    return "Stir Fry Vegetables";

                case DayOfWeek.Friday:
                    return "Pizza Night";

                case DayOfWeek.Saturday:
                    return "BBQ Ribs";

                default:
                    return "Unknown Day";
            }
        }

        #endregion
    }

    #endregion
}
