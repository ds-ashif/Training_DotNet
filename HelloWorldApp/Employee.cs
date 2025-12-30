//namespace HelloWorldApp            // we can use namespace to group related multiple classes together
//{
class Employee{
    int Id;
    string Name;
    string Department;
    float Salary;
    char Gender;


    public void AcceptDetails(){
        Console.WriteLine("Enter Employee Employees Details:");
        Console.WriteLine("Enter Employee ID: ");
        Id=Convert.ToInt32(Console.ReadLine());
        //Id=int.parse(Console.ReadLine());    //other way to convert string to int
        Console.WriteLine("Enter Employee Name: ");
        Name=Console.ReadLine();
        Console.WriteLine("Enter Employee Department: ");
        Department=Console.ReadLine();
        Console.WriteLine("Enter Employee Salary: ");
        Salary=Convert.ToSingle(Console.ReadLine());     // to convert string to float
        Console.WriteLine("Enter Employee Gender: ");
        Gender=Convert.ToChar(Console.ReadLine());     // to convert string to char
        

        
    }
    public void DisplayDetails(){
        Console.WriteLine("Employee Details:");
        Console.WriteLine("Employee ID: "+Id);
        Console.WriteLine($"Employee Name: {Name}");   // another way of string interpolation
        Console.WriteLine("Employee Department: "+Department);
        Console.WriteLine("Employee Salary: "+Salary);
        Console.WriteLine("Employee Gender: "+Gender);
    }
}




//}