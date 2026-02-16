using System;
using System.Collections.Generic;


public class Account
{
    public string AccountNumber{get; set;}
    public string HolderName{get; set;}

    public decimal Balance{get; set;}
}

public class NegativeBalanceException : Exception{}
public class InsufficientFundsException : Exception{}

public class AccountNotFoundException : Exception{}

public class BankUtility
{
    private SortedDictionary<decimal, List<Account>> AccountDetails = new SortedDictionary<decimal, List<Account>>();
    public void AddAccounts(Account account)
    {   //negative balance check
        if(account.Balance < 0 ) throw new NegativeBalanceException();

        foreach(var list in AccountDetails.Values)
        {
            foreach(var acc in list)
            {
                if(acc.AccountNumber == account.AccountNumber) return;
            }
        }

        if (!AccountDetails.ContainsKey(account.Balance))
        {
            AccountDetails[account.Balance]= new List<Account>();
        }
        AccountDetails[account.Balance].Add(account);
    }

    //-----------------Display-----------------------
    public SortedDictionary<decimal,List<Account>> DisplayAccounts()
    {
        return AccountDetails;
    }

    //------------Deposit-----------------
    public void Deposit(string accno, decimal amount)
    {
        if (amount < 0)
        {
            throw new NegativeBalanceException();
        }

        foreach(var pair in AccountDetails)
        {
            var list = pair.Value;
            for(int i=0; i < list.Count; i++)
            {
                if(list[i].AccountNumber == accno)
                {
                    Account acc = list[i];
                    list.RemoveAt(i);
                    if(list.Count == 0)
                    {
                        AccountDetails.Remove(pair.Key);
                    }

                    acc.Balance += amount;
                    AddAccounts(acc);
                    return;
                }
            }
        }
        throw new AccountNotFoundException();
    }

    // ---------- WITHDRAW ----------

    public void Withdraw(string accNo, decimal amount)
    {
        foreach(var pair in AccountDetails)
        {
            var list = pair.Value;
            for(int i = 0; i < list.Count; i++)
            {
                if(list[i].AccountNumber == accNo)
                {
                    Account acc = list[i];
                    if(acc.Balance<amount) throw new InsufficientFundsException();

                    list.RemoveAt(i);
                    if (list.Count == 0)
                    {
                        AccountDetails.Remove(pair.Key);
                    }
                    acc.Balance -= amount;
                    AddAccounts(acc);
                    return;
                }
            }
        }
        throw new AccountNotFoundException();
    }
}

class Program
{
    static void Main()
    {
        BankUtility bank = new BankUtility();
        while (true)
        {
            Console.WriteLine("\n1 Display Accounts");
            Console.WriteLine("2 Deposit");
            Console.WriteLine("3 Withdraw");
            Console.WriteLine("4 Add Account");
            Console.WriteLine("5 Exit");

            Console.WriteLine("Enter Choice: ");
            int choice = int.Parse(Console.ReadLine());

            //--------------------display------------
            if (choice == 1)
            {
                var data = bank.DisplayAccounts();
                foreach(var pair in data)
                {
                    foreach(var acc in pair.Value)
                    {
                        Console.WriteLine($"Details: {acc.AccountNumber} {acc.HolderName} {acc.Balance}");
                    }
                }
            }
            else if(choice == 2)
            {
                Console.WriteLine("Enter AccountNumber and amount:");
                var input = Console.ReadLine().Split(' ');
                bank.Deposit(input[0],decimal.Parse(input[1]));
                Console.WriteLine("Deposit Successful.");

            }
            // ----- WITHDRAW -----
            else if(choice == 3)
            {
                Console.WriteLine("Enter AccountNumber and amount:");
                var input = Console.ReadLine().Split(' ');
                bank.Withdraw(input[0],decimal.Parse(input[1]));
                Console.WriteLine("Withdrawal Successful.");
            }
            else if(choice == 4)
            {
                Console.WriteLine("Enter Account holders details: <AccountNo> <HolderName> <Balance>");
                var input = Console.ReadLine().Split(' ');

                Account account = new Account
                {
                    AccountNumber = input[0],
                    HolderName = input[1],
                    Balance = decimal.Parse(input[2])
                };
                bank.AddAccounts(account);
                Console.WriteLine("Account created successfully!");
            }
            else if(choice == 5)
            {
                Console.WriteLine("Exiting...");
                break;
            }

        }
    }
}