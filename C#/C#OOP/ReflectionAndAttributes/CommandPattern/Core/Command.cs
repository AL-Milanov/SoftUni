using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class Command : ICommand
    {
        public string Execute(string[] args)
        {
            var strategy = Assembly.GetEntryAssembly()
                .GetTypes()
                .Where(t => (typeof(ICommand).IsAssignableFrom(t))
                && typeof(ICommand) != t)
                .First(t => t.Name.Contains(args[0]));

            ICommand sortingStrategy = (ICommand)Activator.CreateInstance(strategy);

            return $"{sortingStrategy.Execute(args)}";
        }

    }
}
