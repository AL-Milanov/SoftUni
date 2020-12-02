using System;
using System.Collections.Generic;

namespace _2.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, int> materials = new Dictionary<string, int>();
            int counter = 0;
            string currMaterial = command;

            while (command != "stop")
            {
                if (counter % 2 != 0)
                {
                    materials[currMaterial] += int.Parse(command);
                }
                else if (materials.ContainsKey(command) == false)
                {
                    materials.Add(command, 0);
                    
                }

                currMaterial = command;
                command = Console.ReadLine();
                counter++;
            }

            foreach (var material in materials)
            {
                Console.WriteLine($"{material.Key} -> {material.Value}");
            }
        }
    }
}
