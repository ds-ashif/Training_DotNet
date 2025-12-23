// using System;

// namespace HelloWorldApp
// {
//     public class CheckEven
//     {
//         // public void CheckEvenOrOdd()
//         // {
//         //     Console.Write("Enter a number: ");
//         //     int num = Convert.ToInt32(Console.ReadLine());

//         //     if (num % 2 == 0)
//         //         Console.WriteLine($"{num} is even");
//         //     else
//         //         Console.WriteLine($"{num} is odd");
//         // }

//         public bool IsEven(int number){
//             return number % 2 == 0;
//         }

//         public static void Main(string[] args){
//             CheckEven ce = new CheckEven();
//             Console.WriteLine("Enter a number to check even or odd (press q to quit) ");
//             string? input=Console.ReadLine();
//             int number=0;
//             bool check=false;

//             while(input!="q" || input!="Q"){
//                 number=int.TryParse(input, out number);

//                 check=ce.IsEven(number);
//                 (check)? Console.WriteLine($"{number} is even"): Console.WriteLine($"{number} is odd");

//                 Console.WriteLine("Enter a number to check even or odd (press q to quit) ");
//                 input=Console.ReadLine();
//             }
//         }
//     }
// }






using System;

namespace HelloWorldApp
{
    public class CheckEven
    {
        public bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        public void CheckEvenOrOdd()
        {
            Console.Write("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(
                IsEven(number)
                ? $"{number} is even"
                : $"{number} is odd"
            );
        }
    }
}
