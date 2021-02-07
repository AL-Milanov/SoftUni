using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> vloggers = 
                new Dictionary<string, Dictionary<string, SortedSet<string>>>();
            string commmand = Console.ReadLine();

            while (commmand != "Statistics")
            {
                string[] cmdArgs = commmand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstVlogger = cmdArgs[0];
                string token = cmdArgs[1];

                if (token == "joined")
                {
                    if (vloggers.ContainsKey(firstVlogger) == false)
                    {
                        vloggers.Add(firstVlogger, new Dictionary<string, SortedSet<string>>());
                        vloggers[firstVlogger].Add("following", new SortedSet<string>());
                        vloggers[firstVlogger].Add("followers", new SortedSet<string>());
                    }
                }
                else if (token == "followed")
                {
                    string secondVlogger = cmdArgs[2];

                    if (vloggers.ContainsKey(firstVlogger) && vloggers.ContainsKey(secondVlogger))
                    {
                        if (firstVlogger != secondVlogger)
                        {
                              vloggers[firstVlogger]["following"].Add(secondVlogger);
                                vloggers[secondVlogger]["followers"].Add(firstVlogger);
                        }
                    }
                }

                commmand = Console.ReadLine();
            }
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            var sortedDataVloggers = vloggers.OrderByDescending(kvp => kvp.Value["followers"].Count)
                .ThenBy(kvp => kvp.Value["following"].Count)
                .ToDictionary(kvp => kvp.Key, kvp=> kvp.Value);
            int counter = 0;
            
            foreach (var vlogger in sortedDataVloggers)
            {
                int followers = vlogger.Value["followers"].Count;
                int followings = vlogger.Value["following"].Count;
                Console.WriteLine($"{++counter}. {vlogger.Key} : {followers} followers, {followings} following");
                if (counter == 1)
                {
                    foreach (var data in vlogger.Value["followers"])
                    {
                        Console.WriteLine($"*  {data}");
                    }
                }
            }
        }
    }
}
