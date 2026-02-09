/**
Q11. Invoice Generator - StringBuilder
An invoice should be generated for multiple items without slow string concatenation.
Requirements:
•	Input 5 items: ItemName, Qty, Price
•	Compute line totals and grand total
•	Use StringBuilder to build the invoice text
Task: Print invoice in a neat layout with totals.
**/

using System;
using System.Text;

class Program
{
    /// <summary>
    /// Generates invoice using StringBuilder
    /// to efficiently build large text output.
    /// </summary>
    static void Main()
    {
        // StringBuilder object to build invoice text efficiently
        StringBuilder invoice = new StringBuilder();

        double grandTotal = 0;

        //Invoice Header
        invoice.AppendLine("=========== INVOICE ===========");
        invoice.AppendLine("Item\tQty\tPrice\tTotal");
        invoice.AppendLine("--------------------------------");

        // Read details for 5 items
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Enter details for Item {i}");
            Console.Write("Item Name: ");
            string itemName = Console.ReadLine();

            Console.Write("Quantity: ");
            int qty = int.Parse(Console.ReadLine());

            Console.Write("Price per item: ");
            double price = double.Parse(Console.ReadLine());

            // Calculate line total
            double total = qty * price;

            // Add to grand total
            grandTotal += total;

            // Append formatted line to invoice
            invoice.AppendLine($"{itemName}\t{qty}\t{price}\t{total}");
        }

        // Invoice footer
        invoice.AppendLine("--------------------------------");
        invoice.AppendLine($"Grand Total:\t\t\t{grandTotal}");
        invoice.AppendLine("================================");

        //print invoice
        Console.WriteLine("\n" + invoice.ToString());
    }
}