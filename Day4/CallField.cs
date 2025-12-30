using System;

namespace Day4Constructor
{
   public class CallField
    {
        public static void Main(string[] args)
        {
            Employee employee=new Employee();
            employee.Id=100;

            // Console.WriteLine(employee.id);  
            string result=employee.DisplayEmployeeDetails();
            Console.WriteLine(result);
        }
    
    }
}