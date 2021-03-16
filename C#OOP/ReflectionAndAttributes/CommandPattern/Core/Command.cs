using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class Command : ICommand
    {
        public string Execute(string[] args)
        {
            if (args[0].StartsWith("Hello"))
            {
                return HelloCommand(args[1]);
            }

            return ExitCommand();
        }


        private string HelloCommand(string text)
        {
            return $"Hello, {text}";
        }
        
        private string ExitCommand()
        {
            return null;
        }
    }
}
