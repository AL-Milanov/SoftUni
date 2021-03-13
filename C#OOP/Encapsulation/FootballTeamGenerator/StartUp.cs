using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                var data = input.Split(";");
                
                string token = data[0];
                string teamName = data[1];

                try
                {
                    if (token == "Team")
                    {
                        teams.Add(teamName, new Team(teamName));
                    }
                    else if (!teams.ContainsKey(teamName))
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                    }
                    else if (token == "Add")
                    {
                        if (teams.ContainsKey(teamName))
                        {
                            string playerName = data[2];
                            int endurance = int.Parse(data[3]);
                            int sprint = int.Parse(data[4]);
                            int dribble = int.Parse(data[5]);
                            int passing = int.Parse(data[6]);
                            int shooting = int.Parse(data[7]);

                            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                            teams[teamName].AddPlayer(player);
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }
                    else if (token == "Remove")
                    {
                        string playerName = data[2];

                        teams[teamName].RemovePlayer(playerName);
                    }
                    else if (token == "Rating")
                    {
                        Console.WriteLine(teams[teamName]);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
