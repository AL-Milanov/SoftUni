using System;
using System.Text.RegularExpressions;

namespace _04.AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\||#)(?<product>[A-z *]+)\1(?<date>[0-9]{2}\/[0-9]{2}\/[0-9]{2})\1(?<cal>\d+)\1";
            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);
            int calories = 0;

            foreach (Match product in matches)
            {
               calories += int.Parse(product.Groups[4].Value);
            }
            double days = calories / 2000;
            Console.WriteLine($"You have food to last you for: {Math.Ceiling(days)} days!");

            foreach (Match product in matches)
            {
                Console.WriteLine($"Item: {product.Groups[2].Value}" +
                    $", Best before: {product.Groups[3].Value}" +
                    $", Nutrition: {product.Groups[4].Value}");
            }
        }
    }
}
