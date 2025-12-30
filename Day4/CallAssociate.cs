using System;

namespace Day4Constructor
{
    public class CallAssociate
    {
        public static void Main(string[] args)
        {
            Associate emp=new Associate();
            emp.Id=101;
            emp.Name="Ashif";

            string Details=emp.DisplayAssociateDetails();
            Console.WriteLine(Details);
            Console.WriteLine(emp.ErrorMeassage);
        }
    }
}