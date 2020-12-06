using System;
using System.Collections.Generic;

namespace _06.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<char> output = new List<char>();

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    continue;
                }
                else
                {
                    output.Add(input[i]);
                }
            }
            output.Add(input[input.Length - 1]);

            foreach (var symbol in output)
            {
                Console.Write(symbol);
            }
        }
    }
}
