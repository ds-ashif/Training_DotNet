//namespace HelloWorldApp
//{
class Calculator{
    int num1;
    int num2;
    int sum;
    int difference;
    int product;
    int divide;
    int remainder;

    public void Addition(){
        Console.WriteLine("Enter first number: ");
        num1=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter second number: "); 
        num2=Convert.ToInt32(Console.ReadLine());

        sum=num1+num2;
        Console.WriteLine($"Sum of {num1} and {num2} is: {sum}");

    }

    public void Subtraction(){
        Console.WriteLine("Enter first number: ");
        num1=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter second number: "); 
        num2=Convert.ToInt32(Console.ReadLine());

        difference=num1-num2;
        Console.WriteLine($"Difference of {num1} and {num2} is: {difference}");

    }
    public void Multiplication(){
        Console.WriteLine("Enter first number: ");
        num1=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter second number: "); 
        num2=Convert.ToInt32(Console.ReadLine());

        product=num1*num2;
        Console.WriteLine($"Product of {num1} and {num2} is: {product}");

    }

    public void Division(){
        Console.WriteLine("Enter first number: ");
        num1=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter second number: "); 
        num2=Convert.ToInt32(Console.ReadLine());

        if(num2!=0){
            divide=num1/num2;
            Console.WriteLine($"Division of {num1} by {num2} is: {divide}");
        }
        else{
            Console.WriteLine("Error: Division by zero is not allowed.");
        }

    }
    public void Modulus(){
        Console.WriteLine("Enter firt number: ");
        num1=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter second number: "); 
        num2=Convert.ToInt32(Console.ReadLine());       
        remainder=num1%num2;
        Console.WriteLine($"Remainder of {num1} divided by {num2} is: {remainder}");    
    }
}
//}