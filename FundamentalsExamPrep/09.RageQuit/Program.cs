using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace _09.RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\D)+";
            string numberPattern = @"\d+";

            string input = Console.ReadLine();
            Regex regex = new Regex(pattern);
            Regex numberRegex = new Regex(numberPattern);

            MatchCollection matches = regex.Matches(input);
            MatchCollection numMatches = numberRegex.Matches(input);

            List<string> numbers = new List<string>();

            foreach (Match number in numMatches)
            {
                numbers.Add(number.Value.ToString());
            }


            List<string> uniqueSymbols = new List<string>();
            StringBuilder sb = new StringBuilder();
            uniqueSymbols.OrderBy(x => x);

            foreach (Match match in matches)
            {
                if (match.Success)
                {

                    for (int i = 0; i < match.Length; i++)
                    {
                        char character = match.Value[i];
                        string toUpper = character.ToString().ToUpper();

                        if (!uniqueSymbols.Contains(toUpper))
                        {
                            uniqueSymbols.Add(toUpper);

                        }
                    }
                    if (numbers.Count == 0)
                    {
                        sb.Append(match);
                    }
                    if (numbers.Count > 0)
                    {

                        int index = int.Parse(numbers[0]);

                        for (int i = 0; i < index; i++)
                        {
                            sb.Append(match.ToString().ToUpper());
                        }

                        numbers.RemoveAt(0);
                    }
                }
            }

            Console.WriteLine($"Unique symbols used: {uniqueSymbols.Count}");

            Console.WriteLine(sb.ToString());
        }
    }
}
