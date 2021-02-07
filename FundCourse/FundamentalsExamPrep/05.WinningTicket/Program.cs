using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _05.WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\w*[@#$^]{6,10}\w*[@#$^]{6,10}\w*)";

            string[] tickets = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Regex regex = new Regex(pattern);

            foreach (var ticket in tickets)
            {
                Match match = regex.Match(ticket);

                if (match.Success && ticket.Length >= 20)
                {
                    char symbol = Char.MinValue;
                    int rigtCount = 0;
                    int leftCount = 0;
                    int biggestCount = 0;

                    for (int i = 0; i < 10; i++)
                    {
                        if (ticket[i] == '@' || ticket[i] == '#' || ticket[i] == '$' || ticket[i] == '^')
                        {
                            symbol = ticket[i];
                            rigtCount++;
                        }
                    }
                    for (int i = 10; i < 20; i++)
                    {
                        if (ticket[i] == '@' || ticket[i] == '#' || ticket[i] == '$' || ticket[i] == '^')
                        {
                            symbol = ticket[i];
                            leftCount++;
                        }
                    }
                    if (leftCount >= rigtCount)
                    {
                        biggestCount = leftCount;
                    }
                    else
                    {
                        biggestCount = rigtCount;
                    }

                    if (biggestCount == 0)
                    {
                        Console.WriteLine($"ticket \"{ticket.Trim()}\" - no match");
                    }
                    else if (biggestCount >= 6 && biggestCount <= 9)
                    {

                        Console.WriteLine($"ticket \"{ticket.Trim()}\" - {biggestCount}{symbol}");
                    }
                    else if (biggestCount == 10)
                    {
                        Console.WriteLine($"ticket \"{ticket.Trim()}\" - {biggestCount}{symbol} Jackpot!");
                    }
                }
                else if (ticket.Length == 20)
                {
                    Console.WriteLine($"ticket \"{ticket.Trim()}\" - no match");
                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }

            }


        }
    }
}
