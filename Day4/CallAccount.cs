using System;

namespace Day4Constructor
{
    class CallAccount
    {
        public static void Main(string[] args)
        {
            Account account = new Account() { AccountId = 1, Name = "Account1"};
            string result = account.GetAccountDetails();
            Console.WriteLine(result);

            SalesAccount salesAccount = new SalesAccount() { AccountId = 1, Name = "Balu", SalesInfo = "Handled 25 corporate clients" };
            string result1=salesAccount.GetSalesAccountDetails();
            Console.WriteLine(result1);

            PurchaseAccount purchaseAccount=new PurchaseAccount(){AccountId = 1, Name = "Balu", PurchaseInfo="Purchase 25 units"};
            string result2=purchaseAccount.GetPurchaseDetails();
            Console.WriteLine(result2);


        }
    }
}