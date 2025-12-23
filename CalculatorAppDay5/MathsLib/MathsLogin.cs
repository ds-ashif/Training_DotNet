using CommonLib;
using System;

namespace MathsLib
{
    public class MathsLogin : LoginAbs
    {
        public override void Login(string username, string password)
        {
            Console.WriteLine($"Maths login successful for user: {username}");
        }

        public override void Logout()
        {
            Console.WriteLine("Maths user logged out.");
        }
    }
}
