using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();
            string command = Console.ReadLine();

            while (command != "Craft!")
            {
                string[] cmdArgs = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                string item = cmdArgs[1];

                if (action == "Collect")
                {
                    if (!input.Contains(item))
                    {
                        input.Add(item);
                    }

                }
                else if (action == "Drop")
                {
                    if (input.Contains(item))
                    {
                        input.Remove(item);
                    }
                }
                else if (action == "Combine Items")
                {
                    string[] items = item.Split(":");
                    string oldItem = items[0];
                    string newItem = items[1];
                    if (input.Contains(oldItem))
                    {
                        int indexOfOldItem = input.IndexOf(oldItem);
                        input.Insert(indexOfOldItem + 1, newItem);

                    }
                }
                else if (action == "Renew")
                {
                    if (input.Contains(item))
                    {
                        input.Remove(item);
                        input.Add(item);
                    }
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", input));
        }
    }
}
