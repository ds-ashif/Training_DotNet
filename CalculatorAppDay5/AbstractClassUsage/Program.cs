namespace AbstractClassUsage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Payment p = new UpiPayment(499.00m, "87yyyyy@upi");
            p.Pay();
            p.PrintReceipt();
            Payment c=new CardPayment(599.00m, "1234567890123456");
            c.Pay();
            c.PrintReceipt();

        }
    }
}
