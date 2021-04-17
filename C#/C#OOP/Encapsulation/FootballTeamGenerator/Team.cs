using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private const int BaseRating = 0;
        private List<Player> players;
        private NameValidator nameValidator = new NameValidator();
        private string teamName;


        public Team(string teamName)
        {
            TeamName = teamName;
            players = new List<Player>();
        }

        public string TeamName 
        {
            get => teamName;
            private set
            {
                nameValidator.ValidName(value);
                teamName = value;
            } 
        }


        public int TeamRaiting => (int)Math.Round(players.Average(s => s.Stats));

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(n => n.Name == playerName);
            if (player == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {TeamName} team.");
            }

            players.Remove(player);
        }

        public override string ToString()
        {
            return players.Count > 0 ? $"{TeamName} - {TeamRaiting}"
                : $"{TeamName} - {BaseRating}";
        }
    }
}
