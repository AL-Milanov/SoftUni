using System;
using System.Text.RegularExpressions;

namespace _14.FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@\#+[A-Z][A-Za-z0-9]{4,}[A-Z]@\#+";

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();
                bool doesntContainDigits = true;
                Match match = Regex.Match(barcode, pattern);
                
                if (match.Success)
                {
                    string compare = match.Value;
                    string productGroup = "";

                    for (int j = 0; j < compare.Length; j++)
                    {
                        if (char.IsDigit(compare[j]))
                        {
                            doesntContainDigits = false;
                            productGroup += compare[j];

                        }
                    }

                    if (doesntContainDigits == true)
                    {
                        Console.WriteLine("Product group: 00");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {productGroup}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
