using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shit = Console.ReadLine()
                                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                       .ToList();
            string command = Console.ReadLine().ToLower();
            int count = 0;

            while (command != "end")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int firstIndex = int.Parse(cmdArgs[0]);
                int secondIndex = int.Parse(cmdArgs[1]);
                count++;

                bool isValidIndex = firstIndex >= 0 && firstIndex < shit.Count 
                    && secondIndex >= 0 && secondIndex < shit.Count
                    && firstIndex != secondIndex;
                if (!isValidIndex)
                {
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    int middleIndex = shit.Count / 2;
                    string[] message = new string[] { 
                        ($"-{count}a"),
                        ($"-{count}a") 
                    };
                    shit.InsertRange(middleIndex , message);
                    
                }
                else if (shit[firstIndex] == shit[secondIndex])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {shit[firstIndex]}!");
                    string removePoint = shit[firstIndex];
                    shit.RemoveAll(x=>x == removePoint);
                }
                else if (shit[firstIndex] != shit[secondIndex])
                {
                    Console.WriteLine("Try again!");
                }
                if (shit.Count == 0)
                {
                    Console.WriteLine($"You have won in {count} turns!");
                    return;
                }

                command = Console.ReadLine();
            }
            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(" ", shit));
        }
    }
}
