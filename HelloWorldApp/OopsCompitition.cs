using System;
using System.Transactions;
namespace HelloWorldApp
{
    public class Employee
    {
        public int Id;
        public string Name;
        public string Department;
        public string Registered;

        public Employee()
        {
            
            Console.WriteLine("Enter Employee Details: Id, Name, Department, Registered");
            Id=Convert.ToInt32(Console.ReadLine());
            Name=Console.ReadLine();
            Department=Console.ReadLine();
            Registered=Console.ReadLine();
            
        }

        public void GetEmployeeDetails()
        {
            Console.WriteLine($"Employee Details: ");
            Console.WriteLine($"  Id: {Id}");
            Console.WriteLine($"  Name: {Name}");
            Console.WriteLine($"  Department: {Department}");
            Console.WriteLine($"  Registered: {Registered}");

        }
            
    }
    public class Compitition
    {
        public string Category;
        public string Discription;
        public int ParticipantID;

        public Compitition()
        {
            Console.WriteLine("Enter Compition details: Category, Discription, ParticipantID ");
            Category=Console.ReadLine();
            Discription=Console.ReadLine();
            ParticipantID=Convert.ToInt32(Console.ReadLine());

        }

        public void GetCompitionDetails()
        {
            
            Console.WriteLine("Compition details like which employee registered for compition");

            Console.WriteLine($"   Category: {Category}");
            Console.WriteLine($"   Discription: {Discription}");
            Console.WriteLine($"   ParticipantId: {ParticipantID}");
        }
    }

    public class ResultDetails
    {
        public string CompititionCategory;
        public int ParticipantId;
        public int Rank;
        public string Remarks;

        public ResultDetails()
        {
          Console.WriteLine("Enter Result Details: Compition Category, participantid, Rank, Remarks");
          CompititionCategory=Console.ReadLine();   
          ParticipantId=Convert.ToInt32(Console.ReadLine());
          Rank=Convert.ToInt32(Console.ReadLine());
          Remarks=Console.ReadLine();   
        } 

        public void Results()
        {
            Console.WriteLine($"Details: ");
            Console.WriteLine($"   Participant id: {ParticipantId}");
            Console.WriteLine($"   Rank: {Rank}");
            Console.WriteLine($"   Remarks: {Remarks}");
            Console.WriteLine($"   Compitition Category: {CompititionCategory}");
        }

    }
}