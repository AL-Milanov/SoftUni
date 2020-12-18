using System;
using System.Collections.Generic;

namespace HousePary
{
    class Program
    {
        static void Main(string[] args)
        {
            int command = int.Parse(Console.ReadLine());
            List<string> guests = new List<string> { };

            for (int i = 0; i < command; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string guestName = cmdArgs[0];

                if (cmdArgs[2] != "not")
                {
                    if (guests.Contains(guestName))
                    {

                        Console.WriteLine($"{guestName} is already in the list!");
                    }
                    else
                    {
                        guests.Add(guestName);
                    }
                }

                else 
                {
                    if (guests.Contains(guestName))
                    {
                        guests.Remove(guestName);
                    }
                    else
                    {
                        Console.WriteLine($"{guestName} is not in the list!");
                    }
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, guests));
        }
    }
}
