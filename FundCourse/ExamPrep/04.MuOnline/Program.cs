using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int bitcoins = 0;
            string[] room = Console.ReadLine()
                                   .Split("|", StringSplitOptions.RemoveEmptyEntries)
                                   .ToArray();
            int counter = 0;

            for (int i = 0; i < room.Length; i++)
            {
                string[] command = room[i].Split();
                string currArgs = command[0].ToLower();
                int number = int.Parse(command[1]);
                counter++;

                if (currArgs == "potion")
                {

                    int currentHp = health;
                    health += number;
                    if (health > 100)
                    {
                        Console.WriteLine($"You healed for {100 - currentHp} hp.");
                        health = 100;

                    }
                    else if (true)
                    {
                        Console.WriteLine($"You healed for {number} hp.");

                    }
                    Console.WriteLine($"Current health: {health} hp.");

                }
                else if (currArgs == "chest")
                {
                    Console.WriteLine($"You found {number} bitcoins.");
                    bitcoins += number;
                }
                else
                {
                    health -= number;
                    if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {currArgs}.");
                        Console.WriteLine($"Best room: {counter}");
                        return;

                    }
                    else if (health > 0)
                    {
                        Console.WriteLine($"You slayed {currArgs}.");
                    }
                }

            }
            
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
