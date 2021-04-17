using System;
using System.Text.RegularExpressions;

namespace _02.Second
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = 
                @"(\*|@)([A-Z][a-z]{2,})\1:\s\[([A-za-z])\]\|\[([A-za-z])\]\|\[([A-za-z])\]\|?[^\s\w\d]+";
            Regex regex = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);
                int counter = 0;
                int lastIndex = input.Length - 1;
                string lastChar = input.Substring(lastIndex);
                bool isValid = lastChar != "|";
                if (isValid == true)
                {
                    Console.WriteLine("Valid message not found!");
                    continue;
                }
                for (int o = 0; o < input.Length; o++)
                {
                    isValid = true;
                    if (input[o] == '|')
                    {
                        counter++;
                       
                    }
                    
                }
                if (counter > 3)
                {
                    Console.WriteLine("Valid message not found!");
                }

                else if (match.Success)
                {
                    string firstGroup = match.Groups[3].Value;
                    int first = 0;
                    string secondGroup = match.Groups[4].Value;
                    int second = 0;
                    string thirdGroup = match.Groups[5].Value;
                    int third = 0;
                    for (int j = 0; j < firstGroup.Length; j++)
                    {
                        first += firstGroup[j];
                    }
                    for (int k = 0; k < secondGroup.Length; k++)
                    {
                        second += secondGroup[k];
                    }
                    for (int l = 0; l < thirdGroup.Length; l++)
                    {
                        third += thirdGroup[l];
                    }
                    Console.Write($"{match.Groups[2]}: {first} {second} {third}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }

            }
        }
    }
}
