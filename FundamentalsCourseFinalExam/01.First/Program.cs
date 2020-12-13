using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.First
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> guests = new Dictionary<string, List<string>>();

            int unlikedMeals = 0;
            string command = Console.ReadLine();

            while (command != "Stop")
            {
                string[] cmdArgs = command.Split("-");
                string token = cmdArgs[0];
                string guest = cmdArgs[1];
                string meal = cmdArgs[2];

                if (token == "Like")
                {
                    if (guests.ContainsKey(guest) == false)
                    {
                        guests.Add(guest, new List<string> { meal });
                    }
                    else if (guests.ContainsKey(guest))
                    {
                        if (guests[guest].Contains(meal) == false)
                        {
                            guests[guest].Add(meal);
                        }
                    }
                }
                else if (token == "Unlike")
                {
                    if (guests.ContainsKey(guest) == false)
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                    else
                    {
                        if (guests[guest].Contains(meal) == false)
                        {
                            Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                        }
                        else if (guests[guest].Contains(meal))
                        {
                            guests[guest].Remove(meal);
                            Console.WriteLine($"{guest} doesn't like the {meal}.");
                            unlikedMeals++;
                        }
                    }
                }
                command = Console.ReadLine();
            }
            foreach (var item in guests.OrderBy(x=>x.Value[0]))
            {

            }
            foreach (var item in guests.OrderByDescending(x => x.Value.Count))
            {

                Console.WriteLine($"{item.Key}: {string.Join(", ", item.Value.OrderBy(n => n))}");
            }
            Console.WriteLine($"Unliked meals: {unlikedMeals}");
        }
    }
}
