using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    interface ILieutenantGeneral : IPrivate
    {
        public List<Private> Privates { get; }
    }
}
