using System;
using System.Text.RegularExpressions;

namespace _15.ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<=\s)([a-z]+|\d+)(\d+|\w+|\.+|-+)([a-z]+|\d+)\@[a-z]+\-?[a-z]+\.[a-z]+(\.[a-z]+)?";
            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (var item in matches)
            {
                Console.WriteLine(item);
            }
        }
    }
}
