using CosmosX.Core.Contracts;
using CosmosX.IO;
using CosmosX.IO.Contracts;
using System;

namespace CosmosX.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandParser commandParser;
        private bool isRunning;

        public Engine(IReader reader, IWriter writer, ICommandParser commandParser)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandParser = commandParser;
            this.isRunning = false;
        }

        public void Run()
        {
            while (!isRunning)
            {
                string line = reader.ReadLine();
                string[] arguments = line.Split();
                string output = commandParser.Parse(arguments);

                writer.WriteLine(output);

                if (line.Contains("Exit"))
                {
                    isRunning = true;
                }
            }
            Console.Clear();
            ((ConsoleWriter)writer).Flush();
        }
    }
}