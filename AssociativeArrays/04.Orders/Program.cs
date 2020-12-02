using System;
using System.Collections.Generic;

namespace _4.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> products = new Dictionary<string, List<double>>();

            string command = Console.ReadLine();

            while (command != "buy")
            {
                string[] cmdArgs = command.Split();
                string product = cmdArgs[0];
                double price = double.Parse(cmdArgs[1]);
                int quantity = int.Parse(cmdArgs[2]);

                if (products.ContainsKey(product) == false)
                {
                    products.Add(product, new List<double>() { price, quantity });

                }
                else
                {
                    products[product][1] += quantity;
                    products[product][0] = price;
                }

                command = Console.ReadLine();
            }

            foreach (var item in products)
            {
                double totalPrice = item.Value[0] * item.Value[1];
                Console.WriteLine($"{item.Key} -> {totalPrice:f2}");
            }
        }
    }
}
