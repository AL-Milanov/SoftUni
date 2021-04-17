using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace _03._SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%([A-Z][a-z]+)%\w*<(\w+)>\w*?\|(\d+)\|\w*?(\d+\.?\d+)\$";
            Regex regex = new Regex(pattern);

            string command = Console.ReadLine();
            
            double totalSum = 0;

            while (command != "end of shift")
            {
                Match match = regex.Match(command);

                if (regex.IsMatch(command))
                {
                    string name = match.Groups[1].Value;
                    string product = match.Groups[2].Value;
                    int quantity = int.Parse(match.Groups[3].Value);
                    double price = double.Parse(match.Groups[4].Value);
                    
                    double sum = quantity * price;
                    
                    totalSum += sum;

                    Console.WriteLine($"{name}: {product} - {sum:F2}");
                    

                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalSum:F2}");
        }
    }
}
