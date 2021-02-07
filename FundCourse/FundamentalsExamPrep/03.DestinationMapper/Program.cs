using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(=|\/)([A-Z][A-Za-z]{2,})\1";

            string locations = Console.ReadLine();

            Regex regex = new Regex(pattern);

            MatchCollection match = regex.Matches(locations);

            int travelPoints = 0;
            List<string> destinations = new List<string>();

            foreach (Match location in match)
            {
                destinations.Add(location.Groups[2].Value);
                travelPoints += location.Groups[2].Value.Length;

            }

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
