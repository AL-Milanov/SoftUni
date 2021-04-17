using System;

namespace _07.WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string destinations = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Travel")
            {
                string[] cmdArgs = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string token = cmdArgs[0];

                if (token == "Add Stop")
                {
                    int index = int.Parse(cmdArgs[1]);
                    string newDestination = cmdArgs[2];

                    if (index >=0 && index <= destinations.Length)
                    {
                        destinations = destinations.Insert(index, newDestination);
                        
                    }

                }
                else if (token == "Remove Stop")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);
                    bool isValidIndex = startIndex >= 0 && 
                                        endIndex < destinations.Length;

                    if (isValidIndex)
                    {
                        int removeLength = endIndex - startIndex + 1;
                        destinations = destinations.Remove(startIndex, removeLength);
                        
                    }
                }
                else if (token == "Switch")
                {
                    string oldString = cmdArgs[1];
                    string newString = cmdArgs[2];

                    if (destinations.Contains(oldString))
                    {
                        destinations = destinations.Replace(oldString, newString);
                        
                    }
                }

                Console.WriteLine(destinations);
                input = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {destinations}");

        }
    }
}
