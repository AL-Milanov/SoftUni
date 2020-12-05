using System;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>([A-z]+)<<(\d+\.?\d+)!(\d+)";

            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();
            double totalMoneySpend = 0;

            Console.WriteLine("Bought furniture:");

            while (input != "Purchase")
            {
                Match match = regex.Match(input);

                if (regex.IsMatch(input))
                {
                    string furniture = match.Groups[1].Value;
                    double price = double.Parse(match.Groups[2].Value);
                    double quantity = double.Parse(match.Groups[3].Value);

                    totalMoneySpend += price * quantity;
                    Console.WriteLine(furniture);
                }


                input = Console.ReadLine();
            }
            Console.WriteLine($"Total money spend: {totalMoneySpend:f2}");
        }
    }
}
