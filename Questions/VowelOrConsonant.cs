using System;

namespace Questions
{
    /// <summary>Checks vowel or consonant.</summary>
    public class VowelOrConsonant
    {
        public static void Main()
        {
            char ch = char.Parse(Console.ReadLine().ToLower());

            switch (ch)
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                    Console.WriteLine("Vowel");
                    break;
                default:
                    Console.WriteLine("Consonant");
                    break;
            }
        }
    }
}
