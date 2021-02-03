using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, string> allContests = new Dictionary<string, string>();

            while (input != "end of contests")
            {
                string[] token = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contest = token[0];
                string passwordForContest = token[1];
                allContests.Add(contest, passwordForContest);

                input = Console.ReadLine();
            }

            string command = Console.ReadLine();
            SortedDictionary<string, Dictionary<string, int>> candidates = 
                                                              new SortedDictionary<string, Dictionary<string, int>>();

            while (command != "end of submissions")
            {
                string[] cmdArgs = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = cmdArgs[0];
                string password = cmdArgs[1];
                string username = cmdArgs[2];
                int points = int.Parse(cmdArgs[3]);

                foreach (var currContest in allContests)
                {
                    if (currContest.Key == contest && currContest.Value == password)
                    {
                        if (candidates.ContainsKey(username) == false)
                        {
                            candidates.Add(username, new Dictionary<string, int>());
                            candidates[username].Add(contest, points);
                        }
                        else
                        {
                            if (candidates[username].ContainsKey(contest) == false)
                            {
                                candidates[username].Add(contest, points);
                            }
                            else 
                            {
                                int currentPoints = candidates[username][contest];
                                if (points > currentPoints)
                                {
                                    candidates[username][contest] = points;
                                }
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            var bestCandidate = candidates.OrderByDescending(kvp => kvp.Value.Values.Sum()).First();
            int totalPoints = bestCandidate.Value.Values.Sum();
            
            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {totalPoints} points.");
            Console.WriteLine("Ranking:");
            
            foreach (var candidate in candidates)
            {
                Console.WriteLine(candidate.Key);
                foreach (var contests in candidate.Value.OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"#  {contests.Key} -> {contests.Value}");
                }
            }
        }
    }
}
