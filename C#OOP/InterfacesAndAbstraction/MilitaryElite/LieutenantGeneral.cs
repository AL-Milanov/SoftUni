using MilitaryElite.Contracts;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, Stack<Private> privates) 
            : base(id, firstName, lastName, salary)
        {
            Privates = privates;
        }

        public Stack<Private> Privates { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            foreach (var soldier in Privates)
            {
                sb.AppendLine($"  {soldier}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
