using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Core
{
    public class Command : ICommand
    {
        public string Execute(string[] args)
        {
            Type type = Type.GetType(args[0]);
            var typeActivate = (ICommand)Activator.CreateInstance(type, new object[] { });
            
            return $"{typeActivate.Execute(args)}";
        }

    }
}
