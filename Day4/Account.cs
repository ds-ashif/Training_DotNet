using System;

namespace Day4Constructor
{



    // public sealed class CreditCardAccount{      //sealed: stop the class to be inherited by any other class
        
    // }


    //summary 
        //Account class
    //

    // #region Account_class start
    public class Account
    {
        public string Name{get; set;}
        public int AccountId{get; set;}

        public string GetAccountDetails()
        {
            return $"This is base Account. Id is {AccountId} ";
        }
    }

    // #regionEnd

    // <summary>
    //     Sales Account class
    // </summary>

    //region SalesAccount starts

    public class SalesAccount : Account 
    {
        public string SalesInfo { get; set; }
        public string GetSalesAccountDetails()
        {
            string info = string.Empty;
            info += base.GetAccountDetails();
            info += $"I am from Sales Derived class, Sales Info: {SalesInfo}";
            return info;
        }
        
    }
    //regionEnd

    // <summary>
    //     Purchase Account start
    // </summary>

    //#region purchaseAccount start

    public class PurchaseAccount: Account
    {
        public string PurchaseInfo{get; set;}

        public string GetPurchaseDetails()
        {
            string info=string.Empty;
            info+=base.GetAccountDetails();
            info+=$"I am from Purchase Derived class, PurchaseInfo is {PurchaseInfo} ";
            return info;
        }
    }
    // #endregion

}