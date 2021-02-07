using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.HelloFrance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split('|')
                .ToList();
            double startBudget = double.Parse(Console.ReadLine());
            double budget = startBudget;
            double finalBudget = 0;
            List<double> newPrices = new List<double>();
            
            for (int i = 0; i < input.Count; i++)
            {
                string[] items = input[i].Split("->").ToArray();
                string item = items[0];
                double price = double.Parse(items[1]);
                if (item == "Clothes")
                {
                    if (price <= 50.00)
                    {
                        if (budget >= price)
                        {
                            budget -= price;
                            double newPrice = price + (price * 0.4);
                            finalBudget += newPrice;
                            newPrices.Add(newPrice);
                        }
                    }
                }
                else if (item == "Shoes")
                {
                    if (price <= 35.00)
                    {
                        if (budget >= price)
                        {
                            budget -= price;
                            double newPrice = price + (price * 0.4);
                            finalBudget += newPrice;
                            newPrices.Add(newPrice);
                        }
                    }
                }
                else if (item == "Accessories")
                {
                    if (price <= 20.50)
                    {
                        if (budget >= price)
                        {
                            budget -= price;
                            double newPrice = price + (price * 0.4);
                            finalBudget += newPrice;
                            newPrices.Add(newPrice);
                        }
                    }
                }

            }
            foreach (double item in newPrices)
            {
                Console.Write($"{item:f2} ");
            }
            Console.WriteLine();
            double profit = (budget + newPrices.Sum()) - startBudget;
            Console.WriteLine($"Profit: {profit:f2}");
            if (budget + finalBudget >= 150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }

        }
    }
}
