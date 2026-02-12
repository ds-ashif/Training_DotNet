using System;

class Program
{
    static string reverse(string str)
    {
        // char[] arr = str.ToCharArray();
        // int i=0,j=arr.Length-1;
        
        // while(i<j)
        // {
        //     char temp=arr[i];
        //     arr[i]=arr[j];
        //     arr[j]=temp;
        //     i++;
        //     j--;
        // }
        // return new string(arr);

        char[] arr = new char[str.Length];

        for(int i = 0; i < str.Length; i++)
        {
            arr[i] = str[str.Length-i-1];
        }
        
        return new string(arr);
    }
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Enter string to reverse");
            string str = Console.ReadLine();

            if (string.IsNullOrEmpty(str))
            {
                Console.WriteLine("exiting..");
                break;
            }
            string result = reverse(str);
            Console.WriteLine($"Reversed string: {result}");
            
        }
        
    }
}