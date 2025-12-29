namespace AraysUse
{
    public class Program
    {
        /// <summary>
        /// Serves as the entry point for the application. Demonstrates the creation and usage of single-dimensional,
        /// multidimensional, and jagged arrays in C#.
        /// Real-world use case
        ///  1D: Daily sales for 30 days
        ///  2D: Monthly sales for multiple products
        ///  Jagged: Monthly calendar (different days per month)
        /// </summary>
        /// <remarks>This method outputs examples of different array types to the console, including their
        /// initialization and iteration. It is intended for educational purposes to illustrate array concepts in C#. No
        /// command-line arguments are required for execution.</remarks>
        /// <param name="args">An array of command-line arguments supplied to the application.</param>
        /// 


        static void Main(string[] args)
        {
            ///<summary>
            ///Single-Dimensional Array: A linear array with a single row of elements.
            ///</summary>


            int[] scores = { 85, 90, 72, 88 };

            Console.WriteLine("All Scores:");
            for (int i = 0; i < scores.Length; i++)
                Console.WriteLine($"scores[{i}] = {scores[i]}");

            // Average
            int sum = 0;
            foreach (var s in scores) sum += s;
            Console.WriteLine("Average = " + (sum / (double)scores.Length));

            ///<summary>
            /// Multidimensional Array: A rectangular array with multiple rows and columns.
            /// </summary>
            int[,] marks = {
            { 78, 81, 90 },
            { 65, 70, 72 }
            };

            Console.WriteLine("Matrix:");
            for (int r = 0; r < marks.GetLength(0); r++)
            {
                for (int c = 0; c < marks.GetLength(1); c++)
                    Console.Write(marks[r, c] + " ");
                Console.WriteLine();
            }

            ///<summary>
            ///Jagged Array: An array of arrays, where each "row" can have a different length.
            ///</summary>
            int[][] data = new int[3][];
            data[0] = new int[] { 1, 2, 3 };
            data[1] = new int[] { 10, 20 };
            data[2] = new int[] { 7, 8, 9, 10 };

            for (int i = 0; i < data.Length; i++)
            {
                Console.Write("Row " + i + ": ");
                foreach (var v in data[i]) Console.Write(v + " ");
                Console.WriteLine();
            }
    }
    }
}
