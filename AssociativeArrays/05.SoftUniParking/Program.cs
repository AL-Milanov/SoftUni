using System;
using System.Collections.Generic;

namespace _5.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parkingSlots = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();
                string cmdArgs = commands[0];
                string username = commands[1];

                if (cmdArgs == "register")
                {
                    string licensePlateNumber = commands[2];

                    if (parkingSlots.ContainsKey(username) == false)
                    {
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                        parkingSlots.Add(username, licensePlateNumber);
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {parkingSlots[username]}");
                    }

                }
                else if (cmdArgs == "unregister")
                {
                    if (parkingSlots.ContainsKey(username) == false)
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        Console.WriteLine($"{username} unregistered successfully");
                        parkingSlots.Remove(username);
                    }
                }

            }
            foreach (var item in parkingSlots)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
