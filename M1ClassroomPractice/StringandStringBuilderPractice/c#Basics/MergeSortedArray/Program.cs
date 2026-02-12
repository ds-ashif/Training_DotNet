using System;

class Program
{
    static int[] MergeSortedArrays(int[] arr1, int[] arr2)
    {
        int size1 = arr1.Length;
        int size2 = arr2.Length;

        int size3 = size1+size2;

        int[] mergedArray = new int[size3];

        int i=0,j=0,k=0;

        while(i<size1 && j < size2)
        {
            if (arr1[i] < arr2[j])
            {
                mergedArray[k++] = arr1[i++];
            }
            else
            {
                mergedArray[k++] = arr2[j++];
            }
        }
        if (i < size1)
        {
            mergedArray[k++] = arr1[i++];
        }
        if (j < size2)
        {
            mergedArray[k++] = arr2[j++];
        }

        return mergedArray;
    }
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nEnter size of array1: (press enter to stop)");
            string input1 = Console.ReadLine();
            if (string.IsNullOrEmpty(input1))
            {
                break;
            }
           
            Console.WriteLine("\nEnter size of array2: (press enter to stop)");
             string input2 = Console.ReadLine();
            if (string.IsNullOrEmpty(input2))
            {
                break;
            }

            int size1 = int.Parse(input1);
            int size2 = int.Parse(input2);
            
            int[] arr1 = new int[size1];
            int[] arr2 = new int[size2];

            Console.WriteLine($"Enter {size1} elements for arr1");
            for(int i = 0; i < size1; i++)
            {
                arr1[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"Enter {size2} elements for arr12");
            for(int i = 0; i < size2; i++)
            {
                arr2[i] = int.Parse(Console.ReadLine());
            }

            int[] merged = MergeSortedArrays(arr1,arr2);

            Console.Write("Sorted merged array: ");
            foreach(var item in merged)
            {
                
                Console.Write($"{item} ");

            }


            
            

        
        }
    }
}