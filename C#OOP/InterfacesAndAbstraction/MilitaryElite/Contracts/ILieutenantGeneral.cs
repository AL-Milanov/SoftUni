using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    interface ILieutenantGeneral : IPrivate
    {
        public Stack<Private> Privates { get; set; }
    }
}
