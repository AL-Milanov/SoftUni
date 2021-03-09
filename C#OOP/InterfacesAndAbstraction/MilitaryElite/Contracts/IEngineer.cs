using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    interface IEngineer : ISpecialisedSoldier
    {
        public Dictionary<string, int> Repairs { get; set; }
    }
}
