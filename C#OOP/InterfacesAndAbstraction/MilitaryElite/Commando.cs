using MilitaryElite.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private Dictionary<string, string> missions;

        public Commando(int id, 
            string firstName, 
            string lastName, 
            decimal salary, 
            string corps,
            Dictionary<string, string> missions) 
            : base(id, firstName, lastName, salary, corps)
        {
            Missions = missions;
        }

        public Dictionary<string, string> Missions 
        {
            get => missions;
            private set
            {
                
                missions = value.Where(s => s.Value == "inProgress" || s.Value == "Finished")
                    .ToDictionary(k => k.Key, v => v.Value);
            } 
        }

        public void CompleteMission(string mission)
        {
            missions[mission] = "Finished";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Missions:");
            foreach (var mission in Missions)
            {
                sb.AppendLine($"  Code Name: {mission.Key} State: {mission.Value}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
