using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            ICommand command = new Command();
            var splitted = args.Split();
            return command.Execute(splitted);
        }
    }
}
