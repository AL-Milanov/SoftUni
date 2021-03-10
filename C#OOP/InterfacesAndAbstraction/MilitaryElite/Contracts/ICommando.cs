using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    interface ICommando : ISpecialisedSoldier
    {
        public Dictionary<string, string> Missions { get; }

    }
}
