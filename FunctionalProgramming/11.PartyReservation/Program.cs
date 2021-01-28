using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PartyReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> prfm = new List<string>();
            string command = Console.ReadLine();

            while (command != "Print")
            {
                string[] cmdArgs = command.Split(";");
                string token = cmdArgs[0];
                string filterType = cmdArgs[1];
                string argument = cmdArgs[2];

                if (token == "Add filter")
                {
                    prfm.Add($"{filterType};{argument}");
                }
                else if (token == "Remove filter")
                {
                    prfm.Remove($"{filterType};{argument}");
                }

                command = Console.ReadLine();
            }

            foreach (var filterType in prfm)
            {
                string[] token = filterType.Split(";");
                string type = token[0];
                string parameter = token[1];
                if (type == "Starts with")
                {
                    guests = guests.Where(guest => !guest.StartsWith(parameter)).ToList();
                }
                else if (type == "Ends with")
                {
                    guests = guests.Where(guest => !guest.EndsWith(parameter)).ToList();
                }
                else if (type == "Length")
                {
                    guests = guests.Where(guest => guest.Length >int.Parse(parameter)).ToList();
                }
                else if (type == "Contains")
                {
                    guests = guests.Where(guest => !guest.Contains(parameter)).ToList();
                }
            }
            Console.WriteLine(String.Join(" ", guests));
        }
    }
}
