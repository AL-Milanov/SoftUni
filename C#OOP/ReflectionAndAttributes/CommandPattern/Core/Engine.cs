using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Core
{
    class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                var args = Console.ReadLine();
                Console.WriteLine(commandInterpreter.Read(args));

                if (args == "CommandPattern.Core.ExitCommand")
                {
                    break;
                }
            }
            
        }
    }
}
