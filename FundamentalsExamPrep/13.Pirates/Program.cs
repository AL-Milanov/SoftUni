using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            string prep = Console.ReadLine();
            Dictionary<string, List<int>> towns = new Dictionary<string, List<int>>();
            while (prep != "Sail")
            {
                string[] token = prep.Split("||", StringSplitOptions.RemoveEmptyEntries);
                string town = token[0];
                int people = int.Parse(token[1]);
                int gold = int.Parse(token[2]);

                if (towns.ContainsKey(town) == false)
                {
                    towns.Add(town, new List<int> { people, gold });
                }
                else
                {
                    towns[town][0] += people;
                    towns[town][1] += gold;
                }

                prep = Console.ReadLine();

            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] cmdArgs = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                string town = cmdArgs[1];
                if (action == "Plunder")
                {
                    int people = int.Parse(cmdArgs[2]);
                    int gold = int.Parse(cmdArgs[3]);
                    towns[town][0] -= people;
                    towns[town][1] -= gold;

                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (towns[town][0] <= 0 || towns[town][1] <= 0)
                    {
                        Console.WriteLine($"{town} has been wiped off the map!");
                        towns.Remove(town);
                    }
                }
                else if(action == "Prosper")
                {
                    int gold = int.Parse(cmdArgs[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine($"Gold added cannot be a negative number!");
                    }
                    else
                    {
                        towns[town][1] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury." +
                            $" {town} now has {towns[town][1]} gold.");
                    }
                }

                command = Console.ReadLine();
            }

            if (towns.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");
                foreach (var town in towns.OrderByDescending(x=> x.Value[1]).ThenBy(n=> n.Key))
                {
                    Console.WriteLine($"{town.Key} -> Population: {town.Value[0]} citizens, Gold: {town.Value[1]} kg");
                }
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }

        }
    }
}
