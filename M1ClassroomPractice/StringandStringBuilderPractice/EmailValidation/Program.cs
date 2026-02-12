using System;
using System.Collections.Generic;


class Program
{
    public static bool IsValid(string mail)
    {

        if (!mail.Contains('@')) return false;

        string[] MailParts = mail.Split('@');

        if (MailParts.Length != 2) return false;

        string user = MailParts[0];
        string domain = MailParts[1];


        if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(domain)) return false;

        //username cannot start and end with '.' and should not contains more than one '.' consecutively
        if(user.StartsWith('.') || user.EndsWith('.') || user.Contains("..")) return false;

        foreach (var ch in user)
        {
            if (char.IsWhiteSpace(ch)) return false;
            if (!char.IsLetterOrDigit(ch) && ch != '.' && ch != '-' && ch != '_') return false;
        }
        if (!domain.Contains('.')) return false;

        //domainname cannot start and end with '.' and should not contains more than one '.' consecutively
        if (domain.StartsWith('.') || domain.EndsWith('.') || domain.Contains("..")) return false;

        //check for hyphens in domain
        string[] Labels = domain.Split('.');
        foreach (var label in Labels)
        {
            if (label.StartsWith('-') || label.EndsWith('-'))
            {
                return false;
            }
        }

        //cheching domain name 
        foreach (var ch in domain)
        {
            if (char.IsWhiteSpace(ch)) return false;
            if (!char.IsLetterOrDigit(ch) && ch != '.' && ch != '-') return false;
        }




        return true;
    }

    static void Main()
    {
        while (true)
        {


            Console.WriteLine("Enter email (press enter to stop)");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Exiting..");
                break;
            }
            Console.WriteLine(IsValid(input));
        }

    }
}
