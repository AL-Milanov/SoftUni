using System;
using System.Text;
using CosmosX.IO.Contracts;

namespace CosmosX.IO
{
    public class ConsoleWriter : IWriter
    {
        private StringBuilder sb;

        public ConsoleWriter()
        {
            sb = new StringBuilder();
        }
        public void WriteLine(string output)
        {
            sb.AppendLine(output);
            Console.WriteLine(output);
        }

        public void Flush()
        {
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}