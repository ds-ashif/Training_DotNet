using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static string Solve(string input)
    {
        if(String.IsNullOrWhiteSpace(input)) return "";
        input = input.Trim();

        StringBuilder sb = new StringBuilder();

        bool PrevSPace = false;
        foreach(char ch in input)
        {
            if(ch == ' ')
            {
                if (!PrevSPace)
                {
                    sb.Append(' ');
                    PrevSPace=true;
                }
            }
            else
            {
                sb.Append(ch);
                PrevSPace = false;
            }
        }

        return sb.ToString();
    }
}