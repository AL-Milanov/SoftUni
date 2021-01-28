using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();

            while (command != "Party!")
            {
                var cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string argument = cmdArgs[0];
                string type = cmdArgs[1];
                string parameter = cmdArgs[2];

                if (argument == "Remove")
                {
                    guests = RemoveFromList(guests, type, parameter);
                }
                else if (argument == "Double")
                {
                    guests = DoubleGuest(guests, type, parameter);
                }

                command = Console.ReadLine();
            }

            if (guests.Count > 0)
            {
                Console.Write(String.Join(", ", guests));
                Console.Write(" are going to the party!");

            }
            else 
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static List<string> DoubleGuest(List<string> guests, string type, string parameter)
        {
            List<string> updatedList = guests;
            List<string> copyList = new List<string>();
            switch (type)
            {
                case "StartsWith":
                    copyList = guests.Where(guest => guest.StartsWith(parameter)).ToList();
                    break;
                case "EndsWith":
                    copyList = guests.Where(guest => guest.EndsWith(parameter)).ToList();
                    break;
                case "Length":
                    copyList = guests.Where(guest => guest.Length == int.Parse(parameter)).ToList();
                    break;
                default:
                    break;
            }
            updatedList.InsertRange(0, copyList);

            return updatedList;
        }

        private static List<string> RemoveFromList(List<string> guests, string type, string parameter)
        {
            List<string> updatedList = guests;
            switch (type)
            {
                case "StartsWith":
                    updatedList = guests.Where(guest => !guest.StartsWith(parameter)).ToList();
                    break;
                case "EndsWith":
                    updatedList = guests.Where(guest => !guest.EndsWith(parameter)).ToList();
                    break;
                case "Length":
                    updatedList = guests.Where(guest => guest.Length > int.Parse(parameter)).ToList();
                    break;
                default:
                    break;
            }

            return updatedList;
        }
    }
}
