using System;

class Program
{
    static int FindLargest(int[] arr)
    {
        int maxEle = int.MinValue;
        foreach(int num in arr){
            if (num > maxEle)
            {
                maxEle = num;
            }
        }
        return maxEle;
    }
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Enter size of array: ");
            string input = Console.ReadLine();

            if(string.IsNullOrEmpty(input)){
                Console.WriteLine("Exiting...");
                break;
            }
            int size = int.Parse(input);
            
            int[] arr = new int[size];
            Console.WriteLine($"Enter {size} array elements");
            for(int i=0;i<size;i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            int largest = FindLargest(arr);

            Console.WriteLine($"Largest element from array is {largest}");
        }
    }
}