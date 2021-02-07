using System;
using System.Collections.Generic;
using System.Linq;

namespace Second
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> usernames = Console.ReadLine()
                                            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                            .ToList();
            string command = Console.ReadLine();
            int blacklist = 0;
            int lost = 0;

            while (command != "Report")
            {
                string[] cmdArgs = command.Split();
                string token = cmdArgs[0];
                string name = cmdArgs[1];

                if (token == "Blacklist")
                {
                    if (usernames.Contains(name))
                    {
                        Console.WriteLine($"{name} was blacklisted.");
                        blacklist++;
                        int index = usernames.IndexOf(name);
                        usernames[index] = "Blacklisted";
                    }
                    else
                    {
                        Console.WriteLine($"{name} was not found.");
                    }
                }
                else if (token == "Error")
                {
                    int index = int.Parse(name);
                    if (usernames[index] != "Blacklisted" && usernames[index] != "Lost")
                    {
                        Console.WriteLine($"{usernames[index]} was lost due to an error.");
                        usernames[index] = "Lost";
                        lost++;

                    }
                }
                else if (token == "Change")
                {
                    int index = int.Parse(name);
                    string newUser = cmdArgs[2];
                    if (index >= 0 && index < usernames.Count)
                    {
                        Console.WriteLine($"{usernames[index]} changed his username to {newUser}.");
                        usernames[index] = newUser;

                    }

                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Blacklisted names: {blacklist}");
            Console.WriteLine($"Lost names: {lost}");
            Console.WriteLine(string.Join(" ", usernames));
        }
    }
}
