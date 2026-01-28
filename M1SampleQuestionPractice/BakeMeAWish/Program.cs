using System;
using System.Collections.Generic;

namespace BakeMeAWish
{
    // CakeOrder class as per specification
    class CakeOrder
    {
        // Dictionary to store OrderId as Key and CakeCost as Value
        private Dictionary<string, double> orderMap = new Dictionary<string, double>();

        // Getter for orderMap
        public Dictionary<string, double> GetOrderMap()
        {
            return orderMap;
        }

        // Setter for orderMap
        public void SetOrderMap(Dictionary<string, double> orderMap)
        {
            this.orderMap = orderMap;
        }

        // Requirement 1: Add cake order details to the orderMap
        public void AddOrderDetails(string orderId, double cakeCost)
        {
            orderMap[orderId] = cakeCost;
        }

        // Requirement 2: Filter orders above the specified cake cost
        public Dictionary<string, double> FindOrdersAboveSpecifiedCost(double cakeCost)
        {
            Dictionary<string, double> filteredOrders = new Dictionary<string, double>();

            foreach (var order in orderMap)
            {
                if (order.Value > cakeCost)
                {
                    filteredOrders.Add(order.Key, order.Value);
                }
            }

            return filteredOrders;
        }
    }

    // UserInterface class containing Main method
    class Program
    {
        public static void Main()
        {
            CakeOrder cakeOrder = new CakeOrder();

            Console.WriteLine("Enter number of cake orders to be added");
            int numberOfOrders = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the cake order details (Order Id: CakeCost)");

            // Reading order details
            for (int i = 0; i < numberOfOrders; i++)
            {
                string input = Console.ReadLine();
                string[] orderDetails = input.Split(':');

                string orderId = orderDetails[0];
                double cakeCost = double.Parse(orderDetails[1]);

                cakeOrder.AddOrderDetails(orderId, cakeCost);
            }

            Console.WriteLine("Enter the cost to search the cake orders");
            double searchCost = double.Parse(Console.ReadLine());

            // Fetch filtered orders
            Dictionary<string, double> resultOrders =
                cakeOrder.FindOrdersAboveSpecifiedCost(searchCost);

            // Display output
            if (resultOrders.Count == 0)
            {
                Console.WriteLine("No cake orders found");
            }
            else
            {
                Console.WriteLine("Cake Orders above the specified cost");
                foreach (var order in resultOrders)
                {
                    Console.WriteLine(
                        "Order ID: " + order.Key + ", Cake Cost: " + order.Value.ToString("0.0")
                    );
                }
            }
        }
    }
}
