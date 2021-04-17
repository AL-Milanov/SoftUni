namespace TheTankGame.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = false;
        }

        public void Run()
        {
            while (!this.isRunning)
            {
                string line = this.reader.ReadLine();
                List<string> arguments = line.Split().ToList();

                string output = this.commandInterpreter.ProcessInput(arguments);
                this.writer.WriteLine(output);

                this.isRunning = line.Contains("Terminate");
            }

        }
    }
}