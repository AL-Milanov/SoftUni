using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => roster.Count;


        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = roster.Where(n => n.Name == name).FirstOrDefault();

            if (player == null)
            {
                return false;
            }

            roster.Remove(player);
            return true;
        }

        public void PromotePlayer(string name)
        {
            Player player = roster.Where(n => n.Name == name).FirstOrDefault();

            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            Player player = roster.Where(n => n.Name == name).FirstOrDefault();

            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string playerClass)
        {
            Player[] players = roster.Where(c => c.Class == playerClass).ToArray();
            roster.RemoveAll(c => c.Class == playerClass);
            return players;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            int count = 0;

            foreach (var player in roster)
            {
                if (count == Count -1)
                {
                    sb.Append(player);
                }
                else
                {
                    sb.AppendLine($"{player}");
                    count++;
                }
            }

            return sb.ToString();
        }
    }
}
