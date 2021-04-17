using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        
        public Engineer(int id, 
            string firstName, 
            string lastName, 
            decimal salary, 
            string corps, 
            Dictionary<string, int> repairs) 
            : base(id, firstName, lastName, salary, corps)
        {
            Repairs = repairs;
        }

        public Dictionary<string, int> Repairs { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Repairs:");
            foreach (var repair in Repairs)
            {
                sb.AppendLine($"  Part Name: {repair.Key} Hours Worked: {repair.Value}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
