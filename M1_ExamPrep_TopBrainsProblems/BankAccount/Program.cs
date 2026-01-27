using System;
namespace BankAccount;

public class Program
{
    /// <summary>
    /// The main entry point of the application.
    /// </summary>
    public static void Main()
    {
        Console.WriteLine("Enter Initial Balance:");
        // Read and parse the initial balance
        decimal initialBalance= decimal.TryParse(Console.ReadLine(),out initialBalance) ? initialBalance:0;
        // Array to hold 4 transactions
        int [] transactions=new int[4];

        Console.WriteLine("Enter Transactions:");
        // Read and parse 4 transactions
        for(int i=0;i<4;i++)
        {
            transactions[i]= int.TryParse(Console.ReadLine(),out transactions[i]) ? transactions[i]:0;
        }
        
        // Create an Account instance and process transactions
        Account account=new Account(initialBalance);
        // Process each transaction
        foreach(int transaction in transactions)
        {
            if (transaction >= 0)
            {
                account.deposit(transaction);
            }
            else
            {
                account.withdraw(-transaction);
            }
        }
        // Display the final balance
        Console.WriteLine("Final Balance: " + account.getBalance());

    }
}